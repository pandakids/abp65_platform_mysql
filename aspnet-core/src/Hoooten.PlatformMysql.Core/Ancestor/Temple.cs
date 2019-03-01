
using Hoooten.PlatformMysql.Storage;
using Hoooten.PlatformMysql.Authorization.Users;
using Hoooten.PlatformMysql.Ancestor;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace Hoooten.PlatformMysql.Ancestor
{
	[Table("Temples")]
    public class Temple : FullAuditedEntity 
    {



		[Required]
		[StringLength(TempleConsts.MaxNameLength, MinimumLength = TempleConsts.MinNameLength)]
		public virtual string Name { get; set; }
		
		[StringLength(TempleConsts.MaxCodeLength, MinimumLength = TempleConsts.MinCodeLength)]
		public virtual string Code { get; set; }
		
		[Required]
		[StringLength(TempleConsts.MaxFanmilyNameLength, MinimumLength = TempleConsts.MinFanmilyNameLength)]
		public virtual string FanmilyName { get; set; }
		
		[StringLength(TempleConsts.MaxAddressLength, MinimumLength = TempleConsts.MinAddressLength)]
		public virtual string Address { get; set; }
		
		[StringLength(TempleConsts.MaxPhotoLength, MinimumLength = TempleConsts.MinPhotoLength)]
		public virtual string Photo { get; set; }
		
		public virtual bool IsShow { get; set; }
		

		public virtual Guid? BinaryObjectId { get; set; }
		public BinaryObject BinaryObject { get; set; }
		
		public virtual long? UserId { get; set; }
		public User User { get; set; }

        /// <summary>
        /// 推荐人
        /// 用于推广运营时使用
        /// </summary>
        public virtual long? RecommendUserId { get; set; }
        public User RecommendUser { get; set; }

        public virtual int? CityId { get; set; }
		public City City { get; set; }
		
    }
}