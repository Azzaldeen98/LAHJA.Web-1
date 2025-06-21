using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    public class InvalidTokenException : BaseExceptionApp
    {
        public InvalidTokenException()
        {
        }

        public InvalidTokenException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public InvalidTokenException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public InvalidTokenException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }


}
