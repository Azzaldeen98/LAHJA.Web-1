using Shared.Wrapper;

namespace Shared.Failures
{

    /// <summary>
    /// Represents a failure related to network or internet connectivity.
    /// Example: connection lost, timeout.
    /// </summary>
    public class NetworkFailure : Failure
    {
        public NetworkFailure(string message = "خطأ في الاتصال بالشبكة.") : base(message) { }
    }
    


}