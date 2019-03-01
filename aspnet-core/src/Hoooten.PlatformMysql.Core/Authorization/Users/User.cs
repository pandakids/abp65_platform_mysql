using System;
using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Users;
using Abp.Extensions;
using Abp.Timing;
using Hoooten.PlatformMysql.Ancestor;

namespace Hoooten.PlatformMysql.Authorization.Users
{
    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class User : AbpUser<User>
    {
        public virtual Guid? ProfilePictureId { get; set; }

        public virtual bool ShouldChangePasswordOnNextLogin { get; set; }

        public DateTime? SignInTokenExpireTimeUtc { get; set; }

        public string SignInToken { get; set; }

        public string GoogleAuthenticatorKey { get; set; }

        //Can add application specific user properties here

        /// <summary>
        /// 年代 十五世
        /// </summary>
		[StringLength(ForeFatherConsts.MaxCenturyLength, MinimumLength = ForeFatherConsts.MinCenturyLength)]
        public virtual string Century { get; set; }

        /// <summary>
        /// 出生
        /// </summary>
        public virtual DateTime? BornAt { get; set; }

        /// <summary>
        /// 死于
        /// </summary>
        public virtual DateTime? DieAt { get; set; }

        /// <summary>
        /// 爱心数量
        /// </summary>
        public virtual int LoveNumber { get; set; }

        /// <summary>
        /// 鲜花数量
        /// </summary>
        public virtual int FlowersNumber { get; set; }

        /// <summary>
        /// 纸钱数量
        /// </summary>
        public virtual int MoneyNumber { get; set; }

        /// <summary>
        /// 元宝数量
        /// </summary>
        public virtual int GoldNumber { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public virtual string Lon { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public virtual string Lat { get; set; }

        /// <summary>
        /// 签到时间
        /// 1. 每天签到 得 5 爱心
        /// 2. 连续三天签到得 额外得30 爱心
        /// 3. 连续五天签到得 额外奖励纸钱1000
        /// 4. 连续10天签到得 额外奖励纸钱2000
        /// </summary>
        public virtual DateTime SignDate { get; set; }

        //Can add application specific user properties here


        public User()
        {
            IsLockoutEnabled = true;
            IsTwoFactorEnabled = true;
        }

        /// <summary>
        /// Creates admin <see cref="User"/> for a tenant.
        /// </summary>
        /// <param name="tenantId">Tenant Id</param>
        /// <param name="emailAddress">Email address</param>
        /// <returns>Created <see cref="User"/> object</returns>
        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress
            };

            user.SetNormalizedNames();

            return user;
        }

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public override void SetNewPasswordResetCode()
        {
            /* This reset code is intentionally kept short.
             * It should be short and easy to enter in a mobile application, where user can not click a link.
             */
            PasswordResetCode = Guid.NewGuid().ToString("N").Truncate(10).ToUpperInvariant();
        }

        public void Unlock()
        {
            AccessFailedCount = 0;
            LockoutEndDateUtc = null;
        }

        public void SetSignInToken()
        {
            SignInToken = Guid.NewGuid().ToString();
            SignInTokenExpireTimeUtc = Clock.Now.AddMinutes(1).ToUniversalTime();
        }
    }
}