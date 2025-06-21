using System.Collections.Generic;

namespace CardShopping.Web.VitsModel 
{
    public class OutputPlance
    {
        public string   id { get; set; }
        public string name { get; set; }
//public OutProduct outProduct { get; set; }
        public string Price { get; set; }
        public string  NumberRequests { get; set; }
        public string PaymentPeriod { get; set; }
        public List<PlanFeature>featuresList { get; set; }

    }
}
