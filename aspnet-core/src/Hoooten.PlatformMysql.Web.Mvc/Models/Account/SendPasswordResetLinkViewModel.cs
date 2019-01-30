using System.ComponentModel.DataAnnotations;

namespace Hoooten.PlatformMysql.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}