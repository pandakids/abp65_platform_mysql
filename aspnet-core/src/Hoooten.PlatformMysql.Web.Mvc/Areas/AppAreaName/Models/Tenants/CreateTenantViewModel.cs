using System.Collections.Generic;
using Hoooten.PlatformMysql.Editions.Dto;
using Hoooten.PlatformMysql.Security;

namespace Hoooten.PlatformMysql.Web.Areas.AppAreaName.Models.Tenants
{
    public class CreateTenantViewModel
    {
        public IReadOnlyList<SubscribableEditionComboboxItemDto> EditionItems { get; set; }

        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public CreateTenantViewModel(IReadOnlyList<SubscribableEditionComboboxItemDto> editionItems)
        {
            EditionItems = editionItems;
        }
    }
}