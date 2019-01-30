using System.Collections.Generic;
using Hoooten.PlatformMysql.Auditing.Dto;
using Hoooten.PlatformMysql.Dto;

namespace Hoooten.PlatformMysql.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
