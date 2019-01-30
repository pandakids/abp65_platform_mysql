using Abp.Dependency;
using Abp.Reflection.Extensions;
using Microsoft.Extensions.Configuration;
using Hoooten.PlatformMysql.Configuration;

namespace Hoooten.PlatformMysql.Tests.Configuration
{
    public class TestAppConfigurationAccessor : IAppConfigurationAccessor, ISingletonDependency
    {
        public IConfigurationRoot Configuration { get; }

        public TestAppConfigurationAccessor()
        {
            Configuration = AppConfigurations.Get(
                typeof(PlatformMysqlTestModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }
    }
}
