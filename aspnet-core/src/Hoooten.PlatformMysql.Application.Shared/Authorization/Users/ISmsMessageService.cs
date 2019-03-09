using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hoooten.PlatformMysql.Authorization.Users
{
    public interface ISmsMessageService : IApplicationService
    {
        void Send(string to, string templateCode, string templateParams);
        Task SendAsync(string to, string templateCode, string templateParams);
    }
}
