using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ShareData.Base;

namespace Domain.Entities.Plans.Response
{
    public class PlanResponse
    {
        public string? Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductId { get; set; }
        public string? BillingPeriod { get; set; }
        public long? NumberRequests { get; set; }
        public double? Amount { get; set; }
        public bool Active { get; set; } = false;
        //public DateTime? CreatedAt { get; set; }
        public ICollection<BaseSubscription>? Subscriptions { get; set; }

    }

      

}
