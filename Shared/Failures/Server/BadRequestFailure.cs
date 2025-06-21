namespace Shared.Failures.Server
{
    public class BadRequestFailure : ServerFailure
    {
        public BadRequestFailure(string message = "طلب غير صالح.") : base($"BadRequest:{message}") { }
        public BadRequestFailure(int statusCode, string message = "طلب غير صالح.")
           : base(statusCode, $"BadRequest:{message}")
        {

        }
    }
}
