using WasmAI.ConditionChecker.Base;
using Domain.Validators.Conditions.Base;
using WasmAI.ConditionChecker.Validators;


namespace Application.Validators.Shared
{
    public interface ISharedValidator<TEnum> : ITValidator where TEnum:Enum
    {
        Task<ConditionResult> ValidateAsync(TEnum type, IConditionContextInput? input = null);
    }

    
}
