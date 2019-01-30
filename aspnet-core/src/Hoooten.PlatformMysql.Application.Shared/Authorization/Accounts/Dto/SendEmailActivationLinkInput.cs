using System.ComponentModel.DataAnnotations;

namespace Hoooten.PlatformMysql.Authorization.Accounts.Dto
{
    public class SendEmailActivationLinkInput
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}