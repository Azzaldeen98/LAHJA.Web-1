using Shared.Wrapper;

namespace Shared.Failures.Auth
{
    public class InvalidEmailFailure : AuthFailure
    {
        public InvalidEmailFailure(string message = "البريد الإلكتروني غير صالح.")
            : base(message) { }
    }    

}