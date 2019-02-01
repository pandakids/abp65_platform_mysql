using Abp.Application.Services.Dto;
using System;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class GetAllCitiesForExcelInput
    {
		public string Filter { get; set; }

		public string cidFilter { get; set; }

		public string locationFilter { get; set; }

		public string parent_cityFilter { get; set; }

		public string admin_areaFilter { get; set; }

		public string cntyFilter { get; set; }



    }
}