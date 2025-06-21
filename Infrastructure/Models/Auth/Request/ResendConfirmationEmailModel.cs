using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Plans
{
    public class ResendConfirmationEmailModel
    {
  
        public  string Email { get; set; }
        public string ReturnUrl { get; set; } = "https://localhost:7121//ConfirmEmail";
    }   


}
