using System;
using System.ComponentModel.DataAnnotations;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.Domain.Entities;

namespace Hoooten.PlatformMysql.Authorization.Users.Dto
{
    //Mapped to/from User in CustomDtoMapper
    public class UserEditDto : IPassivable
    {
        /// <summary>
        /// Set null to create a new user. Set user's Id to update a user
        /// </summary>
        public long? Id { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxSurnameLength)]
        public string Surname { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        [StringLength(UserConsts.MaxPhoneNumberLength)]
        public string PhoneNumber { get; set; }

        // Not used "Required" attribute since empty value is used to 'not change password'
        [StringLength(AbpUserBase.MaxPlainPasswordLength)]
        [DisableAuditing]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public bool ShouldChangePasswordOnNextLogin { get; set; }

        public virtual bool IsTwoFactorEnabled { get; set; }

        public virtual bool IsLockoutEnabled { get; set; }


        public string Sexy { get; set; }

        public DateTime SignDate { get; set; }
        public string Lon { get; set; }
        public string Lat { get; set; }
        /// <summary>
        /// 爱心数量
        /// </summary>
        public int LoveNumber { get; set; }

        /// <summary>
        /// 鲜花数量
        /// </summary>
        public int FlowersNumber { get; set; }

        /// <summary>
        /// 纸钱数量
        /// </summary>
        public int MoneyNumber { get; set; }

        /// <summary>
        /// 元宝数量
        /// </summary>
        public int GoldNumber { get; set; }
        public string Century { get; set; }
    }
}