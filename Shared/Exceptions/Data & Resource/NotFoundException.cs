using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    public class NotFoundException : BaseExceptionApp
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public NotFoundException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public NotFoundException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }

}
