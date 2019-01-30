using System.Threading.Tasks;

namespace Hoooten.PlatformMysql.Identity
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}