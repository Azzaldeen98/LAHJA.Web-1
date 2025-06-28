using Domain.ShareData.Base;
using Domain.Validators.Conditions.Base;


namespace Application.Validators.User
{
    /// <summary>
    /// Represents a context input specifically for subscription-related condition evaluations.
    /// This class serves as a placeholder or marker to identify subscription contexts 
    /// when passed to condition evaluators or rule engines.
    /// </summary>
    /// <remarks>
    /// Although currently empty, this class can be extended in the future to include
    /// properties or methods relevant to subscription condition checks.
    /// Implements <see cref="IConditionContextInput"/> to allow polymorphic handling
    /// within condition evaluation frameworks.
    /// </remarks>
    public class SubscriptionContextInput : IConditionContextInput
    {
      
    }

    
}
