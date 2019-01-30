using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Hoooten.PlatformMysql
{
    public class PlatformMysqlClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PlatformMysqlClientModule).GetAssembly());
        }
    }
}
