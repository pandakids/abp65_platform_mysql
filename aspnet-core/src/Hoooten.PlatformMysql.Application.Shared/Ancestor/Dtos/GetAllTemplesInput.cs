using Abp.Application.Services.Dto;
using System;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class GetAllTemplesInput : PagedAndSortedResultRequestDto
    {
		public string Filter { get; set; }

		public string NameFilter { get; set; }

		public string FanmilyNameFilter { get; set; }

		public int IsShowFilter { get; set; }


		 public string BinaryObjectBytesFilter { get; set; }

		 		 public string UserNameFilter { get; set; }

		 		 public string CitycidFilter { get; set; }

		 
    }
}