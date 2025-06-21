using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    public class TokenExpiredException : BaseExceptionApp
    {
        public TokenExpiredException()
        {
        }

        public TokenExpiredException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public TokenExpiredException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public TokenExpiredException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }

}
