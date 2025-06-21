namespace Shared.Failures.Auth
{
    public class UnverifiedEmailFailure : AuthFailure
        {
            public UnverifiedEmailFailure(string message = "يجب تأكيد البريد الإلكتروني قبل تسجيل الدخول.")
                : base(message) { }
        }
    


}