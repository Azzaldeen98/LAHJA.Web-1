using Domain.ShareData.Base;

namespace Domain.Entities.Plans.Response
{
    public class PlanTechnicalServiceResponse : BaseFeature
    {
        public string? Status { get; set; } = "Active";

        public List<PlanTechnicalServiceFeatureResponse>? TechnicalServiceFeatures { get; set; }
     

    }

    



}
