using Shared.Wrapper;

namespace Shared.Failures.Auth
{


        public class InvalidCredentialsFailure : AuthFailure
        {
            public InvalidCredentialsFailure(string message = "البريد الإلكتروني أو كلمة السر غير صحيحة.")
                : base(message) { }
        }

}