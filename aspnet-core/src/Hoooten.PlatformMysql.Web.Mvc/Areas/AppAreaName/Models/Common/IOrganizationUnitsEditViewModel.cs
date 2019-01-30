using System.Collections.Generic;
using Hoooten.PlatformMysql.Organizations.Dto;

namespace Hoooten.PlatformMysql.Web.Areas.AppAreaName.Models.Common
{
    public interface IOrganizationUnitsEditViewModel
    {
        List<OrganizationUnitDto> AllOrganizationUnits { get; set; }

        List<string> MemberedOrganizationUnits { get; set; }
    }
}