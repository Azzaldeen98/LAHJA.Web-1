using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    public class ServiceUnavailableException : BaseExceptionApp
    {
        public ServiceUnavailableException() : base("Service is currently unavailable", "SERVICE_UNAVAILABLE") { }

        public ServiceUnavailableException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public ServiceUnavailableException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public ServiceUnavailableException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }


}
