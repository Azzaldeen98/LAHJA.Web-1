using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    public class LockedOutException : BaseExceptionApp
    {
        public LockedOutException()
        {
        }

        public LockedOutException(string message, string errorCode = "") : base(message, errorCode)
        {
        }

        public LockedOutException(List<string> messages, string errorCode = "") : base(messages, errorCode)
        {
        }

        public LockedOutException(string message, Exception innerException, string errorCode = "") : base(message, innerException, errorCode)
        {
        }
    }


}
