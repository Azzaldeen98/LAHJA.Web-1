using Domain.Entities.BaseModels;
using Domain.Entities.Plans.Response;
using Infrastructure.DataSource.Seeds.Models;
using Infrastructure.Models.Billing.Response;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Plans.Response;
using Infrastructure.Models.User;
using Shared.BaseModels;

namespace Infrastructure.Models.Profile.Response
{
    public class ProfileResponseModel : BaseProfile
    {
        //public UserModel?  User { get; set; }
        public BillingDetailsResponseModel?  BillingDetails { get; set; }
        public IEnumerable<UserSubscriptionPlanModel>? SubscriptionsPlans { get; set; }
        public IEnumerable<CardDetailsResponseModel>?  CreditCards { get; set; }

    }
}
