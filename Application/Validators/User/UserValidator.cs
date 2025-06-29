using WasmAI.ConditionChecker.Base;
using Shared.Interfaces;
using Domain.Validators.Conditions.Base;

using Domain.Validators.Conditions.Shared.User;
using WasmAI.ConditionChecker.Validators;
using Application.Validators.Shared;
using Domain.Validators.Enums;
using System;


namespace Application.Validators.User
{
    /// <summary>
    /// Represents a validator for user-related conditions.
    /// </summary>
    public interface IUserValidator: ISharedValidator<UserValidatorStates>, ITScope
    {

    }


    /// <summary>
    /// Represents a validator for user-related conditions.
    /// </summary>
    public class UserValidator : BaseValidator<UserValidatorStates>, IUserValidator
    {
        //private readonly IUserConditionChecker checker;
        private readonly IUserConditionContextProvider contextProvider;

        public UserValidator(IUserConditionChecker checker, IUserConditionContextProvider contextProvider)
            :base(checker) 
        {
            //this.checker = checker;
            this.contextProvider = contextProvider;

        }

       
        /// <summary>
        /// Initializes and registers the set of condition validators required for user validation.
        /// </summary>
        /// <remarks>
        /// This method creates a condition provider, registers specific condition instances (such as subscription activation verification) associated with the validation instances,
        /// then registers the provider with the main condition validator.
        /// This setting enables the system to dynamically evaluate user-related conditions during validation.
        /// This function is executed automatically when an instance of this class is created.
        /// </remarks>
        protected override void InitializeConditions()
        {
            //var conditionProvider = new UserConditionProvider();
          
            _provider.Register(UserValidatorStates.SubscriptionActive, new SubscriptionActiveCondition());
            _checker.RegisterProvider(_provider);

        }

        /// <summary>
        /// Validates the user based on the specified condition type and optional input.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ConditionResult> ValidateAsync(UserValidatorStates type, IConditionContextInput? input = null)
        {
            return await ValidateAsync(type, CancellationToken.None, input);
        }

        public async Task<ConditionResult> ValidateAsync(UserValidatorStates type, CancellationToken cancellationToken, IConditionContextInput? input = null)
        {

            var provider = _checker.GetProvider<UserValidatorStates>();
            var condition = provider?.Get(type);

            object? context = null;

            if (condition != null)
            {
                context = await contextProvider.GetContextAsync(type, cancellationToken, input);
            }

            return await _checker.CheckAndResultAsync(type, context);
        }

    }

    
}
