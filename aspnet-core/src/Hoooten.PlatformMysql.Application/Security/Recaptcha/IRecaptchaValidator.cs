using System.Threading.Tasks;

namespace Hoooten.PlatformMysql.Security.Recaptcha
{
    public interface IRecaptchaValidator
    {
        Task ValidateAsync(string captchaResponse);
    }
}