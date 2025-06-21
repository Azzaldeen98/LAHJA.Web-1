using Microsoft.AspNetCore.Http;

namespace Shared.Wrapper
{
    /// <summary>
    /// The base class that represents any failure (logical or technical error) in the system.
    /// It can be inherited to define different types of failures, such as:
    /// - ValidationFailure
    /// - AuthFailure
    /// - NetworkFailure
    /// - ServerFailure
    /// - UnknownFailure
    /// </summary>
    public interface IFailure {

        string ToString();
        string Message { get; }


    }
    /// <summary>
    /// The base class that represents any failure (logical or technical error) in the system.
    /// It can be inherited to define different types of failures, such as:
    /// - ValidationFailure
    /// - AuthFailure
    /// - NetworkFailure
    /// - ServerFailure
    /// - UnknownFailure
    /// </summary>
    public abstract class Failure : IFailure
    {
        public int StatusCode { get; }
        public string Message { get; }

        protected Failure(string message)
        {
            Message = message;
        }

        protected Failure(string message, int statusCode) : this(message)
        {
            StatusCode = statusCode;
        }

        public override string ToString() => Message;

        public static int ParseStatusCode(string statusCode)
        {
            if (int.TryParse(statusCode, out int code))
            {
                return code;
            }
            else
            {
                // قيمة افتراضية إذا لم يتم التحويل بنجاح
                return -1;
            }
        }
    }

}