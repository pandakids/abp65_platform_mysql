using Hoooten.PlatformMysql.Editions;
using Hoooten.PlatformMysql.Editions.Dto;
using Hoooten.PlatformMysql.MultiTenancy.Payments;
using Hoooten.PlatformMysql.Security;
using Hoooten.PlatformMysql.MultiTenancy.Payments.Dto;

namespace Hoooten.PlatformMysql.Web.Models.TenantRegistration
{
    public class TenantRegisterViewModel
    {
        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public int? EditionId { get; set; }

        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }
    }
}
