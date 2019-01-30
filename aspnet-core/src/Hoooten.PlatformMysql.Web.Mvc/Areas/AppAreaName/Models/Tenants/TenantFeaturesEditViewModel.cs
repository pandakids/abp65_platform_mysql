using Abp.AutoMapper;
using Hoooten.PlatformMysql.MultiTenancy;
using Hoooten.PlatformMysql.MultiTenancy.Dto;
using Hoooten.PlatformMysql.Web.Areas.AppAreaName.Models.Common;

namespace Hoooten.PlatformMysql.Web.Areas.AppAreaName.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }

        public TenantFeaturesEditViewModel(Tenant tenant, GetTenantFeaturesEditOutput output)
        {
            Tenant = tenant;
            output.MapTo(this);
        }
    }
}