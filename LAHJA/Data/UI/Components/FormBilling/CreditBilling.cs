using System.ComponentModel.DataAnnotations;

namespace LAHJA.Data.UI.Components.Billing
{
    
        public class CreditBilling
        {

       
            [Required(ErrorMessage = "Full name is required.")]
            public string FullName { get; set; }


            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Invalid email address.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Phone is required.")]
            [Phone(ErrorMessage = "Invalid phone number.")]
            public string Phone { get; set; }

            [Required(ErrorMessage = "Address is required.")]
            public string Address { get; set; }

            [Required(ErrorMessage = "City is required.")]
            public string City { get; set; }

            [Required(ErrorMessage = "Country is required.")]
            public string Country { get; set; }
        }


 
}
