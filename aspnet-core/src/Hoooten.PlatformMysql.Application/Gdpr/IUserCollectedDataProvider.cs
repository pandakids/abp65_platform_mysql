using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Hoooten.PlatformMysql.Dto;

namespace Hoooten.PlatformMysql.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
