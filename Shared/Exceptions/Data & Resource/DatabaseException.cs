using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    // استثناء عام للأخطاء المتعلقة بقاعدة البيانات
    public class DatabaseException : BaseExceptionApp, IExceptionApp
    {
        public DatabaseException()
        {
        }

        public DatabaseException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public DatabaseException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public DatabaseException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }

}
