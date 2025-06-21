using Shared.Exceptions.Base;

namespace Shared.Exceptions.Others
{
    public class OperationFailedException : BaseExceptionApp
    {
        public OperationFailedException()
        {
        }

        public OperationFailedException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public OperationFailedException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public OperationFailedException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }

}
