using System.Text.Json.Serialization;

namespace Domain.ShareData.Base
{
    //public class SubscriptionPlan : BasePlanFeature
    //{

    //    public string? Id { get; set; }
    //    public string Name { get; set; }
    //    public string? Description { get; set; }
    //    public bool Active { get; set; } = false;
    //    public decimal Price { get; set; } = 0;
    //    public bool? IsFixed { get; set; } = true;
    //    public bool? IsPaid { get; set; }
    //    public int Quantity { get; set; } = 1;
    //    public string? BillingPeriod { get; set; }
    //    public decimal TotalAmount { get; set; } = 0;
    //    public string? ContainerId { get; set; }
    //    public decimal? TotalBilling { get; set; }

    //    public string Image { get; set; }

    //    /// <summary>
    //    /// //////////////////////////////////////////////////////
    //    /// </summary>
    //    public decimal? MonthlyPrice { get; set; }
    //    public decimal? AnnualPrice { get; set; }
    //    public decimal? WeeklyPrice { get; set; }

    //    public ContainerPlans ContainerPlan { get; set; }
    //    public List<PlanFeature> Features { get; set; }

    //}

    public class  Service
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; } = false;
        public string? Image { get; set; }
        public decimal? Price { get; set; }
        public decimal? Amount { get; set; }
        public string Token { get; set; }
        public int NumberRequests { get; set; }
        public int NumberOfRequestsUsed { get; set; }

    }



    //public class BaseSubscriptionPlan
    //{
    //    public string? Id { get; set; }
    //    public string? GroupId { get; set; }
    //    public string Name { get; set; }
    //    public string? Description { get; set; }
    //    public bool Active { get; set; } = true;
    //    public decimal Price { get; set; } = 0;
    //    public decimal TotalAmount { get; set; } = 0;
    //    public string? BillingPeriod { get; set; }
    //    public decimal? TotalBilling { get; set; }
    //    public List<BasePlanFeature>? Features { get; set; }


    //}

    //public class BasePlanFeature2
    //{
    //public string? Id { get; set; }
    //public string Name { get; set; }
    //public string? Description { get; set; }
    //public bool Active { get; set; } = true;
    //public decimal Price { get; set; } = 0;
    //public bool? IsFixed { get; set; } = true;
    //public bool? IsPaid { get; set; }
    //public int Count { get; set; } = 1;
    //public int Quantity { get; set; } = 1;
    //public decimal TotalAmount { get; set; } = 0;


    //}





}
