using System.Collections.Generic;
using MvvmHelpers;
using Hoooten.PlatformMysql.Models.NavigationMenu;

namespace Hoooten.PlatformMysql.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}