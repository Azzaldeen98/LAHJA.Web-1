using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    public class NetworkUnavailableException : BaseExceptionApp
    {
        public NetworkUnavailableException() : base("Network is unavailable", "NETWORK_ERROR") { }

        public NetworkUnavailableException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public NetworkUnavailableException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public NetworkUnavailableException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }


}
