using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace Hoooten.PlatformMysql.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
