using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    public class ConflictException : BaseExceptionApp
    {
        public ConflictException()
        {
        }

        public ConflictException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public ConflictException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public ConflictException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }

}
