using Shared.Wrapper;

namespace Shared.Failures
{

    /// <summary>
    /// Represents a failure related to authentication and authorization.
    /// Example: incorrect password, unauthorized access, insufficient permissions.
    /// </summary>
    public abstract class AuthFailure : Failure
    {
        protected AuthFailure(string message) : base(message) { }
    }

}