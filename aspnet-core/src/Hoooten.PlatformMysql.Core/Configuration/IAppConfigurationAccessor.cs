using Microsoft.Extensions.Configuration;

namespace Hoooten.PlatformMysql.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
