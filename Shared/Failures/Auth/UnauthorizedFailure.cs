using Shared.Wrapper;

namespace Shared.Failures.Auth
{    /// <summary>
     /// 401 Unauthorized The user is not recognized, the user did not submit credentials (such as a token),
     /// or the credentials provided are invalid.
     /// </summary>
    public class UnauthorizedFailure : Failure
    {
        public UnauthorizedFailure(string message = "غير مصرح بالدخول.")
            : base(message)
        {
        }
    }



}