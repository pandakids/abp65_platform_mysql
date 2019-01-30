using System.Collections.Generic;
using Hoooten.PlatformMysql.Editions;
using Hoooten.PlatformMysql.Editions.Dto;
using Hoooten.PlatformMysql.MultiTenancy.Payments;
using Hoooten.PlatformMysql.MultiTenancy.Payments.Dto;

namespace Hoooten.PlatformMysql.Web.Models.Payment
{
    public class BuyEditionViewModel
    {
        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public decimal? AdditionalPrice { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}
