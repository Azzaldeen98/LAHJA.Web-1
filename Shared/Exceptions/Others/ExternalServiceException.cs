using Shared.Exceptions.Base;

namespace Shared.Exceptions.Others
{
    public class ExternalServiceException : BaseExceptionApp
    {
        public ExternalServiceException()
        {
        }

        public ExternalServiceException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public ExternalServiceException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public ExternalServiceException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }

}
