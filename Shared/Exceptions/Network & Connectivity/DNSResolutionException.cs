using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    public class DNSResolutionException : BaseExceptionApp
    {
        public DNSResolutionException()
        {
        }

        public DNSResolutionException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public DNSResolutionException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public DNSResolutionException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }


}
