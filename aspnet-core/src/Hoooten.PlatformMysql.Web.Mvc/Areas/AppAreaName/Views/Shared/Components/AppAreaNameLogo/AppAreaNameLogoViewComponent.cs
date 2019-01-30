﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hoooten.PlatformMysql.Web.Areas.AppAreaName.Models.Layout;
using Hoooten.PlatformMysql.Web.Session;
using Hoooten.PlatformMysql.Web.Views;

namespace Hoooten.PlatformMysql.Web.Areas.AppAreaName.Views.Shared.Components.AppAreaNameTenantLogo
{
    public class AppAreaNameLogoViewComponent : PlatformMysqlViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;
        
        public AppAreaNameLogoViewComponent(
            IPerRequestSessionCache sessionCache
        )
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync(string logoSkin = null)
        {
            var headerModel = new LogoViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync(),
                LogoSkinOverride = logoSkin
            };
            
            return View(headerModel);
        }
    }
}
