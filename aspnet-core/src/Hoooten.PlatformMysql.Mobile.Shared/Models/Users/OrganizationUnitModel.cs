using Abp.AutoMapper;
using Hoooten.PlatformMysql.Organizations.Dto;

namespace Hoooten.PlatformMysql.Models.Users
{
    [AutoMapFrom(typeof(OrganizationUnitDto))]
    public class OrganizationUnitModel : OrganizationUnitDto
    {
        public bool IsAssigned { get; set; }
    }
}