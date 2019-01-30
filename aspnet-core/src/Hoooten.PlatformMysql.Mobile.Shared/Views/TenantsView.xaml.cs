using Hoooten.PlatformMysql.Models.Tenants;
using Hoooten.PlatformMysql.ViewModels;
using Xamarin.Forms;

namespace Hoooten.PlatformMysql.Views
{
    public partial class TenantsView : ContentPage, IXamarinView
    {
        public TenantsView()
        {
            InitializeComponent();
        }

        private async void ListView_OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            await ((TenantsViewModel)BindingContext).LoadMoreTenantsIfNeedsAsync(e.Item as TenantListModel);
        }
    }
}