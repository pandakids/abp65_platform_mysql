using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Net.Sms;
using Abp.UI;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using Castle.Core.Logging;

namespace Hoooten.PlatformMysql.Net.Sms
{
    public class AliDayuSmsSender : SmsSenderBase, ITransientDependency
    {
        private IClientProfile profile = null;
        public ILogger Logger { get; set; }
        public AliDayuSmsSender(ISmsSenderConfiguration configuration) : base(configuration)
        {
            Logger = NullLogger.Instance;
            profile = DefaultProfile.GetProfile("cn-hangzhou", configuration.GetAppKey(), configuration.GetAppSecret());
        }

        protected override void SendSms(SmsMessage sms)
        {

            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", "Dysmsapi", "dysmsapi.aliyuncs.com");
            IAcsClient acsClient = new DefaultAcsClient(profile);
            SendSmsRequest request = new SendSmsRequest();
            try
            {
                //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为1000个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式
                request.PhoneNumbers = sms.To;
                //必填:短信签名-可在短信控制台中找到
                request.SignName = sms.FreeSignName;
                //必填:短信模板-可在短信控制台中找到
                request.TemplateCode = string.IsNullOrEmpty(sms.TemplateCode)
                    ? _configuration.GetDefaultSmsTemplateCode()
                    : sms.TemplateCode;
                //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
                request.TemplateParam = sms.TemplateParams;
                //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
                //request.OutId = "yourOutId";
                //请求失败这里会抛ClientException异常
                SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(request);
                Logger.Info("发送返回：" + sendSmsResponse.Message);
            }
            catch (ServerException e)
            {
                throw new UserFriendlyException("短信发送失败",
                    new Exception(string.Format("to:{0},errCode:{1},errMsg:{2}",
                        sms.To,
                        e.ErrorCode,
                        e.Message)));
            }
            catch (ClientException e)
            {
                throw new UserFriendlyException("短信发送失败",
                    new Exception(string.Format("to:{0},errCode:{1},errMsg:{2}",
                        sms.To,
                        e.ErrorCode,
                        e.Message)));
            }

        }

        protected override Task SendSmsAsync(SmsMessage sms)
        {
            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", "Dysmsapi", "dysmsapi.aliyuncs.com");
            var task = new Task(() =>
            {
                IAcsClient acsClient = new DefaultAcsClient(profile);
                SendSmsRequest request = new SendSmsRequest();
                try
                {
                    //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为1000个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式
                    request.PhoneNumbers = sms.To;
                    //必填:短信签名-可在短信控制台中找到
                    request.SignName = sms.FreeSignName;
                    //必填:短信模板-可在短信控制台中找到
                    request.TemplateCode = string.IsNullOrEmpty(sms.TemplateCode)
                        ? _configuration.GetDefaultSmsTemplateCode()
                        : sms.TemplateCode;
                    //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
                    request.TemplateParam = sms.TemplateParams;
                    //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
                    //request.OutId = "yourOutId";
                    //请求失败这里会抛ClientException异常
                    SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(request);
                    Logger.Info("发送返回：" + sendSmsResponse.Message);
                }
                catch (ServerException e)
                {
                    throw new UserFriendlyException("短信发送失败",
                        new Exception(string.Format("to:{0},errCode:{1},errMsg:{2}",
                            sms.To,
                            e.ErrorCode,
                            e.Message)));
                }
                catch (ClientException e)
                {
                    throw new UserFriendlyException("短信发送失败",
                        new Exception(string.Format("to:{0},errCode:{1},errMsg:{2}",
                            sms.To,
                            e.ErrorCode,
                            e.Message)));
                }
            });


            task.Start();
            return task;
        }
    }
}
