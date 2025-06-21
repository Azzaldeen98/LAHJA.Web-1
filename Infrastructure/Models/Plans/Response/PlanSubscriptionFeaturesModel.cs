using Domain.Entities.Plans.Response;
using Domain.ShareData.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.Plans.Response
{


    public class PlanSubscriptionFeaturesModel : BaseSubscriptionFeatures
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    public class UserSubscriptionPlanModel : BaseSubscriptionPlan
    {
        public new List<PlanFeatureModel>? Features { get; set; }

    }

   

   

}
