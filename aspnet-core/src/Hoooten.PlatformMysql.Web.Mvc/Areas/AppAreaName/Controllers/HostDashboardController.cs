using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hoooten.PlatformMysql.Authorization;
using Hoooten.PlatformMysql.Web.Areas.AppAreaName.Models.HostDashboard;
using Hoooten.PlatformMysql.Web.Controllers;

namespace Hoooten.PlatformMysql.Web.Areas.AppAreaName.Controllers
{
    [Area("AppAreaName")]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Host_Dashboard)]
    public class HostDashboardController : PlatformMysqlControllerBase
    {
        private const int DashboardOnLoadReportDayCount = 7;

        public ActionResult Index()
        {
            return View(new HostDashboardViewModel(DashboardOnLoadReportDayCount));
        }
    }
}