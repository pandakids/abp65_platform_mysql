using Abp.AutoMapper;
using Hoooten.PlatformMysql.Sessions.Dto;

namespace Hoooten.PlatformMysql.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}