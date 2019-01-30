using System.Threading.Tasks;
using Hoooten.PlatformMysql.Views;
using Xamarin.Forms;

namespace Hoooten.PlatformMysql.Services.Modal
{
    public interface IModalService
    {
        Task ShowModalAsync(Page page);

        Task ShowModalAsync<TView>(object navigationParameter) where TView : IXamarinView;

        Task<Page> CloseModalAsync();
    }
}
