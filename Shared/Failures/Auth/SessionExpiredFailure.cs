namespace Shared.Failures.Auth
{
    public class SessionExpiredFailure : AuthFailure
        {
            public SessionExpiredFailure(string message = "انتهت صلاحية الجلسة. يرجى تسجيل الدخول مجددًا.")
                : base(message) { }
        }
    


}