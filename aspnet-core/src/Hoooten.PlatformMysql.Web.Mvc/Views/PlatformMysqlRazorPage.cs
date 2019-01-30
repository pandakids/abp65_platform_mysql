using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Hoooten.PlatformMysql.UiCustomization;
using Hoooten.PlatformMysql.UiCustomization.Dto;

namespace Hoooten.PlatformMysql.Web.Views
{
    public abstract class PlatformMysqlRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        [RazorInject]
        public IUiThemeCustomizerFactory UiThemeCustomizerFactory { get; set; }

        protected PlatformMysqlRazorPage()
        {
            LocalizationSourceName = PlatformMysqlConsts.LocalizationSourceName;
        }

        public async Task<UiCustomizationSettingsDto> GetTheme()
        {
            var themeCustomizer = await UiThemeCustomizerFactory.GetCurrentUiCustomizer();
            var settings = await themeCustomizer.GetUiSettings();
            return settings;
        }
    }
}
