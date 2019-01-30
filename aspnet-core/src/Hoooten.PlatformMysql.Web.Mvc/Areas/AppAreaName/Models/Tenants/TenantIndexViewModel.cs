using System.Collections.Generic;
using Hoooten.PlatformMysql.Editions.Dto;

namespace Hoooten.PlatformMysql.Web.Areas.AppAreaName.Models.Tenants
{
    public class TenantIndexViewModel
    {
        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }
    }
}