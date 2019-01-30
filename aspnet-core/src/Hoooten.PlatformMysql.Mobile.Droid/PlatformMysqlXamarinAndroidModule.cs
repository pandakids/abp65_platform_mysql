using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Hoooten.PlatformMysql
{
    [DependsOn(typeof(PlatformMysqlXamarinSharedModule))]
    public class PlatformMysqlXamarinAndroidModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PlatformMysqlXamarinAndroidModule).GetAssembly());
        }
    }
}