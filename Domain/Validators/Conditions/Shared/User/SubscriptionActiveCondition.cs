using Domain.Entity;
using Shared.Interfaces;
using WasmAI.ConditionChecker.Base;

namespace Domain.Validators.Conditions.Shared.User
{

    public class SubscriptionActiveCondition : BaseCondition, ICondition, ITScope
    {

        public SubscriptionActiveCondition(string name = "Subscription Active", string? errorMessage = "No active subscription") : base(name, errorMessage)
        {

        }

        public override Task<ConditionResult> Evaluate(object? context)
        {
            var subscription = context as Subscription;

            return Task.FromResult(subscription?.Status?.ToLower() == "active"
                ? ConditionResult.ToSuccess(subscription)
                : ConditionResult.ToError("No active subscription."));
        }
    }
}
