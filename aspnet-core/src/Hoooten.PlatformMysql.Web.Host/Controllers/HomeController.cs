using Abp.Auditing;
using Microsoft.AspNetCore.Mvc;

namespace Hoooten.PlatformMysql.Web.Controllers
{
    public class HomeController : PlatformMysqlControllerBase
    {
        [DisableAuditing]
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
