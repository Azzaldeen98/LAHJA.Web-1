using Infrastructure.Models.User;

namespace Infrastructure.Models.Profile.Request
{
    public class ProfileRequestModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Image { get; set; }
        public bool? Active { get; set; }
    }


}
