using Domain.ShareData.Base;
using Domain.Validators.Conditions.Base;


namespace Application.Validators.User
{
    public class SubscriptionContextInput : IConditionContextInput
    {
        public FilterResponseData Filter { get; set; }
    }

    
}
