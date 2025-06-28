namespace Domain.Validators.Conditions.Base
{
    
    /// <summary>
    /// Defines a contract for context input objects used in condition evaluation processes.
    /// This interface represents a general-purpose marker or base for any data container
    /// that holds information needed to evaluate specific conditions or rules within the system.
    /// </summary>
    /// <remarks>
    /// Implementing this interface allows different types of context inputs to be
    /// handled polymorphically by condition evaluators or rule engines.
    /// It can be extended later to include common properties or methods if needed.
    /// </remarks>
    public interface IConditionContextInput { }

    
}
