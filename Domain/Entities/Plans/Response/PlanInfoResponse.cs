namespace Domain.Entities.Plans.Response
{
    public class PlanInfoResponse
    {
        public string? Id { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public bool? Active { get; set; } = true;
        public decimal TotalPrice { get; set; } = 0;
        
        public List<PlanTechnicalServiceResponse>? TechnicalServices { get; set; }
        public List<PlanQuantitativeFeatureResponse>? QuantitativeFeatures { get; set; }
    }

    



}
