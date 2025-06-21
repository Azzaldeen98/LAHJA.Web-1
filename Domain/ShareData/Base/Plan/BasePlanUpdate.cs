namespace Domain.ShareData.Base.Plan
{
    public partial class BasePlanUpdate
    {

        public string Id { get; set; } 

        public bool Active { get; set; } = true;


        public bool ReLoadFromStripe { get; set; } = false;

        public IEnumerable<BasePlanServicesUpdate> PlanServices { get; set; }

    }
}
