using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    public class ValidationException : BaseExceptionApp
    {
        public ValidationException()
        {
        }

        public ValidationException(List<string> messages) : base(messages, "VALIDATION_ERROR") { }

        public ValidationException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public ValidationException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public ValidationException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }

}
