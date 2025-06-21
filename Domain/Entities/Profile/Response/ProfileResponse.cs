using Domain.Entities.BaseModels;
using Domain.Entities.Billing.Response;
using Domain.Entities.Plans.Response;
using Domain.Entities.Subscriptions.Response;
using Domain.ShareData.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Profile
{

    public class ProfileResponse : BaseProfile
    {

        public  BillingDetailsResponse? BillingDetails { get; set; }
        public  IEnumerable<SubscriptionResponse>? Subscriptions { get; set; }
        public  IEnumerable<CardDetailsResponse>? CreditCards { get; set; }

        
    }




}
