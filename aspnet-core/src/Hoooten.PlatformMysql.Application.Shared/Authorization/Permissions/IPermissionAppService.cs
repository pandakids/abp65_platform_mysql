using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hoooten.PlatformMysql.Authorization.Permissions.Dto;

namespace Hoooten.PlatformMysql.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
