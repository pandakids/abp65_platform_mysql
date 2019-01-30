using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Hoooten.PlatformMysql.Authorization;

namespace Hoooten.PlatformMysql
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(PlatformMysqlCoreModule)
        )]
    public class PlatformMysqlApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PlatformMysqlApplicationModule).GetAssembly());
        }
    }
}