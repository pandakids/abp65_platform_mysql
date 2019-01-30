using Microsoft.AspNetCore.Mvc;
using Hoooten.PlatformMysql.Web.Controllers;

namespace Hoooten.PlatformMysql.Web.Public.Controllers
{
    public class HomeController : PlatformMysqlControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}