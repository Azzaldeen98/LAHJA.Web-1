using Domain.Entities.Service.Response;
using Domain.Entities.Subscriptions.Response;
using Domain.Entities.User;

namespace Domain.ShareData.Base.Request
{

    public partial class RequestResponseBase
    {
        public string? Id { get; set; }
        public string? Status { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public string? ModelGateway { get; set; }
        public string? ModelAi { get; set; }
        public string? Data { get; set; }
        public string? URL { get; set; }
        public string? Token { get; set; }
        public string? Method { get; set; }

        //public long NumberRequests { get; set; }
        //public long CurrentNumberRequests { get; set; }
        //public bool Allowed { get; set; }


        public UserResponse? User { get; set; }
        public SubscriptionResponse? Subscription { get; set; }
        public ServiceResponse? Service { get; set; }
        //public ICollection<EventRequestResponse>? Events { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }


}
