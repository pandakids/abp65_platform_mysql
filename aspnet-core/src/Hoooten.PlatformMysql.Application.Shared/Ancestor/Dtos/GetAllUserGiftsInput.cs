using Abp.Application.Services.Dto;
using System;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class GetAllUserGiftsInput : PagedAndSortedResultRequestDto
    {
		public string Filter { get; set; }


		 public string UserNameFilter { get; set; }

		 
    }
}