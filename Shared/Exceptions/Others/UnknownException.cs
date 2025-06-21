using Shared.Exceptions.Base;

namespace Shared.Exceptions.Others
{
  
    public class UnknownException : BaseExceptionApp
    {
        public UnknownException()
        {
        }

        public UnknownException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public UnknownException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public UnknownException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }

}
