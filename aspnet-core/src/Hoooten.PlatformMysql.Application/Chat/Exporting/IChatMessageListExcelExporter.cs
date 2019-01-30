using System.Collections.Generic;
using Hoooten.PlatformMysql.Chat.Dto;
using Hoooten.PlatformMysql.Dto;

namespace Hoooten.PlatformMysql.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(List<ChatMessageExportDto> messages);
    }
}
