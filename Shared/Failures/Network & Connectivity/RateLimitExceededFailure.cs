using Shared.Wrapper;

namespace Shared.Failures
{

        // تجاوز الحد المسموح من الطلبات (429)
        public class RateLimitExceededFailure : NetworkFailure
        {
            public RateLimitExceededFailure(string message = "تم تجاوز الحد الأقصى للطلبات المسموح بها.")
                : base(message) { }
        }
    

}