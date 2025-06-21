using Shared.Exceptions.Base;

namespace Shared.Exceptions.Subscription
{
    /// <summary>
    /// SubscriptionExpiredFailure The subscription exists but has expired (expired).
    /// </summary>
    public class SubscriptionExpiredException : BaseExceptionApp
    {
        public SubscriptionExpiredException()
        {
        }

        public SubscriptionExpiredException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public SubscriptionExpiredException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public SubscriptionExpiredException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }


}
