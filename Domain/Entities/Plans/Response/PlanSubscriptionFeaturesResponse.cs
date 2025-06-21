using Domain.ShareData.Base;

namespace Domain.Entities.Plans.Response
{
    public class PlanSubscriptionFeaturesResponse : BaseSubscriptionFeatures
    {
        public string? Status { get; set; } = "Active";
        public string? Name { get; set; }
        public string? Description { get; set; }


    }

}
