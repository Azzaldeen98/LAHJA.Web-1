using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    public class HostNotFoundException : BaseExceptionApp
    {
        public HostNotFoundException() : base("HostNotFound", "") { }

        public HostNotFoundException(string message, string errorCode = "") : base(message, errorCode)
        {
        }

        public HostNotFoundException(List<string> messages, string errorCode = "") : base(messages, errorCode)
        {
        }

        public HostNotFoundException(string message, Exception innerException, string errorCode = "") : base(message, innerException, errorCode)
        {
        }
    }
}
