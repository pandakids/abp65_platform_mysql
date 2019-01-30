using System.Collections.Generic;
using Abp.Localization;
using Hoooten.PlatformMysql.Install.Dto;

namespace Hoooten.PlatformMysql.Web.Models.Install
{
    public class InstallViewModel
    {
        public List<ApplicationLanguage> Languages { get; set; }

        public AppSettingsJsonDto AppSettingsJson { get; set; }
    }
}
