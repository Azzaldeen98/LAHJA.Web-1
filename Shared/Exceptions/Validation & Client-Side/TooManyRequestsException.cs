using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    public class TooManyRequestsException : BaseExceptionApp
    {
        public TooManyRequestsException() : base("Too many requests, try again later", "TOO_MANY_REQUESTS") { }

        public TooManyRequestsException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public TooManyRequestsException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public TooManyRequestsException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }

}
