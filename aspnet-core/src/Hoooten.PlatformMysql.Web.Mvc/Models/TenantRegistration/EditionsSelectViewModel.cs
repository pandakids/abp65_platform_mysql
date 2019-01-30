using Abp.AutoMapper;
using Hoooten.PlatformMysql.MultiTenancy.Dto;

namespace Hoooten.PlatformMysql.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(EditionsSelectOutput))]
    public class EditionsSelectViewModel : EditionsSelectOutput
    {
        public EditionsSelectViewModel(EditionsSelectOutput output)
        {
            output.MapTo(this);
        }
    }
}
