using System.Collections.Generic;
using Hoooten.PlatformMysql.Authorization.Users.Dto;

namespace Hoooten.PlatformMysql.Web.Areas.AppAreaName.Models.Users
{
    public class UserLoginAttemptModalViewModel
    {
        public List<UserLoginAttemptDto> LoginAttempts { get; set; }
    }
}