
using Hoooten.PlatformMysql.Storage;
using Hoooten.PlatformMysql.Ancestor;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace Hoooten.PlatformMysql.Ancestor
{
	[Table("ForeActivities")]
    public class ForeActivity : FullAuditedEntity 
    {



		[Required]
		[StringLength(ForeActivityConsts.MaxNameLength, MinimumLength = ForeActivityConsts.MinNameLength)]
		public virtual string Name { get; set; }
		
		[StringLength(ForeActivityConsts.MaxAddressLength, MinimumLength = ForeActivityConsts.MinAddressLength)]
		public virtual string Address { get; set; }
		
		[StringLength(ForeActivityConsts.MaxContentLength, MinimumLength = ForeActivityConsts.MinContentLength)]
		public virtual string Content { get; set; }
		

		public virtual Guid? BinaryObjectId { get; set; }
		public BinaryObject BinaryObject { get; set; }
		
		public virtual int? TempleId { get; set; }
		public Temple Temple { get; set; }
		
    }
}