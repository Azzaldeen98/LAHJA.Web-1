namespace Shared.Failures.Auth
{
    public class UserNotFoundFailure : AuthFailure
        {
            public UserNotFoundFailure(string message = "المستخدم غير موجود.")
                : base(message) { }
        }
    


}