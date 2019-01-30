using Abp.Notifications;
using Hoooten.PlatformMysql.Dto;

namespace Hoooten.PlatformMysql.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }
    }
}