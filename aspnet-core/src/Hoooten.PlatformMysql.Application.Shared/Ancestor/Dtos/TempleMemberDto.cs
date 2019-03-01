
using System;
using Abp.Application.Services.Dto;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class TempleMemberDto : EntityDto
    {
		public string Marks { get; set; }

		public bool IsApproved { get; set; }


		 public long UserId { get; set; }

		 		 public int TempleId { get; set; }

		 
    }
}