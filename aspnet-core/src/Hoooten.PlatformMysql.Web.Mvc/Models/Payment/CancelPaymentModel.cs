using Hoooten.PlatformMysql.MultiTenancy.Payments;

namespace Hoooten.PlatformMysql.Web.Models.Payment
{
    public class CancelPaymentModel
    {
        public string PaymentId { get; set; }

        public SubscriptionPaymentGatewayType Gateway { get; set; }
    }
}