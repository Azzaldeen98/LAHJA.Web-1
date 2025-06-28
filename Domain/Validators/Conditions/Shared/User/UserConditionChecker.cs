using Domain.Validators.Conditions.Shared;
using Shared.Interfaces;
using WasmAI.ConditionChecker.Checker;

namespace Domain.Validators.Conditions.Shared.User
{
    public interface IUserConditionChecker: ISharedConditionChecker , ITScope
    {

    }

    /// <summary>
    /// Provides a basic implementation of a condition checker that manages and evaluates various condition providers.
    /// </summary>
    /// <remarks>
    /// This abstract class maintains a collection of condition providers defined by enumeration types.
    /// It provides synchronous and asynchronous methods for checking a single or multiple conditions.
    /// It supports error reporting, retrying, and evaluating conditions using custom logic or multiple contexts.
    ///
    /// The class emits events when conditions are met or failed, allowing subscribers to react accordingly.
    ///
    /// The public constraint <typeparamref name="TEnum"/> ensures that condition types are always enumeration values.
    /// It enables type-safe logging and evaluation of conditions.
    /// Conditions are stored in an array for later reuse without having to rebuild the conditions each time.
    /// This class is designed to be extended to implement specific behaviors for condition validation by inheriting from them.
    /// All of the above functions are available in the parent class from which the current class inherits.
    /// </remarks>
    public class UserConditionChecker : BaseConditionChecker, IUserConditionChecker
    {


    }
}
