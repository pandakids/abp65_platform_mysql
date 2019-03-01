
using System;
using Abp.Application.Services.Dto;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class ForeFatherDto : EntityDto
    {
		public string Name { get; set; }

		public string Century { get; set; }

		public DateTime? BornAt { get; set; }

		public DateTime? DieAt { get; set; }

		public int LoveNumber { get; set; }

		public int FlowersNumber { get; set; }

		public int MoneyNumber { get; set; }

		public int GoldNumber { get; set; }

		public string Lon { get; set; }

		public string Lat { get; set; }

		public string Marks { get; set; }


		 public Guid? BinaryObjectId { get; set; }

		 
    }
}