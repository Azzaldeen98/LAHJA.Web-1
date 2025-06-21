using Domain.ShareData.Base;
using Infrastructure.Models.Base.Response;

namespace Infrastructure.Models.Plans
{

    public class ContainerPlansModel : BaseContainerPlans, IBaseMonitorResponseModel
    {
        public new List<SubscriptionPlanModel>? SubscriptionsPlans { get; set; }
        public string ServiceUrl { get; set; }
        public string ServiceToken { get; set; }

    }






}
