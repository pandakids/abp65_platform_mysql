using System.Threading.Tasks;
using Hoooten.PlatformMysql.ApiClient.Models;

namespace Hoooten.PlatformMysql.ApiClient
{
    public interface IAccessTokenManager
    {
        Task<string> GetAccessTokenAsync();
         
        Task<AbpAuthenticateResultModel> LoginAsync();

        void Logout();

        bool IsUserLoggedIn { get; }
    }
}