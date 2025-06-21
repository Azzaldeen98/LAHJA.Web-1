namespace Shared.Failures
{
    namespace Shared.Failures.Network
    {
        // SSL/TLS شهادة غير موثوقة أو خطأ تشفير
        public class SecureConnectionFailure : NetworkFailure
        {
            public SecureConnectionFailure(string message = "فشل في الاتصال الآمن بالخادم.")
                : base(message) { }
        }
    }




}