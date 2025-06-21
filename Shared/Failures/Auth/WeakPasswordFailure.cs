namespace Shared.Failures.Auth
{
    public class WeakPasswordFailure : AuthFailure
        {
            public WeakPasswordFailure(string message = "كلمة السر ضعيفة. يرجى اختيار كلمة أقوى.")
                : base(message) { }
        }



}