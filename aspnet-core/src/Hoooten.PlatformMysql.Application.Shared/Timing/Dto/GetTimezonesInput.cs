using Abp.Configuration;

namespace Hoooten.PlatformMysql.Timing.Dto
{
    public class GetTimezonesInput
    {
        public SettingScopes DefaultTimezoneScope { get; set; }
    }
}
