namespace Shared.Failures
{
    namespace Shared.Failures.Network
    {
        public class HostNotFoundFailure : NetworkFailure
        {
            public HostNotFoundFailure(string message = "تعذر ايجاد  عنوان المضيف .")
                : base($"ConnectionTimeout:{message}") { }
        }
    }




}