using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Hoooten.PlatformMysql.Web.Public.Views
{
    public abstract class PlatformMysqlRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected PlatformMysqlRazorPage()
        {
            LocalizationSourceName = PlatformMysqlConsts.LocalizationSourceName;
        }
    }
}
