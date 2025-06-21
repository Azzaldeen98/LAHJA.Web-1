namespace Shared.Failures
{
    namespace Shared.Failures.Network
    {
        // فشل في الاتصال بالخادم (timeout)
        public class ConnectionTimeoutFailure : NetworkFailure
        {
            public ConnectionTimeoutFailure(string message = "انتهت مهلة الاتصال بالخادم.")
                : base($"ConnectionTimeout:{message}") { }
        }        
    }




}