using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    public class DuplicateEntryException : BaseExceptionApp
    {
        public DuplicateEntryException()
        {
        }

        public DuplicateEntryException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public DuplicateEntryException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public DuplicateEntryException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }

}
