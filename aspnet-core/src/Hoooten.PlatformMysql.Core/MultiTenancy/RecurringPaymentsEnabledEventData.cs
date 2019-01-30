using Abp.Events.Bus;

namespace Hoooten.PlatformMysql.MultiTenancy
{
    public class RecurringPaymentsEnabledEventData : EventData
    {
        public int TenantId { get; set; }
    }
}