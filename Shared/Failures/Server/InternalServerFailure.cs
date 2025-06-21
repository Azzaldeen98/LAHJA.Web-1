

namespace Shared.Failures.Server
{
    // خطأ داخلي في الخادم (Internal Server Error 500)
    public class InternalServerFailure : ServerFailure
    {
        public InternalServerFailure(string message = "خطأ داخلي في الخادم.")
            : base(message) { }

        public InternalServerFailure(int statusCode,string message = "خطأ داخلي في الخادم.") : base(statusCode,message)
        {
        }
    }


}