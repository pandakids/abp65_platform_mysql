
using Hoooten.PlatformMysql.Authorization.Users;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace Hoooten.PlatformMysql.Ancestor
{
	[Table("UserGifts")]
    public class UserGift : FullAuditedEntity 
    {



		public virtual int TheGiftType { get; set; }
		
		public virtual int GiftNumber { get; set; }
		
		public virtual DateTime? SignDate { get; set; }
		
		public virtual int GiftSource { get; set; }
		

		public virtual long UserId { get; set; }
		public User User { get; set; }
		
    }
}