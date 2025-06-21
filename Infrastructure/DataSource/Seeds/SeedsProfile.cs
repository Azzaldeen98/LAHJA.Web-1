using AutoMapper;
using Domain.ShareData;
using Infrastructure.DataSource.Seeds.Models;
using Infrastructure.Models.Billing.Response;
using Infrastructure.Models.Profile.Response;

namespace Infrastructure.DataSource.Seeds
{
    public class SeedsProfile
    {
        //private readonly IMapper _mapper;
        //private readonly SeedsUsers seedsUsers;
        //private readonly SeedsBillings seedsBillings;
        //private readonly SeedsCreditCards seedsCreditCards;
        //private readonly SeedsPlans seedsPlans;
        //private readonly ISessionUserManager _sessionUserManager;
        //private readonly List<UserApp> userDb;


        public SeedsProfile(
            //IMapper mapper,
            //SeedsUsers seedsUsers,
            //SeedsBillings seedsBillings,
            //SeedsCreditCards seedsCreditCards,
            //SeedsPlans seedsPlans,
            //ISessionUserManager sessionUserManager
            )
        {
            //_mapper = mapper;
            //this.seedsUsers = seedsUsers;
            //userDb = seedsUsers.Db;
            //this.seedsBillings = seedsBillings;
            //this.seedsCreditCards = seedsCreditCards;
            //this.seedsPlans = seedsPlans;
            //_sessionUserManager = sessionUserManager;
        }

        public async Task<ProfileResponseModel> getProfileAsync()
        {
            //var email =await _sessionUserManager.GetEmailAsync();
            //if (email != null)
            //{
            //    var billing = seedsBillings.GetBillingDetailsByEmail(email);
            //    var cards = seedsCreditCards.GetCardDetailsByEmail(email);
            //    //var cards = seedsUsers .GetCardDetailsByEmail(email);
      
            //    var bilRes = _mapper.Map<BillingDetailsResponseModel>(billing);


            //    return new ProfileResponseModel
            //    {
            //        BillingDetails = bilRes,
            //    };
            //}

            return new ProfileResponseModel();

        }


    }
}
