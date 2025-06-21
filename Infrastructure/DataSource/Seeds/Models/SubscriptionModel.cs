using Domain.ShareData.Base;
using Infrastructure.Models.Plans;

namespace Infrastructure.DataSource.Seeds.Models
{
    public partial class SubscriptionModel:BaseSubscription
    {
       
        public SubscriptionPlanModel? SubscriptionPlan { get; set; }
        public List<SubscriptionPlanModel>? Services { get; set; }
    }

   
}
