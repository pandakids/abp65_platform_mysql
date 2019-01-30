using Hoooten.PlatformMysql.Editions.Dto;

namespace Hoooten.PlatformMysql.MultiTenancy.Payments.Dto
{
    public class PaymentInfoDto
    {
        public EditionSelectDto Edition { get; set; }

        public decimal AdditionalPrice { get; set; }
    }
}
