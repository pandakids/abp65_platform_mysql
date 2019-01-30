using Abp.Dependency;
using Hoooten.PlatformMysql.Configuration;
using Hoooten.PlatformMysql.Url;
using Hoooten.PlatformMysql.Web.Url;

namespace Hoooten.PlatformMysql.Web.Public.Url
{
    public class WebUrlService : WebUrlServiceBase, IWebUrlService, ITransientDependency
    {
        public WebUrlService(
            IAppConfigurationAccessor appConfigurationAccessor) :
            base(appConfigurationAccessor)
        {
        }

        public override string WebSiteRootAddressFormatKey => "App:WebSiteRootAddress";

        public override string ServerRootAddressFormatKey => "App:AdminWebSiteRootAddress";
    }
}