namespace Domain.ShareData.Base
{


    //public class BasePricingFeature : BaseFeature
    //{
    //    public decimal Price { get; set; }

    //}
    //public class QuantitativeFeature : BaseQuantitativeFeature
    //{


    //}


    public class BasePlanFeature : BaseQuantitativeFeature
    {

        public string? BillingPeriod { get; set; }
        public decimal? TotalBilling { get; set; } = 0;
        public decimal TotalAmount { get; set; } = 0;
        public string? Token { get; set; }
        public string? Processor { get; set; }
        public string? ConnectionType { get; set; }
        public string? AbsolutePath { get; set; }
        public int? NumberRequests { get; set; }
        public int? NumberOfRequestsUsed { get; set; } = 0;
        public string? Image { get; set; }
        public List<string>? Images { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }

    }

}
