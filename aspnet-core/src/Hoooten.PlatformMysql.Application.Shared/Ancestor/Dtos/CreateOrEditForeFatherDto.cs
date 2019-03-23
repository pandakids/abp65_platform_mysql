
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class CreateOrEditForeFatherDto : FullAuditedEntityDto<int?>
    {

		[Required]
		[StringLength(ForeFatherConsts.MaxNameLength, MinimumLength = ForeFatherConsts.MinNameLength)]
		public string Name { get; set; }
		
		
		[StringLength(ForeFatherConsts.MaxCenturyLength, MinimumLength = ForeFatherConsts.MinCenturyLength)]
		public string Century { get; set; }

        /// <summary>
        /// ÐÔ±ð
        /// </summary>
        public string Sexy { get; set; }


        public DateTime? BornAt { get; set; }
		
		
		public DateTime? DieAt { get; set; }
		
		
		public int LoveNumber { get; set; }
		
		
		public int FlowersNumber { get; set; }
		
		
		public int MoneyNumber { get; set; }
		
		
		public int GoldNumber { get; set; }
		
		
		public double Lon { get; set; }
		
		
		public double Lat { get; set; }
		
		
		[StringLength(ForeFatherConsts.MaxMarksLength, MinimumLength = ForeFatherConsts.MinMarksLength)]
		public string Marks { get; set; }
		
		
		 public Guid? BinaryObjectId { get; set; }
		 
		 //public int? TempleId { get; set; }
		 
		 
    }
}