using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hoooten.PlatformMysql.Web.Areas.AppAreaName.Models.Layout;
using Hoooten.PlatformMysql.Web.Session;
using Hoooten.PlatformMysql.Web.Views;

namespace Hoooten.PlatformMysql.Web.Areas.AppAreaName.Views.Shared.Components.AppAreaNameFooter
{
    public class AppAreaNameFooterViewComponent : PlatformMysqlViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppAreaNameFooterViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerModel = new FooterViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(footerModel);
        }
    }
}
