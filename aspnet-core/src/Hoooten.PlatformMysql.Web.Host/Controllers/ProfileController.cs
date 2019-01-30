using Abp.AspNetCore.Mvc.Authorization;
using Hoooten.PlatformMysql.Storage;

namespace Hoooten.PlatformMysql.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ProfileController : ProfileControllerBase
    {
        public ProfileController(ITempFileCacheManager tempFileCacheManager) :
            base(tempFileCacheManager)
        {
        }
    }
}