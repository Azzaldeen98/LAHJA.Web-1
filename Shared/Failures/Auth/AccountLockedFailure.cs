using Shared.Wrapper;

namespace Shared.Failures.Auth
{
    public class AccountLockedFailure : AuthFailure
        {
            public AccountLockedFailure(string message = "تم قفل الحساب بسبب عدة محاولات فاشلة.")
                : base(message) { }
        }

}