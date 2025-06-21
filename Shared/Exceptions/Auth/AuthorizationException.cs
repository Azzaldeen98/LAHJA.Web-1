using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    // استثناء للأخطاء المتعلقة بالتصريح (Authorization)
    public class AuthorizationException : BaseExceptionApp, IExceptionApp
    {
        public AuthorizationException()
        {
        }

        public AuthorizationException(string message) : base(message) { }

        public AuthorizationException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public AuthorizationException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public AuthorizationException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }

}
