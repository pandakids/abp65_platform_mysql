using Abp.Application.Services.Dto;
using System;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class GetAllTempleMembersInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public int IsApprovedFilter { get; set; }


        public string UserNameFilter { get; set; }

        public string TempleNameFilter { get; set; }

        public int TempleId { get; set; }
    }
}