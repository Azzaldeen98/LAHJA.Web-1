using Shared.Wrapper;
using System.Buffers.Text;

namespace Shared.Failures
{

    /// <summary>
    /// Represents a failure that occurred on the server or in server response.
    /// Example: internal server error (500), resource not found (404).
    /// </summary>
    public class ServerFailure : Failure
    {
        public ServerFailure(string message = "خطأ في الخادم.") : base(message)
        {
        }

        public ServerFailure(int statusCode,string message) : base(message, statusCode)
        {
        }

        public ServerFailure(string message, string statusCode) : base(message, ParseStatusCode(statusCode))
        {
        }
    }


}