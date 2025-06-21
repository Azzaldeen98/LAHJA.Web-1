using Shared.Interfaces;

namespace LAHJA.Data.UI.Models.Plan
{
    public class PlanCreateStartData:ITVM
    {
        public string Label { set; get; } = "create";

        public string Description { get; set; }= "Features are monetizable capabilities that can be linked to products, granting purchasing customers an entitlement to the feature through Stripe.";

        public string Titel { set; get; } = "Start by adding a feature";
    }



}
