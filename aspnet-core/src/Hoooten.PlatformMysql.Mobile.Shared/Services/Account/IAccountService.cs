using System.Threading.Tasks;
using Hoooten.PlatformMysql.ApiClient.Models;

namespace Hoooten.PlatformMysql.Services.Account
{
    public interface IAccountService
    {
        AbpAuthenticateModel AbpAuthenticateModel { get; set; }
        AbpAuthenticateResultModel AuthenticateResultModel { get; set; }
        Task LoginUserAsync();
    }
}
