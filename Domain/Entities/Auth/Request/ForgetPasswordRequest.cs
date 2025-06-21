namespace Domain.Entities.Auth.Request
{
    public class ForgetPasswordRequest
    {
        public string? Email { get; set; }
        public string? ReturnUrl { get; set; }
    }


}
