

namespace Shared.Failures.Server
{
    // الخدمة غير متوفرة (Service Unavailable 503)
    public class ServiceUnavailableFailure : ServerFailure
    {
        public ServiceUnavailableFailure(string message = "الخدمة غير متوفرة حالياً.")
            : base(503,message) { }
    }


}