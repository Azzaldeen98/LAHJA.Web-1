using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    public class InvalidCredentialsException : BaseExceptionApp, IExceptionApp
    {

        //401
        public InvalidCredentialsException()
        {
        }

        public InvalidCredentialsException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public InvalidCredentialsException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public InvalidCredentialsException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }

}
