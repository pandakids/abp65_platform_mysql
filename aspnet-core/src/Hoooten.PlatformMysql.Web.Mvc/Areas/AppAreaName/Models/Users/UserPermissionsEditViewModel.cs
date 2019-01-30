using Abp.AutoMapper;
using Hoooten.PlatformMysql.Authorization.Users;
using Hoooten.PlatformMysql.Authorization.Users.Dto;
using Hoooten.PlatformMysql.Web.Areas.AppAreaName.Models.Common;

namespace Hoooten.PlatformMysql.Web.Areas.AppAreaName.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; private set; }

        public UserPermissionsEditViewModel(GetUserPermissionsForEditOutput output, User user)
        {
            User = user;
            output.MapTo(this);
        }
    }
}