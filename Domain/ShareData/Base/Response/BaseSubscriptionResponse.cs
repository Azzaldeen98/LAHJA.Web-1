namespace Domain.ShareData.Base.Response
{
    public partial class BaseSubscriptionResponse
    {
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public string? PlanId { get; set; }
        public string? CustomerId { get; set; }
        public string? BillingPeriod { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public string? Status { get; set; }
        public bool? CancelAtPeriodEnd { get; set; }

    }
}
