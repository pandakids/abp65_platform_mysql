using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoooten.PlatformMysql.Web.Models.TokenAuth
{
    public class AuthenticateByPhoneCaptchaModel
    {
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public int Captcha { get; set; }
    }
}
