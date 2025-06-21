namespace Shared.Failures.Auth
{
    public class InvalidPhoneNumberFailure : AuthFailure
    {
        public InvalidPhoneNumberFailure(string message = "  رقم الهاتف غير صالح.")
            : base(message) { }
    }

}