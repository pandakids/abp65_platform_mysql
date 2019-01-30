using System.Reflection;
using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Hoooten.PlatformMysql.Localization
{
    public static class PlatformMysqlLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    PlatformMysqlConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(PlatformMysqlLocalizationConfigurer).GetAssembly(),
                        "Hoooten.PlatformMysql.Localization.PlatformMysql"
                    )
                )
            );
        }
    }
}