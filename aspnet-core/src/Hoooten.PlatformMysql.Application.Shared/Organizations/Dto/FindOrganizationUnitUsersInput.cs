using Hoooten.PlatformMysql.Dto;

namespace Hoooten.PlatformMysql.Organizations.Dto
{
    public class FindOrganizationUnitUsersInput : PagedAndFilteredInputDto
    {
        public long OrganizationUnitId { get; set; }
    }
}
