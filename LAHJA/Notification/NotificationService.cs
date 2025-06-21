using Microsoft.AspNetCore.SignalR;

namespace LAHJA.Notification
{
    public class NotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly UserContextService _userContext;

        public NotificationService(IHubContext<NotificationHub> hubContext, UserContextService userContext)
        {
            _hubContext = hubContext;
            _userContext = userContext;
        }
        public async Task NotifyClients(string message)
        {

            await _hubContext.Clients.All.SendAsync("ReceiveNotification", message);
        }

        // إرسال إشعار لمستخدم معين بناءً على معرفه
        public async Task SendAlertToUser(string userId, string message)
        {
            var connectionId = _userContext.GetConnectionId(userId);
            if (connectionId != null)
            {
                await _hubContext.Clients.Client(connectionId).SendAsync("ReceiveNotification", message);
            }
        }
    }

}
