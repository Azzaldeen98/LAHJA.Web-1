using Shared.Exceptions.Base;

namespace Shared.Exceptions.Operation
{
    public class ClientTaskCanceledException : BaseExceptionApp
    {
        public ClientTaskCanceledException()
        {
        }

        public ClientTaskCanceledException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public ClientTaskCanceledException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public ClientTaskCanceledException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }

}
