using Shared.Wrapper;

namespace Shared.Failures
{

    /// <summary>
    /// Represents a failure related to a specific operation or task inside the system.
    /// Example: task cancelled by user, operation execution failed.
    /// </summary>
    public abstract class OperationFailure : Failure
    {
        protected OperationFailure(string message) : base(message) { }
    }
}
