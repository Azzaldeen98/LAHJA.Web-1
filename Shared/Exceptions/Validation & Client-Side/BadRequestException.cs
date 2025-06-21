using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    public class BadRequestException : BaseExceptionApp
    {
        public BadRequestException() : base("Bad request", "BAD_REQUEST") { }

        public BadRequestException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public BadRequestException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public BadRequestException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }

}
