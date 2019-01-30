using System.Collections.Generic;
using Hoooten.PlatformMysql.Editions.Dto;
using Hoooten.PlatformMysql.MultiTenancy.Payments;

namespace Hoooten.PlatformMysql.Web.Models.Payment
{
    public class ExtendEditionViewModel
    {
        public EditionSelectDto Edition { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}