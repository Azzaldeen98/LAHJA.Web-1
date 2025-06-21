namespace Shared.Failures
{
    namespace Shared.Failures.Network
    {
        // رد غير متوقع من الخادم (خطأ في البروتوكول أو الاستجابة)
        public class UnexpectedServerResponseFailure : NetworkFailure
        {
            public UnexpectedServerResponseFailure(string message = "رد غير متوقع من الخادم.")
                : base(message) { }
        }
    }




}