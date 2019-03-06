using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Linq;
using Hoooten.PlatformMysql.Authorization.Roles;
using System.Threading.Tasks;

namespace Hoooten.PlatformMysql.Authorization.Users
{
    /// <summary>
    /// Used to perform database operations for <see cref="UserManager"/>.
    /// </summary>
    public class UserStore : AbpUserStore<Role, User>
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<User, long> _userRepository;

        public UserStore(
            IRepository<User, long> userRepository,
            IRepository<UserLogin, long> userLoginRepository,
            IRepository<UserRole, long> userRoleRepository,
            IRepository<Role> roleRepository,
            IAsyncQueryableExecuter asyncQueryableExecuter, 
            IUnitOfWorkManager unitOfWorkManager,
            IRepository<UserClaim, long> userCliamRepository,
            IRepository<UserPermissionSetting, long> userPermissionSettingRepository)
            : base(
                unitOfWorkManager,
                userRepository,
                roleRepository,
                asyncQueryableExecuter,
                userRoleRepository,
                userLoginRepository,
                userCliamRepository,
                userPermissionSettingRepository)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _userRepository = userRepository;
        }

        /// <summary>
        /// 通过手机号查询用户
        /// </summary>
        /// <param name="phoneNumber">手机号</param>
        /// <returns></returns>
        public virtual async Task<User> FindByPhoneNumberAsync(string phoneNumber)
        {
            return await _userRepository.FirstOrDefaultAsync(model => model.PhoneNumber == phoneNumber);
        }

        /// <summary>
        /// 通过手机号查询用户
        /// </summary>
        /// <param name="tenantId">租户id</param>
        /// <param name="phoneNumber">手机号</param>
        /// <returns></returns>
        [UnitOfWork]
        public virtual async Task<User> FindByPhoneNumberAsync(int? tenantId, string phoneNumber)
        {
            using (_unitOfWorkManager.Current.SetTenantId(tenantId))
            {
                return await FindByPhoneNumberAsync(phoneNumber);
            }
        }

    }
}