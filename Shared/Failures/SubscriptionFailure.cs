using Shared.Wrapper;

namespace Shared.Failures
{

    /// <summary>
    /// Represents a failure related to subscription or billing status.
    /// Example: subscription expired, subscription unavailable.
    /// </summary>
    public class SubscriptionFailure : Failure
    {
        public SubscriptionFailure(string message) : base(message) { }

        public SubscriptionFailure(int statusCode, string message ): base(message, statusCode)
        {
        }
    }


}