using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    public class BadGatewayException : BaseExceptionApp
    {
        //502
        public BadGatewayException()
        {
        }

        public BadGatewayException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public BadGatewayException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public BadGatewayException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }


}
