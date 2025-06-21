namespace Shared.Failures
{
    namespace Shared.Failures.Network
    {
        // تعذر تحليل البيانات المستلمة (مثلاً JSON غير صالح)
        public class ResponseParsingFailure : NetworkFailure
        {
            public ResponseParsingFailure(string message = "تعذر قراءة استجابة الخادم.")
                : base(message) { }
        }
    }




}