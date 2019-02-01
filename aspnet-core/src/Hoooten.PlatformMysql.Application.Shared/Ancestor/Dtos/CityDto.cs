
using System;
using Abp.Application.Services.Dto;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class CityDto : EntityDto
    {
		public string cid { get; set; }

		public string location { get; set; }

		public string parent_city { get; set; }

		public string admin_area { get; set; }

		public string cnty { get; set; }

		public string lat { get; set; }

		public string lon { get; set; }

		public string tz { get; set; }

		public string type { get; set; }



    }
}