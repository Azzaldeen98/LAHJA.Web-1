namespace Infrastructure.Models.User
{
    public class UserResponseModel
    {

  
        public string Email { get; set; }

       
        public string CustomerId { get; set; }

        
        public string SubscriptionId { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsEmailConfirmed { get; set; }
        
        public bool IsPhoneNumberConfirmed { get; set; }

        public string Role { get; set; }


    }
}
