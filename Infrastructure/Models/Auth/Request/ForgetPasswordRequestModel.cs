namespace Infrastructure.Models.Plans
{
    public class ForgetPasswordRequestModel
    {
        public string? Email { get; set; }
        public string? ReturnUrl { get; set; }
    }


}
