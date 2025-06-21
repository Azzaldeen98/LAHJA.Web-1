using Domain.Entities.Plans.Response;


namespace Infrastructure.Models.Plans.Response
{
    public class PlanCreateModel
    {
        public string PriceId { get; set; }
        public IEnumerable<PlanServicesCreateModel> PlanServices { get; set; }
    }

}
