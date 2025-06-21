namespace Domain.ShareData.Base
{
    public class BaseConfirmEmailRequest
    {
        public string Email { get; set; }
        public string Code { get; set; }

        public string ReturnUrl { get; set; } = "https://localhost:7121/ConfirmEmail";
        public string ChangedEmail { get; set; }
    }
}
