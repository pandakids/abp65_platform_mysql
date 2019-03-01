
using Hoooten.PlatformMysql.Storage;

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

		/// <summary>
        /// 年代 十五世
        /// </summary>
		[StringLength(ForeFatherConsts.MaxCenturyLength, MinimumLength = ForeFatherConsts.MinCenturyLength)]
		public virtual string Century { get; set; }
		
		public virtual DateTime? BornAt { get; set; }
		
		public virtual DateTime? DieAt { get; set; }
		
		public virtual int LoveNumber { get; set; }
		
		public virtual int FlowersNumber { get; set; }
		
		public virtual int MoneyNumber { get; set; }
		
		public virtual int GoldNumber { get; set; }
		
		public virtual string Lon { get; set; }
		
		public virtual string Lat { get; set; }
		
		[StringLength(ForeFatherConsts.MaxMarksLength, MinimumLength = ForeFatherConsts.MinMarksLength)]
		public virtual string Marks { get; set; }
		

		public virtual Guid? BinaryObjectId { get; set; }
		public BinaryObject BinaryObject { get; set; }
		
    }
}