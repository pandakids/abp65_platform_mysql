using Xamarin.Forms;

namespace Hoooten.PlatformMysql.Views
{
    public partial class MainView : MasterDetailPage, IXamarinView
    {
        public MainView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
