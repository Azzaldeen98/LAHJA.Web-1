using Domain.ShareData.Base;
using Domain.ShareData.Base.Response;
using Infrastructure.Models.Plans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.Subscriptions.Response
{

    public partial class SubscriptionResponseModel : BaseSubscription
    {
        public SubscriptionPlanModel? SubscriptionPlan { get; set; }
    }




}
