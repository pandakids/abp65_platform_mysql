using System.Collections.Generic;
using Hoooten.PlatformMysql.Authorization.Users.Dto;
using Hoooten.PlatformMysql.Dto;

namespace Hoooten.PlatformMysql.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}