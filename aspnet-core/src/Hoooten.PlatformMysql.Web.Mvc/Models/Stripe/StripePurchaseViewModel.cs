﻿using Hoooten.PlatformMysql.MultiTenancy.Payments.Stripe;

namespace Hoooten.PlatformMysql.Web.Models.Stripe
{
    public class StripePurchaseViewModel
    {
        public long PaymentId { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public bool IsRecurring { get; set; }

        public bool UpdateSubscription { get; set; }

        public StripePaymentGatewayConfiguration Configuration { get; set; }
    }
}
