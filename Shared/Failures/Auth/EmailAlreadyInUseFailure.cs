namespace Shared.Failures.Auth
{
    public class EmailAlreadyInUseFailure : AuthFailure
        {
            public EmailAlreadyInUseFailure(string message = "البريد الإلكتروني مستخدم بالفعل.")
                : base(message) { }
        }
    


}