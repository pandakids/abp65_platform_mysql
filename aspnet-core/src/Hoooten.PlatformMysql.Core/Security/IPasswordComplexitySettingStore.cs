using System.Threading.Tasks;

namespace Hoooten.PlatformMysql.Security
{
    public interface IPasswordComplexitySettingStore
    {
        Task<PasswordComplexitySetting> GetSettingsAsync();
    }
}
