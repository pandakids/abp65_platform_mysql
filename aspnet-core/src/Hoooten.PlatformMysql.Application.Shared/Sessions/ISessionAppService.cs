using System.Threading.Tasks;
using Abp.Application.Services;
using Hoooten.PlatformMysql.Sessions.Dto;

namespace Hoooten.PlatformMysql.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
