using Abp.Application.Services;
using Hoooten.PlatformMysql.Dto;
using Hoooten.PlatformMysql.Logging.Dto;

namespace Hoooten.PlatformMysql.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
