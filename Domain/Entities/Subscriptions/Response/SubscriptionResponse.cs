using Domain.Entities.Plans.Response;
using Domain.ShareData.Base;
using Domain.ShareData.Base.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Subscriptions.Response
{
    public partial class SubscriptionResponse: BaseSubscription
    {
        public SubscriptionPlan? SubscriptionPlan { get; set; }
    }
}
