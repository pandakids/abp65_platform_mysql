using System.Threading.Tasks;
using Hoooten.PlatformMysql.Security.Recaptcha;

namespace Hoooten.PlatformMysql.Tests.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
