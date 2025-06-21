namespace Domain.Entities.Plans.Response
{
    public class PlanCreate
    {
        public string PriceId { get; set; }
        public IEnumerable<PlanServicesCreate> PlanServices { get; set; }
    }
}
