using System.Collections.Generic;
using Hoooten.PlatformMysql.Editions.Dto;
using Hoooten.PlatformMysql.MultiTenancy.Dto;

namespace Hoooten.PlatformMysql.Web.Areas.AppAreaName.Models.Tenants
{
    public class EditTenantViewModel
    {
        public TenantEditDto Tenant { get; set; }

        public IReadOnlyList<SubscribableEditionComboboxItemDto> EditionItems { get; set; }

        public EditTenantViewModel(TenantEditDto tenant, IReadOnlyList<SubscribableEditionComboboxItemDto> editionItems)
        {
            Tenant = tenant;
            EditionItems = editionItems;
        }
    }
}