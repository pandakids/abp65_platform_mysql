using Abp.Application.Navigation;

namespace Hoooten.PlatformMysql.Web.Areas.AppAreaName.Models.Layout
{
    public class MenuViewModel
    {
        public UserMenu Menu { get; set; }

        public string CurrentPageName { get; set; }
    }
}