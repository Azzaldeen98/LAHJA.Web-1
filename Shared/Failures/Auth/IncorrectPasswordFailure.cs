using Shared.Wrapper;

namespace Shared.Failures.Auth
{
    /// <summary>
    /// 
    /// </summary>
    public class IncorrectPasswordFailure : AuthFailure
    {
        public IncorrectPasswordFailure(string message = "كلمة المرور غير صحيحة.")
            : base(message)
        {
        }
    }

}