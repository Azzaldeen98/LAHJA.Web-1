using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    // استثناء للأخطاء المتعلقة بالشبكة
    public class NetworkException : BaseExceptionApp, IExceptionApp
    {
        public NetworkException()
        {
        }

        public NetworkException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public NetworkException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public NetworkException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }


}
