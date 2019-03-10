using Abp.Application.Services.Dto;
using System;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class GetAllForeFathersForExcelInput
    {
		public string Filter { get; set; }

		public string NameFilter { get; set; }

		public string CenturyFilter { get; set; }


		 public string BinaryObjectTenantIdFilter { get; set; }

		 		 public string TempleNameFilter { get; set; }

		 
    }
}