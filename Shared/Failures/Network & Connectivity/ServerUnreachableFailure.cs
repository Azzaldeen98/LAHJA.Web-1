namespace Shared.Failures
{
    namespace Shared.Failures.Network
    {
        // لا يمكن الوصول إلى الخادم
        public class ServerUnreachableFailure : NetworkFailure
        {
            public ServerUnreachableFailure(string message = "لا يمكن الوصول إلى الخادم.")
                : base(message) { }
        }
    }




}