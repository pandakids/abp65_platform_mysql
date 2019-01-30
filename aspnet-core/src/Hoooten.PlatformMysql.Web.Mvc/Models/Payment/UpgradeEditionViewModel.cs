using System.Collections.Generic;
using Hoooten.PlatformMysql.Editions.Dto;
using Hoooten.PlatformMysql.MultiTenancy.Payments;

namespace Hoooten.PlatformMysql.Web.Models.Payment
{
    public class UpgradeEditionViewModel
    {
        public EditionSelectDto Edition { get; set; }

        public PaymentPeriodType PaymentPeriodType { get; set; }

        public SubscriptionPaymentType SubscriptionPaymentType { get; set; }

        public decimal? AdditionalPrice { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}