
using System;
using Abp.Application.Services.Dto;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class TempleDto : EntityDto
    {
		public string Name { get; set; }

		public string Code { get; set; }

		public string FanmilyName { get; set; }

		public string Address { get; set; }

		public string Photo { get; set; }

		public bool IsShow { get; set; }

		public double Lon { get; set; }

		public double Lat { get; set; }


		 public Guid? BinaryObjectId { get; set; }

		 		 public long? UserId { get; set; }

		 		 public int? CityId { get; set; }

		 
    }
}