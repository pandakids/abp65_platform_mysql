﻿using Hoooten.PlatformMysql.Dto;

namespace Hoooten.PlatformMysql.Common.Dto
{
    public class FindUsersInput : PagedAndFilteredInputDto
    {
        public int? TenantId { get; set; }
    }
}