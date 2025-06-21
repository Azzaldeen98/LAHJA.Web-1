namespace Domain.ShareData.Base.Request
{
    public partial class RequestAllowedBase
    {

        public long NumberRequests { get; set; }

        public long CurrentNumberRequests { get; set; }

        public bool Allowed { get; set; }

    }




}
