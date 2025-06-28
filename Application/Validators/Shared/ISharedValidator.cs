using WasmAI.ConditionChecker.Base;
using Domain.Validators.Conditions.Base;
using WasmAI.ConditionChecker.Validators;


namespace Application.Validators.Shared
{

    /// <summary>
    /// Defines a generic validator interface that supports validation based on a specified enum type.
    /// </summary>
    /// <typeparam name="TEnum">
    /// The enumeration type that specifies the kind of validation to perform.
    /// Must be an enum.
    /// </typeparam>
    /// <remarks>
    /// This interface extends <see cref="ITValidator"/> and provides an asynchronous method
    /// <see cref="ValidateAsync"/> that accepts a validation type (as enum) and an optional
    /// validation context input (<see cref="IConditionContextInput"/>).
    /// The validation logic can be differentiated based on the provided enum value,
    /// allowing flexible and reusable validation implementations.
    /// </remarks>
    public interface ISharedValidator<TEnum> : ITValidator where TEnum:Enum
    {
        Task<ConditionResult> ValidateAsync(TEnum type, IConditionContextInput? input = null);
    }

    
}
