

namespace Shared.Failures.Server
{
    // خطأ في التهيئة (HTTP 500-599 عام)
    public class GeneralServerErrorFailure : ServerFailure
    {

        public GeneralServerErrorFailure(string message = "خطأ في الخادم.") : base(message)
        {

        }
        public GeneralServerErrorFailure(int statusCode, string message = "خطأ في الخادم.")
            : base(statusCode,message)
        {
            
        }
    }


}