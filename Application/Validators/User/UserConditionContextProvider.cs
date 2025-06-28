
using Domain.Validators.Enums;
using Domain.Validators.Conditions.Base;
using Domain.Validators.Conditions.Shared;
using Shared.Interfaces;
using Application.UseCases;


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
            return await GetContextAsync(conditionType, CancellationToken.None, input);
        }

        public async Task<object?> GetContextAsync(UserValidatorStates conditionType, CancellationToken cancellationToken, IConditionContextInput? input = null)
        {
            return conditionType switch
            {
                UserValidatorStates.SubscriptionActive when input is SubscriptionContextInput subscriptionInput =>
                    (await action.ExecuteAsync(cancellationToken)),

                // شروط أخرى...

                _ => null
            };
        }

  
    }

    
}
