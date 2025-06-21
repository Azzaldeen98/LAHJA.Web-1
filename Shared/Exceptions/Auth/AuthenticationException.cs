using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    // استثناء للأخطاء المتعلقة بالمصادقة (Authentication)
    public class AuthenticationException : BaseExceptionApp, IExceptionApp
    {
        public AuthenticationException()
        {
        }

        public AuthenticationException(string message) : base(message) { }

        public AuthenticationException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public AuthenticationException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public AuthenticationException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }


}
