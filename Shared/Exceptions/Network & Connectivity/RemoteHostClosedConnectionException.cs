using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    public class RemoteHostClosedConnectionException : BaseExceptionApp
    {
        public RemoteHostClosedConnectionException()
        {
        }

        public RemoteHostClosedConnectionException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public RemoteHostClosedConnectionException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public RemoteHostClosedConnectionException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }


}
