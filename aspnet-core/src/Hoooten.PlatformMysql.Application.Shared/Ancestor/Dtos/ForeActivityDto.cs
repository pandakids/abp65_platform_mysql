
using System;
using Abp.Application.Services.Dto;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class ForeActivityDto : EntityDto
    {
		public string Name { get; set; }

		public string Address { get; set; }

		public string Content { get; set; }


		 public Guid? BinaryObjectId { get; set; }

		 		 public int? TempleId { get; set; }

		 
    }
}