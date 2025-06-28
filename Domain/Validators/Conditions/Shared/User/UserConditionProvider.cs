using Domain.Validators.Enums;
using Domain.Validators.Conditions.Base;
using Domain.Validators.Conditions.Shared;
using WasmAI.ConditionChecker.Checker;

namespace Domain.Validators.Conditions.Shared.User
{

    /// <summary>
    /// Represents a condition provider specialized for user-related validation states.
    /// Inherits from <see cref="BaseConditionProvider{UserValidatorStates}"/> to manage
    /// conditions keyed by <see cref="UserValidatorStates"/> enum values.
    /// Implements <see cref="ISharedConditionProvider"/> to participate in shared condition provider mechanisms.
    /// </summary>
    public class UserConditionProvider : BaseConditionProvider<UserValidatorStates>,  ISharedConditionProvider
    {


    }
}
