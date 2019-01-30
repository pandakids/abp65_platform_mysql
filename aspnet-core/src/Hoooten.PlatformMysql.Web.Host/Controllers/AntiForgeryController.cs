using Microsoft.AspNetCore.Antiforgery;

namespace Hoooten.PlatformMysql.Web.Controllers
{
    public class AntiForgeryController : PlatformMysqlControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
