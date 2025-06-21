

namespace Shared.Failures.Server
{
    // تجاوز المهلة من البوابة (Gateway Timeout 504)
    public class GatewayTimeoutFailure : ServerFailure
    {
        public GatewayTimeoutFailure(string message = "انتهت مهلة البوابة.")
            : base(504,message) { }

        public GatewayTimeoutFailure(int statusCode, string message = "انتهت مهلة البوابة.")
            : base(statusCode, message)
        {

        }
    }


}