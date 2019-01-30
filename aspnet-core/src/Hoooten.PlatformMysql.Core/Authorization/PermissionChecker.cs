using Abp.Authorization;
using Hoooten.PlatformMysql.Authorization.Roles;
using Hoooten.PlatformMysql.Authorization.Users;

namespace Hoooten.PlatformMysql.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
