using Shared.Exceptions.Base;

namespace Shared.Exceptions.Server
{
    public class InternalServerException : BaseExceptionApp
    {
        public InternalServerException()
        {
        }

        public InternalServerException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public InternalServerException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public InternalServerException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }

}
