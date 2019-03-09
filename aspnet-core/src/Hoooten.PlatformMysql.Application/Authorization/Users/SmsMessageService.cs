using Abp.Net.Sms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoooten.PlatformMysql.Authorization.Users
{
    public class SmsMessageService : ISmsMessageService
    {
        private readonly ISmsSender _smsSender;

        public SmsMessageService(ISmsSender smsSender)
        {
            _smsSender = smsSender;
        }

        public void Send(string to, string templateCode, string templateParams)
        {
            _smsSender.Send(to, templateCode, templateParams);
        }

        public async Task SendAsync(string to, string templateCode, string templateParams)
        {
            await _smsSender.SendAsync(to, templateCode, templateParams);
        }
    }
}
