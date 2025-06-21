using Microsoft.AspNetCore.SignalR;

namespace LAHJA.Notification
{
    public class NotificationHub : Hub
    {
        private readonly UserContextService _userContext;


        public NotificationHub(UserContextService userContext)
        {
            _userContext = userContext;

        }

        public override Task OnConnectedAsync()
        {
            var HttpContext = Context.GetHttpContext();
            var token = HttpContext?.Request.Query["access_token"].ToString();
            if (!string.IsNullOrEmpty(token))
            {
                _userContext.AddUser(token, Context.ConnectionId);


            }
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var HttpContext = Context.GetHttpContext();
            var token = HttpContext?.Request.Query["access_token"].ToString();
            if (!string.IsNullOrEmpty(token))
            {
                _userContext.RemoveUser(token);
            }
            return base.OnDisconnectedAsync(exception);

        }
    }

}
