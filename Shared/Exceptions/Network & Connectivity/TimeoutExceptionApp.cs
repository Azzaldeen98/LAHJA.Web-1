using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    public class TimeoutExceptionApp : BaseExceptionApp
    {
        public TimeoutExceptionApp()
        {
        }

        public TimeoutExceptionApp(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public TimeoutExceptionApp(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public TimeoutExceptionApp(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }   


}
