using System.Threading.Tasks;
using Hoooten.PlatformMysql.Sessions.Dto;

namespace Hoooten.PlatformMysql.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
