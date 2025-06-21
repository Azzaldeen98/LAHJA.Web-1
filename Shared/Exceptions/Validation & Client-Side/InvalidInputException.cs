using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    // استثناء للأخطاء المتعلقة بإدخال بيانات غير صحيحة
    public class InvalidInputException : BaseExceptionApp, IExceptionApp
    {
        public InvalidInputException()
        {
        }

        public InvalidInputException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public InvalidInputException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public InvalidInputException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }

}
