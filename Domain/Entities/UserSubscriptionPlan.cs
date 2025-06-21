using Domain.Entities.Plans.Response;
using Domain.ShareData.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserSubscriptionPlan : BaseSubscriptionPlan
    {
        public new List<PlanFeature>? Features { get; set; }

    }

}


