using Microsoft.AspNetCore.Mvc;
using Hoooten.PlatformMysql.Web.Controllers;

namespace Hoooten.PlatformMysql.Web.Public.Controllers
{
    public class AboutController : PlatformMysqlControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}