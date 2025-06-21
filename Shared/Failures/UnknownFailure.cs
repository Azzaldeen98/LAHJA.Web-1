using Shared.Wrapper;

namespace Shared.Failures
{
    /// <summary>
    /// Represents an unknown or unclassified failure.
    /// Used when an unexpected error occurs and its type cannot be precisely determined.
    /// </summary>
    public class UnknownFailure : Failure
    {
        public UnknownFailure(string message = "حدث خطأ غير معروف.")
            : base(message)
        {
        }

        public UnknownFailure(int statusCode, string message = "حدث خطأ غير معروف.")
       : base(message, statusCode)
        {
        }
    }
}