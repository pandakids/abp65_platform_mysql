using System.Threading.Tasks;
using Abp.Application.Services;
using Hoooten.PlatformMysql.Configuration.Host.Dto;

namespace Hoooten.PlatformMysql.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
