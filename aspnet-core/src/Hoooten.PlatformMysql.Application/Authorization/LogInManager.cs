using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Zero.Configuration;
using Microsoft.AspNetCore.Identity;
using Hoooten.PlatformMysql.Authorization.Roles;
using Hoooten.PlatformMysql.Authorization.Users;
using Hoooten.PlatformMysql.MultiTenancy;
using Abp.UI;
using Abp.Timing;
using System.Threading.Tasks;
using Abp.Extensions;
using System.Security.Claims;

namespace Hoooten.PlatformMysql.Authorization
{
    public class LogInManager : AbpLogInManager<Tenant, Role, User>
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<Tenant> _tenantRepository;
        private readonly IMultiTenancyConfig _multiTenancyConfig;
        private readonly UserManager _userManager;
        private readonly UserClaimsPrincipalFactory _claimsPrincipalFactory;
        private readonly UserStore _userStore;

        public LogInManager(
            UserManager userManager, 
            IMultiTenancyConfig multiTenancyConfig, 
            IRepository<Tenant> tenantRepository, 
            IUnitOfWorkManager unitOfWorkManager, 
            ISettingManager settingManager, 
            IRepository<UserLoginAttempt, long> userLoginAttemptRepository, 
            IUserManagementConfig userManagementConfig, 
            IIocResolver iocResolver, 
            RoleManager roleManager,
            IPasswordHasher<User> passwordHasher,
            UserClaimsPrincipalFactory claimsPrincipalFactory,
            UserStore userStore)
            : base(
                  userManager, 
                  multiTenancyConfig, 
                  tenantRepository, 
                  unitOfWorkManager, 
                  settingManager, 
                  userLoginAttemptRepository, 
                  userManagementConfig, 
                  iocResolver, 
                  passwordHasher,
                  roleManager,
                  claimsPrincipalFactory)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _tenantRepository = tenantRepository;
            _multiTenancyConfig = multiTenancyConfig;
            _userManager = userManager;
            _claimsPrincipalFactory = claimsPrincipalFactory;
            _userStore = userStore;
        }

        /// <summary>
        /// 手机验证码登陆
        /// </summary>
        /// <param name="phoneNumber">手机号</param>
        /// <param name="captcha">验证码</param>
        /// <param name="tenantName">租户名</param>
        /// <param name="shouldLockout">是否锁定</param>
        /// <returns></returns>
        public virtual async Task<AbpLoginResult<Tenant, User>> LoginByMobileAsync(string phoneNumber, int captcha,
            string tenantName = null, bool shouldLockout = true)
        {
            var result = await LoginByMobileAsyncInternal(phoneNumber, captcha, tenantName, shouldLockout);
            await SaveLoginAttempt(result, tenantName, result.User.UserName);
            return result;
        }


        /// <summary>
        /// 手机验证码登陆内部方法
        /// </summary>
        /// <param name="phoneNumber">手机号</param>
        /// <param name="captcha">验证码</param>
        /// <param name="tenantName">租户名</param>
        /// <param name="shouldLockout">是否锁定</param>
        /// <returns></returns>
        protected virtual async Task<AbpLoginResult<Tenant, User>> LoginByMobileAsyncInternal(string phoneNumber,
            int captcha, string tenantName, bool shouldLockout)
        {
            if (phoneNumber.IsNullOrEmpty())
            {
                //Logger.Error("手机号不能为空");
                throw new UserFriendlyException("手机号不能为空");
            }
            //获取和检查租户
            Tenant tenant = null;
            //设置当前租户id为空
            using (_unitOfWorkManager.Current.SetTenantId(null))
            {
                //如果关闭租户就获取默认租户
                if (!_multiTenancyConfig.IsEnabled)
                {
                    //获取默认租户
                    tenant = await GetDefaultTenantAsync();
                }
                //租户id是否为空
                else if (!string.IsNullOrWhiteSpace(tenantName))
                {
                    //查询租户信息
                    tenant = await _tenantRepository.FirstOrDefaultAsync(model => model.TenancyName == tenantName);
                    if (tenant == null)
                        //返回无效租户
                        return new AbpLoginResult<Tenant, User>(AbpLoginResultType.InvalidTenancyName);
                    if (!tenant.IsActive)
                        //返回租户未启用
                        return new AbpLoginResult<Tenant, User>(AbpLoginResultType.TenantIsNotActive, tenant);
                }
            }
            //设置租户id
            var tenantId = tenant == null ? (int?)null : tenant.Id;
            //设置当前租户id
            using (_unitOfWorkManager.Current.SetTenantId(tenantId))
            {
                //初始化选项
                await _userManager.InitializeOptionsAsync(tenantId);
                var loggedInFromExternalSource = false;
                //通过手机号查询用户
                var user = await _userStore.FindByPhoneNumberAsync(tenantId, phoneNumber);
                if (user == null)
                    //返回无效用户
                    return new AbpLoginResult<Tenant, User>(AbpLoginResultType.InvalidUserNameOrEmailAddress, tenant);
                //用户是否被锁定
                if (await _userManager.IsLockedOutAsync(user))
                    //返回锁定用户
                    return new AbpLoginResult<Tenant, User>(AbpLoginResultType.LockedOut, tenant, user);
                if (!loggedInFromExternalSource)
                {
                    if (!_userManager.CheckCaptcha(user, captcha))
                    {
                        //是否锁定
                        if (shouldLockout)
                        {
                            //锁定账户
                            if (await TryLockOutAsync(tenantId, user.Id))
                                //返回锁定账户
                                return new AbpLoginResult<Tenant, User>(AbpLoginResultType.LockedOut, tenant, user);
                        }
                        //返回无效密码
                        return new AbpLoginResult<Tenant, User>(AbpLoginResultType.InvalidPassword, tenant, user);
                    }
                    //重置登陆失败次数
                    await UserManager.ResetAccessFailedCountAsync(user);
                }
                return await CreateLoginByMobileResultAsync(user, tenant);
            }
        }

        /// <summary>
        /// 创建手机号登陆结果
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="tenant">租户</param>
        /// <returns></returns>
        protected virtual async Task<AbpLoginResult<Tenant, User>> CreateLoginByMobileResultAsync(User user,
            Tenant tenant = null)
        {
            //用户未激活
            if (!user.IsActive)
                //返回用户未激活
                return new AbpLoginResult<Tenant, User>(AbpLoginResultType.UserIsNotActive, tenant, user);
            //用户手机号未认证
            if (user.IsPhoneNumberConfirmed)
                //返回用户手机号未认证
                return new AbpLoginResult<Tenant, User>(AbpLoginResultType.UserPhoneNumberIsNotConfirmed, tenant, user);
            user.LastLoginTime = Clock.Now;
            //更新用户
            await _userManager.UpdateAsync(user);
            await _unitOfWorkManager.Current.SaveChangesAsync();
            var principal = await _claimsPrincipalFactory.CreateAsync(user);
            return new AbpLoginResult<Tenant, User>(
                tenant,
                user,
                principal.Identity as ClaimsIdentity
            );
        }

    }
}