

namespace Shared.Failures.Server
{
    // البوابة غير متاحة (Bad Gateway 502)
    public class BadGatewayFailure : ServerFailure
    {
        public BadGatewayFailure(string message = "البوابة غير متاحة.")
            : base(502,message) { }
    }


}