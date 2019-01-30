using Abp.AutoMapper;
using Hoooten.PlatformMysql.Editions;
using Hoooten.PlatformMysql.MultiTenancy.Payments.Dto;

namespace Hoooten.PlatformMysql.Web.Areas.AppAreaName.Models.SubscriptionManagement
{
    [AutoMapTo(typeof(ExecutePaymentDto))]
    public class PaymentResultViewModel : SubscriptionPaymentDto
    {
        public EditionPaymentType EditionPaymentType { get; set; }
    }
}