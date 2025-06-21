using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    public class UnsupportedMediaTypeException : BaseExceptionApp
    {
        public UnsupportedMediaTypeException() : base("Unsupported media type", "UNSUPPORTED_MEDIA_TYPE") { }

        public UnsupportedMediaTypeException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public UnsupportedMediaTypeException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public UnsupportedMediaTypeException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }

}
