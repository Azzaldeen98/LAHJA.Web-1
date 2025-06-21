using AutoMapper;
using Domain.Entities.Billing.Response;
using Domain.Entities.Plans.Response;
using Domain.Entities.Profile;
using Domain.Entities.Profile.Request;
using Domain.Entities.Profile.Response;
using Domain.Entities.Request.Response;
using Domain.Entities.Subscriptions.Response;
using Domain.Repository.Profile;
using Domain.ShareData;
 using Shared.Wrapper;
using Infrastructure.DataSource.ApiClient.Plans;
using Infrastructure.DataSource.ApiClient.Profile;
using Infrastructure.DataSource.Seeds;
using Infrastructure.Models.Billing.Request;
using Infrastructure.Models.Billing.Response;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Profile.Response;
using Shared.Helpers;
using Shared.Settings;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class ProfileRepository :IProfileRepository
{

    private readonly SeedsProfile seedsProfile;
    private readonly SeedsUsers seedsUsers;
    private readonly SeedsBillings seedsBillings;
    private readonly SeedsCreditCards seedsCreditCards;
    private readonly SeedsSubscriptionsData seedsSubscriptionsData;
    private readonly SeedsPlans seedsPlans;

    private readonly ProfileApiClient profileApiClient;
    private readonly ISessionUserManager _sessionUserManager;
    private readonly IMapper _mapper;
    private readonly ApplicationModeService appModeService;

	public ProfileRepository(SeedsProfile seedsProfile,
							 ProfileApiClient profileApiClient,
							IMapper mapper,
							ApplicationModeService appModeService,
							ISessionUserManager sessionUserManager,
							SeedsUsers seedsUsers,
							SeedsBillings seedsBillings,
							SeedsCreditCards seedsCreditCards,
							SeedsPlans seedsPlans,
							SeedsSubscriptionsData seedsSubscriptionsData)
	{
		this.seedsProfile = seedsProfile;
		this.profileApiClient = profileApiClient;
		_mapper = mapper;
		this.appModeService = appModeService;
		this._sessionUserManager = sessionUserManager;
		this.seedsUsers = seedsUsers;
		this.seedsBillings = seedsBillings;
		this.seedsCreditCards = seedsCreditCards;
		this.seedsPlans = seedsPlans;
		this.seedsSubscriptionsData = seedsSubscriptionsData;
	}

	public Task<Result<ProfileResponse>> CreateProfileAsync(ProfileRequest profileRequest)
    {
        throw new NotImplementedException();
    }

    public Task<Result<bool>> DeleteProfileAsync(string profileId)
    {
        throw new NotImplementedException();
    }
    public async Task<Result<ProfileUserResponse>> UpdateProfileUserAsync(ProfileUserRequest request)
    {
       return await ExecutorAppMode.ExecuteAsync(
           async () => await profileApiClient.UpdateProfileUserAsync(request),
          async () => Result<ProfileUserResponse>.Success());
    }

    public async Task<Result<ProfileUserResponse>> GetProfileUserAsync()
    {
        var response = await ExecutorAppMode.ExecuteAsync<Result<ProfileUserResponse>>(
             async () => await profileApiClient.GetProfileUserAsync(),
              async () => {
                  try
                  {
                      var email = await _sessionUserManager.GetEmailAsync();
                      if (email != null)
                      {
                          //var billing = seedsBillings.GetBillingDetailsByEmail(email);
                          //var cards = seedsCreditCards.GetCardDetailsByEmail(email);
                          var user = await seedsUsers.getUserByEmailAsync(email);
                          var subscriptionsPlans = seedsSubscriptionsData.getActiveSubscriptions(email);


                          //var bilRes = _mapper.Map<BillingDetailsResponseModel>(billing);
                          //var billingData = _mapper.Map<BillingDetailsResponse>(bilRes);

                          //var cardsRes = _mapper.Map<List<CardDetailsResponseModel>>(cards);
                          var subscriptionsPlansRes = _mapper.Map<List<SubscriptionResponse>>(subscriptionsPlans);
                          //var cardsData = _mapper.Map<List<CardDetailsResponse>>(cardsRes);

                          if (user != null)
                          {
                              var profile = new ProfileUserResponse
                              {
                                  DisplayName = user?.Name ?? "",
                                  Email = user?.Email ?? "",
                                  PhoneNumber = user?.PhoneNumber ?? "",
                                  Image = user?.Image ?? "",
                            
                                  Subscription = new(),// subscriptionsPlansRes?.Count()>0? subscriptionsPlansRes.FirstOrDefault():null,
                              };
                              return Result<ProfileUserResponse>.Success(profile);
                          }

                      }

                      return Result<ProfileUserResponse>.Success();
                  }
                  catch (Exception e)
                  {
                      return Result<ProfileUserResponse>.Fail(e.Message);
                  }


              });

        return response;
    }
    public async Task<Result<ProfileResponse>> getProfileAsync()
    {

        var response = await ExecutorAppMode.ExecuteAsync<Result<ProfileResponse>>(
             async () => Result<ProfileResponse>.Success(),//await profileApiClient.getProfileAsync(),
              async () =>
              {

                  try
                  {
                      var email = await _sessionUserManager.GetEmailAsync();
                      if (email != null)
                      {
                          var billing = seedsBillings.GetBillingDetailsByEmail(email);
                          var cards = seedsCreditCards.GetCardDetailsByEmail(email);
                          var user = await seedsUsers.getUserByEmailAsync(email);
                          var subscriptionsPlans =  seedsSubscriptionsData.getActiveSubscriptions(email);


                          var bilRes = _mapper.Map<BillingDetailsResponseModel>(billing);
                          var billingData = _mapper.Map<BillingDetailsResponse>(bilRes);

                          var cardsRes = _mapper.Map<List<CardDetailsResponseModel>>(cards);
                          var subscriptionsPlansRes = _mapper.Map<List<SubscriptionResponse>>(subscriptionsPlans);
                          var cardsData = _mapper.Map<List<CardDetailsResponse>>(cardsRes);

                          if (user != null)
                          {
                              var profile = new ProfileResponse
                              {
                                  Name = user?.Name ?? "",
                                  Email = user?.Email ?? "",
                                  PhoneNumber = user?.PhoneNumber ?? "",
                                  Image = user?.Image ?? "",
                                  Active = user?.Active,
                                  CreditCards = cardsData,
                                  BillingDetails = billingData,
                                  Subscriptions = subscriptionsPlansRes,
                              };
                              return Result<ProfileResponse>.Success(profile);
                          }

                      }

                      return Result<ProfileResponse>.Success();
                  }
                  catch(Exception e)
                  {
                      return Result<ProfileResponse>.Fail(e.Message);
                  }

                      
              });

        if (response.Succeeded)
        {
            var result = (response.Data != null) ? _mapper.Map<ProfileResponse>(response.Data) : null;
            return Result<ProfileResponse>.Success(result);
        }
        else
        {
            return Result<ProfileResponse>.Fail(response.Messages);
        }
    }

    public Task<Result<ProfileResponse>> UpdateProfileAsync(ProfileRequest profileRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<ProfileSubscriptionResponse>> SubscriptionsAsync()
    {

        var response = await profileApiClient.SubscriptionsAsync();
        return response;

    }

    public async Task<ICollection<ProfileModelAiResponse>> ModelAisAsync()
    {
      

        var response = await profileApiClient.ModelAisAsync();
        return response;

    }

    public async Task<ICollection<ProfileServiceResponse>> ServicesAsync()
    {
      

        var response = await profileApiClient.ServicesAsync();
        return response;


    }

    public async Task<ICollection<ProfileServiceResponse>> ServicesModelAiAsync(string modelAiId)
    {
  

        var response = await profileApiClient.ServicesModelAiAsync(modelAiId);
        return response;


    }

    public async Task<ICollection<ProfileSpaceResponse>> SpacesSubscriptionAsync(string subscriptionId)
    {

        var response = await profileApiClient.SpacesSubscriptionAsync(subscriptionId);
        return response;

    }


    public async Task<ProfileSpaceResponse> SpaceSubscriptionAsync(string subscriptionId, string spaceId)
    {
    

        var response = await profileApiClient.SpaceSubscriptionAsync(subscriptionId, spaceId);
        return response;

    }



    public async Task<List<RequestResponse>> RequestsServiceAsync(string serviceId)
    {
        
        var response = await profileApiClient.RequestsServiceAsync(serviceId);
        return _mapper.Map<List<RequestResponse>>(response);

    }

}
