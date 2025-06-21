namespace Shared.Failures
{
    namespace Shared.Failures.Network
    {
        // عدم وجود اتصال بالإنترنت
        public class NoInternetConnectionFailure : NetworkFailure
        {
            public NoInternetConnectionFailure(string message = "لا يوجد اتصال بالإنترنت.")
                : base(message) { }
        }
    }




}