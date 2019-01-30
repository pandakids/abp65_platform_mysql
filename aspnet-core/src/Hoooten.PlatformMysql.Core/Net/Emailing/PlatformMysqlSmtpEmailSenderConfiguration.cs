using Abp.Configuration;
using Abp.Net.Mail;
using Abp.Net.Mail.Smtp;
using Abp.Runtime.Security;

namespace Hoooten.PlatformMysql.Net.Emailing
{
    public class PlatformMysqlSmtpEmailSenderConfiguration : SmtpEmailSenderConfiguration
    {
        public PlatformMysqlSmtpEmailSenderConfiguration(ISettingManager settingManager) : base(settingManager)
        {

        }

        public override string Password => SimpleStringCipher.Instance.Decrypt(GetNotEmptySettingValue(EmailSettingNames.Smtp.Password));
    }
}