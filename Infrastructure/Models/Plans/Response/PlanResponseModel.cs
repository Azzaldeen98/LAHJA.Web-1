namespace Infrastructure.Models.Plans
{

    public class PlanResponseModel 
    {
        public string? Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductId { get; set; }
        public string? BillingPeriod { get; set; }
        public long? NumberRequests { get; set; }
        public double? Amount { get; set; }
        public bool Active { get; set; } = false;

        public ICollection<PlanSubscriptionResponseModel>? Subscriptions { get; set; }


    }


}
