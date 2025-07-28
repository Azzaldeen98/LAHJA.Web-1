using AutoGenerator.Attributes;
using AutoGenerator.Enums;
using Domain.Entities.Request.Request;
using Shared.Interfaces;

namespace Domain.Entity
{


    [AutomateMapperWith(LayersModels.DTO, "ApplicationUser", "ApplicationUserUpdateVM", "ApplicationUserCreateVM")]
    public partial class User : ITDso
    {
      
        public string CustomerId { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string DisplayName { get; set; }


        public string ProfileUrl { get; set; }


        public string Image { get; set; }


        public bool IsArchived { get; set; }


        public DateTimeOffset? ArchivedDate { get; set; }


        public string LastLoginIp { get; set; }

        public DateTimeOffset? LastLoginDate { get; set; }


        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public string SubscriptionId { get; set; }


        public Subscription Subscription { get; set; }


        public ICollection<UserModelAi> UserModelAis { get; set; }

        public ICollection<UserService> UserServices { get; set; }


        public string Id { get; set; }

        public string UserName { get; set; }


        public string NormalizedUserName { get; set; }


        public string Email { get; set; }


        public string NormalizedEmail { get; set; }


        public bool EmailConfirmed { get; set; }


        public string PhoneNumber { get; set; }


        public bool PhoneNumberConfirmed { get; set; }

        public ICollection<Request> Requests { get; set; }
        public bool TwoFactorEnabled { get; set; }


        public DateTimeOffset? LockoutEnd { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }
    }
}
