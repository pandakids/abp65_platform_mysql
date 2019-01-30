using Abp.AspNetCore.Mvc.ViewComponents;

namespace Hoooten.PlatformMysql.Web.Views
{
    public abstract class PlatformMysqlViewComponent : AbpViewComponent
    {
        protected PlatformMysqlViewComponent()
        {
            LocalizationSourceName = PlatformMysqlConsts.LocalizationSourceName;
        }
    }
}