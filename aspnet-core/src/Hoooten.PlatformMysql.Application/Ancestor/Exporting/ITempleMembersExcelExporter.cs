using System.Collections.Generic;
using Hoooten.PlatformMysql.Ancestor.Dtos;
using Hoooten.PlatformMysql.Dto;

namespace Hoooten.PlatformMysql.Ancestor.Exporting
{
    public interface ITempleMembersExcelExporter
    {
        FileDto ExportToFile(List<GetTempleMemberForView> templeMembers);
    }
}