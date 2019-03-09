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


        public void SmsLogin(string to)
        {
            var templateCode = "SMS_150737271";
            var code = GenCode();

            //将验证码写入User表
            var templateParams = "{\"code\":\""+ code + "\"}";
            _smsSender.Send(to, templateCode, templateParams);
        }

        private string GenCode()
        {
            string vc = "";
            Random rNum = new Random();//随机生成类
            int num1 = rNum.Next(0, 9);//返回指定范围内的随机数
            int num2 = rNum.Next(0, 9);
            int num3 = rNum.Next(0, 9);
            int num4 = rNum.Next(0, 9);

            int[] nums = new int[4] { num1, num2, num3, num4 };
            for (int i = 0; i < nums.Length; i++)//循环添加四个随机生成数
            {
                vc += nums[i].ToString();
            }
            return vc;
        }
    }
}
