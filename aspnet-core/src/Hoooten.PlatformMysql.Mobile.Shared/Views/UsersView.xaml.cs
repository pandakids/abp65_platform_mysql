using Hoooten.PlatformMysql.Models.Users;
using Hoooten.PlatformMysql.ViewModels;
using Xamarin.Forms;

namespace Hoooten.PlatformMysql.Views
{
    public partial class UsersView : ContentPage, IXamarinView
    {
        public UsersView()
        {
            InitializeComponent();
        }

        public async void ListView_OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            await ((UsersViewModel) BindingContext).LoadMoreUserIfNeedsAsync(e.Item as UserListModel);
        }
    }
}