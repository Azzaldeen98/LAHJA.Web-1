using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Auth.Request
{

    public class RegisterRequest
    {


        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? FullName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }


        public string? ConfirmPassword { get; set; }


        public string? Avatar { get; set; }


        public string? ReturnUrl { get; set; } = "https://localhost:7121/ConfirmEmail";

        public  string? UserRole { get; set; }

    }


}
