using LAHJA.Data.UI.Models.Profile;

namespace LAHJA.Data.UI.Components.ProFileModel
{
    public class DataBuildUserProfile
    {

        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string CustomerId { get; set; }
        public string SubscriptionId { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public bool IsPhoneNumberConfirmed { get; set; }

        public string Role { get; set; }
        public Uri ImageUri { get; set; }
        public DataBuildUserSubscriptionInfo Subscription { get; set; }
        public string ImageUrl => Image;






    }

}
