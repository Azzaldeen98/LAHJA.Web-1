using Shared.Wrapper;

namespace Shared.Failures
{

    /// <summary>
    /// Represents a failure related to validation of data or inputs.
    /// Example: invalid email format, weak password.
    /// </summary>
    public class ValidationFailure : Failure
    {
        public ValidationFailure(string message) : base(message) { }
    }
}