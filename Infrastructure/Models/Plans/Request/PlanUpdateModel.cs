using Domain.ShareData.Base.Plan;


namespace Infrastructure.Models.Plans.Response
{
    public partial class PlanUpdateModel:BasePlanUpdate
    {

        public new IEnumerable<PlanServicesUpdateModel> PlanServices { get; set; }

    }

}
