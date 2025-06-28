using Domain.Validators.Conditions.Base;

namespace Domain.Validators.Conditions.Shared
{
    public interface ISharedConditionContextProvider<TEnum>: IBaseConditionContextProvide where TEnum : Enum
    {
        Task<object?> GetContextAsync(TEnum conditionState, IConditionContextInput? input = null);
        Task<object?> GetContextAsync(TEnum conditionState,CancellationToken cancellationToken, IConditionContextInput? input = null);
    }

}
