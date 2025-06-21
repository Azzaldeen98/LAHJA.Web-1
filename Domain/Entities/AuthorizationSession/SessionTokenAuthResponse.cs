using Domain.Entities.Space.Response;

namespace Domain.Entities.AuthorizationSession
{
    public class SessionTokenAuthResponse
    {
        public string Id { get; set; }
        //public string SpaceId { get; set; }        // معرف الـ Space
        public string SessionToken { get; set; }    // رمز الوصول (Access Token)
        public string Subscription { get; set; }   // نوع الاشتراك (مجاني/مدفوع)
        public string AuthorizationType { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public bool IsActive { get; set; }
        public string IpAddress { get; set; }
        public string DeviceInfo { get; set; }
        public string ServiceId { get; set; }
        public string ModelGatewayId { get; set; }

        public string ApiEndPoint { get; set; }    // بوابة API
        public bool Status { get; set; } // الحالة (فعال / غير فعال)
        public ICollection<SpaceResponse> Spaces { get; set; }
    }




}
