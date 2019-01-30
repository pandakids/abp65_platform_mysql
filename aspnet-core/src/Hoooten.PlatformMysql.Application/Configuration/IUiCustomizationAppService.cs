using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Hoooten.PlatformMysql.Configuration.Dto;

namespace Hoooten.PlatformMysql.Configuration
{
    public interface IUiCustomizationSettingsAppService : IApplicationService
    {
        Task<List<ThemeSettingsDto>> GetUiManagementSettings();

        Task UpdateUiManagementSettings(ThemeSettingsDto settings);

        Task UpdateDefaultUiManagementSettings(ThemeSettingsDto settings);

        Task UseSystemDefaultSettings();
    }
}
