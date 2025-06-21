using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Auth.Request
{
    public class ResendConfirmationEmail
    {

        public  string Email { get; set; }
        public string ReturnUrl { get; set; } = "https://localhost:7121/ConfirmEmail";
    }   


}
