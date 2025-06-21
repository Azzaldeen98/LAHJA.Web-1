namespace LAHJA.Data.UI.Models.Profile
{
    public class DataBuildUserSubscriptionInfoVM
    {
        public string Id { get; set; }

        public string? PlanId { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public string Status { get; set; }
        public bool CancelAtPeriodEnd { get; set; }
        public string ProductName { get; set; }
        public int NumberRequests { get; set; }
        public decimal Amount { get; set; }

        public bool Active
        {
            get => Status.ToLower() == "active"; set
            {
                Status = value ? "Active" : "UnActive";
            }
        }
        public string Description { get; set; } = "";
    }



}
