namespace Shared.Models
{
    public class RecaptchaResponse
    {
        public bool Success { get; set; }
        public string ChallengeTs { get; set; }
        public string Hostname { get; set; }
        public string[] ErrorCodes { get; set; }
    }

}
