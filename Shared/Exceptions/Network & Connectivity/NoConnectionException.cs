using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    public class NoConnectionException : BaseExceptionApp
    {
        public NoConnectionException() : base("NoConnectionException", "") { }

        public NoConnectionException(string message, string errorCode = "") : base(message, errorCode)
        {
        }

        public NoConnectionException(List<string> messages, string errorCode = "") : base(messages, errorCode)
        {
        }

        public NoConnectionException(string message, Exception innerException, string errorCode = "") : base(message, innerException, errorCode)
        {
        }
    }

}
