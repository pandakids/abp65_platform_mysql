using Abp.Domain.Services;

namespace Hoooten.PlatformMysql
{
    public abstract class PlatformMysqlDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected PlatformMysqlDomainServiceBase()
        {
            LocalizationSourceName = PlatformMysqlConsts.LocalizationSourceName;
        }
    }
}
