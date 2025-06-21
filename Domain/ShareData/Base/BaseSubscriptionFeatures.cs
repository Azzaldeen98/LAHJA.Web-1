namespace Domain.ShareData.Base
{
    public class BaseSubscriptionFeatures
    {
        public string? Id { get; set; }
        public string? BillingPeriod { get; set; }
        public long? NumberRequests { get; set; }
        public double? Amount { get; set; }
        public bool? Active { get; set; }
    }


}
