namespace Shared.Failures
{
    namespace Shared.Failures.Network
    {
        // الخادم رفض الطلب (403 أو ما شابه)
        public class AccessDeniedFailure : NetworkFailure
        {
            public AccessDeniedFailure(string message = "تم رفض الوصول من الخادم.")
                : base(message) { }
        }
    }




}