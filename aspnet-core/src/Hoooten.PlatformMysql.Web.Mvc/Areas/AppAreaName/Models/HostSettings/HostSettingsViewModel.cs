using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Hoooten.PlatformMysql.Configuration.Host.Dto;
using Hoooten.PlatformMysql.Editions.Dto;

namespace Hoooten.PlatformMysql.Web.Areas.AppAreaName.Models.HostSettings
{
    public class HostSettingsViewModel
    {
        public HostSettingsEditDto Settings { get; set; }

        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }

        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}