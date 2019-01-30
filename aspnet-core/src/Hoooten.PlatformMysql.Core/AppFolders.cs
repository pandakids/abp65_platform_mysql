using Abp.Dependency;

namespace Hoooten.PlatformMysql
{
    public class AppFolders : IAppFolders, ISingletonDependency
    {
        public string SampleProfileImagesFolder { get; set; }

        public string WebLogsFolder { get; set; }
    }
}