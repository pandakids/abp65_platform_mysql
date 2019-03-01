
using Hoooten.PlatformMysql.Authorization.Users;
using Hoooten.PlatformMysql.Ancestor;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace Hoooten.PlatformMysql.Ancestor
{
	[Table("TempleMembers")]
    public class TempleMember : FullAuditedEntity 
    {



		[StringLength(TempleMemberConsts.MaxMarksLength, MinimumLength = TempleMemberConsts.MinMarksLength)]
		public virtual string Marks { get; set; }
		
		public virtual bool IsApproved { get; set; }
		

		public virtual long UserId { get; set; }
		public User User { get; set; }
		
		public virtual int TempleId { get; set; }
		public Temple Temple { get; set; }
		
    }
}