using System.Collections.Generic;

namespace Hoooten.PlatformMysql.MultiTenancy.Payments
{
    public interface IPaymentGatewayStore
    {
        List<PaymentGatewayModel> GetActiveGateways();
    }
}
