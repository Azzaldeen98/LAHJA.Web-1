using LAHJA.Data.UI.Models.Space;

namespace LAHJA.Data.UI.Models.SessionTokenAuth
{
    public class SessionTokenAuth
    {
        public string Id { get; set; }
        //public string SpaceId { get; set; }        // معرف الـ Space
        public string Subscription { get; set; }   // نوع الاشتراك (مجاني/مدفوع)
        public string SessionToken { get; set; }    // رمز الوصول (Access Token)
        public string ApiEndPoint { get; set; }    // بوابة API
        public bool Status { get; set; } // الحالة (فعال / غير فعال)
        public string AuthorizationType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public string IpAddress { get; set; }
        public string DeviceInfo { get; set; }
        public string ServiceId { get; set; }
        public string ModelGatewayId { get; set; }

        public ICollection<DataBuildSpace> Spaces { get; set; }         
    }



}
