using Abp.Application.Services.Dto;
using System;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class GetAllTempleMembersForExcelInput
    {
		public string Filter { get; set; }

		public int IsApprovedFilter { get; set; }


		 public string UserNameFilter { get; set; }

		 		 public string TempleNameFilter { get; set; }

		 
    }
}