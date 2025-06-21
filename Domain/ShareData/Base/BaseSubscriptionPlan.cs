namespace Domain.ShareData.Base
{
    public class BaseSubscriptionPlan : BasePlanFeature
    {

      

        public string? ContainerId { get; set; }
      
        /// <summary>
        /// //////////////////////////////////////////////////////
        /// </summary>
        public decimal? MonthlyPrice { get; set; }
        public decimal? AnnualPrice { get; set; }
        public decimal? WeeklyPrice { get; set; }

        //public BaseContainerPlans? ContainerPlan { get; set; }

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
