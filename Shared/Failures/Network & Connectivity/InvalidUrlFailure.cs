namespace Shared.Failures
{
    namespace Shared.Failures.Network
    {
        // خطأ في عنوان URL أو التنسيق
        public class InvalidUrlFailure : NetworkFailure
        {
            public InvalidUrlFailure(string message = "عنوان URL غير صالح.")
                : base(message) { }
        }
    }




}