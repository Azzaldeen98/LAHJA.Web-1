using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    public class DataIntegrityException : BaseExceptionApp
    {
        public DataIntegrityException()
        {
        }

        public DataIntegrityException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public DataIntegrityException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public DataIntegrityException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }

}
