using Abp;
using Abp.Domain.Repositories;
using Abp.Net.Sms;
using Abp.UI;
using Aliyun.Acs.Core.Exceptions;
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
        private readonly IRepository<User, long> _userRepository;

        public SmsMessageService(ISmsSender smsSender,
            IRepository<User, long> userRepository)
        {
            _smsSender = smsSender;
            _userRepository = userRepository;
        }

        public void Send(string to, string templateCode, string templateParams)
        {
            _smsSender.Send(to, templateCode, templateParams);
        }

        public async Task SendAsync(string to, string templateCode, string templateParams)
        {
            await _smsSender.SendAsync(to, templateCode, templateParams);
        }

        /// <summary>
        /// 短信登录
        /// </summary>
        /// <param name="to"></param>
        public void SmsLogin(string to)
        {
            try
            {
                if (string.IsNullOrEmpty(to)) {
                    throw new UserFriendlyException("手机号不能为空",
                    new Exception(string.Format("error:{0}", "手机号不能为空")));
                }

                var templateCode = "SMS_150737271";
                var randomCode = RandomHelper.GetRandom(1000, 9999);
                var code = randomCode.ToString();

                //将验证码写入User表
                var user = _userRepository.GetAll().Where(e => e.PhoneNumber == to).FirstOrDefault();
                user.Captcha = randomCode;

                if (user != null)
                {
                    var templateParams = "{\"code\":\"" + code + "\"}";
                    _smsSender.Send(to, templateCode, templateParams);
                }
                else {
                    throw new UserFriendlyException("用户未注册",
                    new Exception(string.Format("error:{0}", "用户未注册")));
                }
            }
            catch (ServerException e)
            {
                throw new UserFriendlyException("短信发送失败",
                    new Exception(string.Format("to:{0},errCode:{1},errMsg:{2}",
                        to,
                        e.ErrorCode,
                        e.Message)));
            }
            catch (ClientException e)
            {
                throw new UserFriendlyException("短信发送失败",
                    new Exception(string.Format("to:{0},errCode:{1},errMsg:{2}",
                        to,
                        e.ErrorCode,
                        e.Message)));
            }
        }
    }
}
