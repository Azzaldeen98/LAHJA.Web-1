using Domain.ShareData.Base;
using Shared.Interfaces;

namespace LAHJA.Data.UI.Models.Subscription
{
    public partial class SubscriptionViewModel : ITVM
    {
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public string? PlanId { get; set; }
        public long? Nr { get; set; }
        public string? CustomerId { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public string? Status { get; set; }
        public string? BillingPeriod { get; set; }
        public DateTimeOffset? CancelAt { get; set; }
        public bool? CancelAtPeriodEnd { get; set; }
    }
}
