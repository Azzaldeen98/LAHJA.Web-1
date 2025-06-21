using WasmAI.ConditionChecker.Base;
using Shared.Interfaces;
using Domain.Validators.Conditions.Base;
using Domain.Validator.Enums;
using Domain.Validators.Conditions.Shared.User;
using WasmAI.ConditionChecker.Validators;
using Application.Validators.Shared;


namespace Application.Validators.User
{

    public interface IUserValidator: ISharedValidator<UserValidatorStates>, ITScope
    {

    }

    public class UserValidator : BaseValidator<UserValidatorStates>, IUserValidator
    {
        private readonly IUserConditionChecker checker;
        private readonly IUserConditionContextProvider contextProvider;

        public UserValidator(IUserConditionChecker checker, IUserConditionContextProvider contextProvider):base(checker) 
        {
            this.checker = checker;
            this.contextProvider = contextProvider;
        }

   
        protected override void InitializeConditions()
        {
            var conditionProvider = new UserConditionProvider();
            var subscriptionActiveCondition = new SubscriptionActiveCondition();

            conditionProvider.Register(UserValidatorStates.SubscriptionActive, subscriptionActiveCondition);
            conditionProvider.Register(UserValidatorStates.EmailVerified, subscriptionActiveCondition);
            conditionProvider.Register(UserValidatorStates.UsageWithinLimit, subscriptionActiveCondition);

            checker.RegisterProvider(conditionProvider);
        }

        public async Task<ConditionResult> ValidateAsync(UserValidatorStates type, IConditionContextInput? input = null)
        {
            var provider = checker.GetProvider<UserValidatorStates>();
            var condition = provider?.Get(type);

            object? context = null;

            if (condition != null)
            {
                context = await contextProvider.GetContextAsync(type, input);
            }

            return await checker.CheckAndResultAsync(type, context);
        }

    }

    
}
