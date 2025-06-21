using Application.UseCase.Plans.Get;
using Domain.Validator.Enums;
using Domain.Validators.Conditions.Base;
using Domain.Validators.Conditions.Shared;
using Shared.Interfaces;


namespace Application.Validators.User
{
    public interface IUserConditionContextProvider: ISharedConditionContextProvider<UserValidatorStates>,ITScope
    {

    }

    public class UserConditionContextProvider : IUserConditionContextProvider
    {
        private readonly GetSubscriptionUseCase action;

        public UserConditionContextProvider(GetSubscriptionUseCase action)
        {
            this.action = action;
        }

        public async Task<object?> GetContextAsync(UserValidatorStates conditionType, IConditionContextInput? input = null)
        {
            return conditionType switch
            {
                UserValidatorStates.SubscriptionActive when input is SubscriptionContextInput subscriptionInput =>
                    (await action.ExecuteAsync(subscriptionInput.Filter)).Data,

                // شروط أخرى...

                _ => null
            };
        }
    }

    
}
