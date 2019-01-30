using System.Collections.Generic;
using Hoooten.PlatformMysql.Caching.Dto;

namespace Hoooten.PlatformMysql.Web.Areas.AppAreaName.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}