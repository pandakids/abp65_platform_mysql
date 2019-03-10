
using Hoooten.PlatformMysql.Storage;
using Hoooten.PlatformMysql.Ancestor;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace Hoooten.PlatformMysql.Ancestor
{
	[Table("ForeFathers")]
    public class ForeFather : FullAuditedEntity 
    {



		[Required]
		[StringLength(ForeFatherConsts.MaxNameLength, MinimumLength = ForeFatherConsts.MinNameLength)]
		public virtual string Name { get; set; }
		
		[StringLength(ForeFatherConsts.MaxCenturyLength, MinimumLength = ForeFatherConsts.MinCenturyLength)]
		public virtual string Century { get; set; }
		
		public virtual DateTime? BornAt { get; set; }
		
		public virtual DateTime? DieAt { get; set; }
		
		public virtual int LoveNumber { get; set; }
		
		public virtual int FlowersNumber { get; set; }
		
		public virtual int MoneyNumber { get; set; }
		
		public virtual int GoldNumber { get; set; }
		
		public virtual double Lon { get; set; }
		
		public virtual double Lat { get; set; }
		
		[StringLength(ForeFatherConsts.MaxMarksLength, MinimumLength = ForeFatherConsts.MinMarksLength)]
		public virtual string Marks { get; set; }
		

		public virtual Guid? BinaryObjectId { get; set; }
		public BinaryObject BinaryObject { get; set; }
		
		public virtual int? TempleId { get; set; }
		public Temple Temple { get; set; }
		
    }
}