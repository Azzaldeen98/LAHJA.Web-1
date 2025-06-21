
using AutoMapper;
using Domain.Entities.Event.Request;
using Domain.Entities.Event.Response;
using Domain.Entities.Request.Request;
using Domain.Entities.Request.Response;
using Domain.Entities.Service.Response;
using Domain.Repository.Request;
using Domain.ShareData;
 using Shared.Wrapper;
using Infrastructure.DataSource.ApiClient.Payment;
using Infrastructure.DataSource.Seeds;
using Infrastructure.DataSource.Seeds.Models;
using Infrastructure.Models.Request.Response;
using Infrastructure.Models.Subscriptions.Response;
using Shared.Settings;


namespace Infrastructure.Repository.Subscription
{

    public class RequestRepository : IRequestRepository
    {
        private readonly SeedsSubscriptionsPlans seedsPlans;
        private readonly SeedsSubscriptionsData seedsSubscriptionsData;
        private readonly SubscriptionsApiClient subscriptionApiClient;
        private readonly IMapper _mapper;
        private readonly ISessionUserManager _sessionUserManager;
        private readonly ApplicationModeService appModeService;
        public RequestRepository(
            IMapper mapper,
            SeedsSubscriptionsPlans seedsPlans,
            ApplicationModeService appModeService,
            SubscriptionsApiClient subscriptionApiClient,
            SeedsSubscriptionsData seedsSubscriptionsData,
            ISessionUserManager sessionUserManager)
        {

            //seedsPlans = new SeedsPlans();
            _mapper = mapper;
            this.seedsPlans = seedsPlans;
            this.appModeService = appModeService;

            this.subscriptionApiClient = subscriptionApiClient;
            this.seedsSubscriptionsData = seedsSubscriptionsData;
            _sessionUserManager = sessionUserManager;
        }

        public async Task<Result<bool>> HasActiveSubscriptionAsync()
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<SubscriptionResponseModel>>(
                 async () =>  Result<SubscriptionResponseModel>.Success(),
                  async () =>
                  {
                      var email = await _sessionUserManager.GetEmailAsync();
                      if (email == null)
                          return Result<SubscriptionResponseModel>.Fail();

                      var data = seedsSubscriptionsData.getActiveSubscription(email);
                      if (data != null)
                      {
                          var items = _mapper.Map<SubscriptionResponseModel>(data);
                          return Result<SubscriptionResponseModel>.Success(items);
                      }


                      return Result<SubscriptionResponseModel>.Fail();
                  });

            if (response.Succeeded)
            {
                return Result<bool>.Success(response.Data?.SubscriptionPlan?.NumberOfRequestsUsed < response.Data?.SubscriptionPlan?.NumberRequests);
            }
            else
            {
                return Result<bool>.Fail();
            }


        }


        public async Task<Result<RequestResponse>> CreateAsync(RequestCreate request)
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<bool>>(
                  async () => Result<bool>.Success(),
                  async () =>
                  {
                      var res =await HasActiveSubscriptionAsync();
                      if (res.Succeeded)
                      {
                          if (res.Data)
                          {
                              var email = await _sessionUserManager.GetEmailAsync();
                              if (email == null)
                                  return Result<bool>.Fail();
                              
                              seedsSubscriptionsData.CreateRequest(email, request.ServiceId);
                              return Result<bool>.Success();
                          }
                      }
                      return Result<bool>.Fail();
                      
                  });

            if (response.Succeeded)
            {
                //var result = (response.Data != null) ? _mapper.Map<SubscriptionResponse>(response.Data) : null;
                return Result<RequestResponse>.Success();
            }
            else
            {
                return Result<RequestResponse>.Fail(response.Messages);
            }
        }

        public async Task<Result<RequestAllowed>> RequestAllowedAsync(RequestCreate request)
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<RequestAllowedModel>>(
                  async () => Result<RequestAllowedModel>.Success(),
                  async () =>
                  {
                      var res = await HasActiveSubscriptionAsync();
                      if (res.Succeeded)
                      {
                          if (res.Data)
                          {
                              var email = await _sessionUserManager.GetEmailAsync();
                              if (email == null)
                                  return Result<RequestAllowedModel>.Fail();

                              seedsSubscriptionsData.CreateRequest(email, request.ServiceId);
                              return Result<RequestAllowedModel>.Success();
                          }
                      }
                      return Result<RequestAllowedModel>.Fail();
                  });

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<RequestAllowed>(response.Data) : null;
                return Result<RequestAllowed>.Success(result);
            }
            else
            {
                return Result<RequestAllowed>.Fail(response.Messages);
            }
        }

        public async Task<Result<RequestResponse>> CreateRequestAsync(RequestCreate request)
        {

            var response = await ExecutorAppMode.ExecuteAsync<Result<bool>>(
                  async () => Result<bool>.Success(),
                  async () =>
                  {
                      var res = await HasActiveSubscriptionAsync();
                      if (res.Succeeded)
                      {
                          if (res.Data)
                          {
                              var email = await _sessionUserManager.GetEmailAsync();
                              if (email == null)
                                  return Result<bool>.Fail();

                             var flag= seedsSubscriptionsData.CreateRequest(email,request.ServiceId);
                              if(flag)
                                 return Result<bool>.Success();
                          }
                      }
                      return Result<bool>.Fail();

                  });

            if (response.Succeeded)
            {
                //var result = (response.Data != null) ? _mapper.Map<SubscriptionResponse>(response.Data) : null;
                return Result<RequestResponse>.Success(new RequestResponse { Id= "12332" });
            }
            else
            {
                return Result<RequestResponse>.Fail(response.Messages);
            }
        }

        public async Task<Result<RequestResponse>> RequestAllowedAsync(string serviceId)
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<RequestResponse>>(
                   async () => Result<RequestResponse>.Success(),
                   async () =>
                   {
                       var res = await HasActiveSubscriptionAsync();
                       if (res.Succeeded)
                       {
                           if (res.Data)
                           {
                               var email = await _sessionUserManager.GetEmailAsync();
                               if (email == null)
                                   return Result<RequestResponse>.Fail();

                               seedsSubscriptionsData.CreateRequest(email, serviceId);
                               return Result<RequestResponse>.Success();
                           }
                       }
                       return Result<RequestResponse>.Fail();
                   });

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<RequestResponse>(response.Data) : null;
                return Result<RequestResponse>.Success(result);
            }
            else
            {
                return Result<RequestResponse>.Fail(response.Messages);
            }
        }

        public async Task<Result<EventResponse>> CreateEventAsync(EventRequest request)
        {
            return Result<EventResponse>.Success();
        }

        public async Task<Result<ServiceResponse>> ResultRequestAsync(ResultRequest request)
        {
            return Result<ServiceResponse>.Success();
        }
    }
}
