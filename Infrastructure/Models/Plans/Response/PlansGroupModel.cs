using Infrastructure.Models.Plans.Response;

namespace Infrastructure.Models.Plans
{


    public class PlansGroupModel
    {
        public string? Id { get; set; }
        //public string? ContainerId { get; set; }
        public string? ProductName { get; set; } = "";
        public bool? Active { get; set; } = true;
        public List<PlanSubscriptionFeaturesModel>? SubscriptionFeatures { get; set; }
        public List<PlanTechnicalFeaturesModel>?  TechnicalFeatures { get; set; }
    }





}
