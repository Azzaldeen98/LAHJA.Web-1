using Shared.Exceptions.Base;

namespace Shared.Exceptions.General
{
    public class MaxRetryAttemptsReachedException : BaseExceptionApp
    {
        public MaxRetryAttemptsReachedException()
        {
        }

        public MaxRetryAttemptsReachedException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public MaxRetryAttemptsReachedException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public MaxRetryAttemptsReachedException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }

}
