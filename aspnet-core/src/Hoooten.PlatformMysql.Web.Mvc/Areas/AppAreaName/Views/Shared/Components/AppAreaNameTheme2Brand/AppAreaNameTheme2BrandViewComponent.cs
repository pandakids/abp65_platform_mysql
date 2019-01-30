using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hoooten.PlatformMysql.Web.Areas.AppAreaName.Models.Layout;
using Hoooten.PlatformMysql.Web.Session;
using Hoooten.PlatformMysql.Web.Views;

namespace Hoooten.PlatformMysql.Web.Areas.AppAreaName.Views.Shared.Components.AppAreaNameTheme2Brand
{
    public class AppAreaNameTheme2BrandViewComponent : PlatformMysqlViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppAreaNameTheme2BrandViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var headerModel = new HeaderViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(headerModel);
        }
    }
}
