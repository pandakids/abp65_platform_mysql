using System.Threading.Tasks;
using Abp.Application.Services;
using Hoooten.PlatformMysql.MultiTenancy.Payments.Dto;
using Hoooten.PlatformMysql.MultiTenancy.Payments.PayPal.Dto;

namespace Hoooten.PlatformMysql.MultiTenancy.Payments.PayPal
{
    public interface IPayPalPaymentAppService : IApplicationService
    {
        Task ConfirmPayment(long paymentId, string paypalPaymentId, string paypalPayerId);

        PayPalConfigurationDto GetConfiguration();

        Task CancelPayment(CancelPaymentDto input);
    }
}
