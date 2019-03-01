
using Hoooten.PlatformMysql.Ancestor;
using Hoooten.PlatformMysql.Authorization.Users;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace Hoooten.PlatformMysql.Ancestor
{
	[Table("ForeFatherGifts")]
    public class ForeFatherGift : FullAuditedEntity 
    {



		public virtual int TheGiftType { get; set; }
		
		public virtual int GiftNumber { get; set; }
		

		public virtual int ForeFatherId { get; set; }
		public ForeFather ForeFather { get; set; }
		
		public virtual long? UserId { get; set; }
		public User User { get; set; }
		
    }
}