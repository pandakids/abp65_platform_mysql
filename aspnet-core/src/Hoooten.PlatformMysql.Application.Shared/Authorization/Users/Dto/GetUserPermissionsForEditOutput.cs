using System.Collections.Generic;
using Hoooten.PlatformMysql.Authorization.Permissions.Dto;

namespace Hoooten.PlatformMysql.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}