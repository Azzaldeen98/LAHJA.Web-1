namespace Shared.Failures.Server
{
    public class NotFoundFailure : ServerFailure
    {
        public NotFoundFailure(string message = "لم يتم العثور على المورد المطلوب.")
            : base(message)
        {
        }
        public NotFoundFailure(int statusCode, string message = "لم يتم العثور على المورد المطلوب.") : base(statusCode,message)
        {
        }
    }
}
