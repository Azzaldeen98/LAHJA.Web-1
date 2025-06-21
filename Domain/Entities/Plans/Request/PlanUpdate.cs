
using Domain.ShareData.Base.Plan;

namespace Domain.Entities.Plans.Response
{
    public class PlanUpdate : BasePlanUpdate
    {
        public new IEnumerable<BasePlanServicesUpdate> PlanServices { get; set; }
    }
}
