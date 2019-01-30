using System.Collections.Generic;
using Hoooten.PlatformMysql.Authorization.Permissions.Dto;

namespace Hoooten.PlatformMysql.Web.Areas.AppAreaName.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}