namespace Shared.Failures.Auth
{
    public class LockedOutFailure : AuthFailure
    {
        public LockedOutFailure(string message = "تم قفل الحساب مؤقتًا بسبب محاولات تسجيل دخول متكررة غير ناجحة. الرجاء المحاولة لاحقًا.")
            : base(message) { }
    }

}