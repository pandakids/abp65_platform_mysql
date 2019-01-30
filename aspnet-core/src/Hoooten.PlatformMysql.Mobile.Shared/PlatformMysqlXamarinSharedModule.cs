using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Hoooten.PlatformMysql
{
    [DependsOn(typeof(PlatformMysqlClientModule), typeof(AbpAutoMapperModule))]
    public class PlatformMysqlXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PlatformMysqlXamarinSharedModule).GetAssembly());
        }
    }
}