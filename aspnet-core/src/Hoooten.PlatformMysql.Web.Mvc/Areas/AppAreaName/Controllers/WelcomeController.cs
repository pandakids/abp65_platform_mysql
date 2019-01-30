using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hoooten.PlatformMysql.Web.Controllers;

namespace Hoooten.PlatformMysql.Web.Areas.AppAreaName.Controllers
{
    [Area("AppAreaName")]
    [AbpMvcAuthorize]
    public class WelcomeController : PlatformMysqlControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}