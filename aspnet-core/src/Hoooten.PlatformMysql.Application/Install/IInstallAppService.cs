using System.Threading.Tasks;
using Abp.Application.Services;
using Hoooten.PlatformMysql.Install.Dto;

namespace Hoooten.PlatformMysql.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}