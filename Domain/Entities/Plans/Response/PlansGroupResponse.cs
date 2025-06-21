namespace Domain.Entities.Plans.Response
{
    public class PlansGroupResponse
    {

        public string? Id { get; set; }
        //public string? ContainerId { get; set; }
        public string? Description { get; set; }
        public string? ProductName { get; set; }
        public bool? Active { get; set; } = true;
        public List<PlanSubscriptionFeaturesResponse>? SubscriptionFeatures { get; set; }
        public List<PlanTechnicalFeaturesResponse>? TechnicalFeatures { get; set; }
    }



}
