using Domain.ShareData.Base;

namespace Infrastructure.Models.Plans
{
    public class PlanTechnicalFeaturesModel : BaseQuantitativeFeature
    {
        public string? Status { get; set; } = "NoActive";
    }


}
