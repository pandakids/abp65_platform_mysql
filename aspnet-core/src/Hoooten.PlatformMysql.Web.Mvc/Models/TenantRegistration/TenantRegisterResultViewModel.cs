using Abp.AutoMapper;
using Hoooten.PlatformMysql.MultiTenancy.Dto;

namespace Hoooten.PlatformMysql.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(RegisterTenantOutput))]
    public class TenantRegisterResultViewModel : RegisterTenantOutput
    {
        public string TenantLoginAddress { get; set; }
    }
}