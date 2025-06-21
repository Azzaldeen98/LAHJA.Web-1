
using AutoMapper;
 using Shared.Wrapper;
using Infrastructure.DataSource.Seeds;

using Shared.Settings;
using Infrastructure.DataSource.ApiClient.Payment;

using Domain.ShareData.Base;
using Domain.Repository.Subscriptions;
using Domain.Entities.Subscriptions.Response;
using Infrastructure.Models.Subscriptions.Request;
using Infrastructure.Models.Subscriptions.Response;
using Domain.Entities.Subscriptions.Request;
using Infrastructure.DataSource.Seeds.Models;
using Domain.ShareData;
using Infrastructure.DataSource.ApiClient.Profile;


namespace Infrastructure.Repository.Subscription
{

    public class SubscriptionsRepository : ISubscriptionsRepository
    {
        private readonly ProfileApiClient profileApiClient;
        private readonly SeedsSubscriptionsPlans seedsPlans;
        private readonly SeedsSubscriptionsData seedsSubscriptionsData;
        private readonly SubscriptionsApiClient subscriptionApiClient;
        private readonly IMapper _mapper;
        private readonly ISessionUserManager _sessionUserManager;
        private readonly ApplicationModeService appModeService;
        public SubscriptionsRepository(
            IMapper mapper,
            SeedsSubscriptionsPlans seedsPlans,
            ApplicationModeService appModeService,
            SubscriptionsApiClient subscriptionApiClient,
            SeedsSubscriptionsData seedsSubscriptionsData,
            ISessionUserManager sessionUserManager,
            ProfileApiClient profileApiClient)
        {

            //seedsPlans = new SeedsPlans();
            _mapper = mapper;
            this.seedsPlans = seedsPlans;
            this.appModeService = appModeService;

            this.subscriptionApiClient = subscriptionApiClient;
            this.seedsSubscriptionsData = seedsSubscriptionsData;
            _sessionUserManager = sessionUserManager;
            this.profileApiClient = profileApiClient;
        }
        public async Task<Result<bool>> HasActiveSubscriptionAsync()
        {

            try
            {
                var subscriptions = await profileApiClient.SubscriptionsAsync();
                if (subscriptions != null)
                {
                    if (subscriptions != null && subscriptions?.Any() == true)
                    {
                        var result = subscriptions.Any(x => x.Status?.ToLower() == "active");
                        return Result<bool>.Success(result);
                    }

                    return Result<bool>.Success(false);
                }
                else
                {
                    return Result<bool>.Fail("not found");
                }

            }
            catch (Exception e)
            {
                return Result<bool>.Fail(e.Message);
            }


        }
        public async Task<Result<SubscriptionResponse>> GetUserActiveSubscriptionAsync()
        {

            try
            {
                var subscriptions = await profileApiClient.SubscriptionsAsync();
                if (subscriptions != null)
                {
                    if (subscriptions != null && subscriptions?.Any() == true)
                    {
                        var result = subscriptions.FirstOrDefault(x => x.Status?.ToLower() == "active");
                        if (result != null)
                        {
                            var sub = _mapper.Map<SubscriptionResponse>(result);
                            return Result<SubscriptionResponse>.Success(sub);
                        }
                    }

            
                }
              
                return Result<SubscriptionResponse>.Fail("not found");
                

            }
            catch (Exception e)
            {
                return Result<SubscriptionResponse>.Fail(e.Message);
            }


            //var response = await ExecutorAppMode.ExecuteAsync<Result<List<SubscriptionResponseModel>>>(
            //    async () => await subscriptionApiClient.getAllAsync(),
            //     async () => {
            //         var email = await _sessionUserManager.GetEmailAsync();
            //         if (email == null)
            //             return Result<List<SubscriptionResponseModel>>.Fail();

            //         var data = seedsSubscriptionsData.getActiveSubscriptions(email);
            //         if (data != null)
            //         {
            //             var items = _mapper.Map<List<SubscriptionResponseModel>>(data);
            //             return Result<List<SubscriptionResponseModel>>.Success(items);
            //         }


            //         return Result<List<SubscriptionResponseModel>>.Fail();
            //     });
            //if (response.Succeeded)
            //{

            //    var subscriptions = response.Data;
            //    if (subscriptions != null && subscriptions?.Any() == true)
            //    {
            //        var result = subscriptions.FirstOrDefault(x => x.Status?.ToLower() == "active");
            //        if (result != null)
            //        {
            //           var sub= _mapper.Map<SubscriptionResponse>(result);
            //          return Result<SubscriptionResponse>.Success(sub);
            //        }
                   
            //    }

            //    return Result<SubscriptionResponse>.Fail("No found");
            //}
            //else
            //{
            //    return Result<SubscriptionResponse>.Fail(response?.Messages?.Any()==true? response?.Messages[0]?? "Error" : "Error");
            //}
        }

        public async Task<Result<SubscriptionResponse>> GetSubscriptionAsync(FilterResponseData filter)
        {
    
                var response = await ExecutorAppMode.ExecuteAsync<SubscriptionResponseModel>(
                async () => await subscriptionApiClient.GetSubscriptionAsync(filter),
                 async () => await subscriptionApiClient.GetSubscriptionAsync(filter));

            
                if (response != null)
                {
                    var sub = _mapper.Map<SubscriptionResponse>(response);
                    return Result<SubscriptionResponse>.Success(sub);
                }

                return Result<SubscriptionResponse>.Fail("not found");



        }
        //public async Task<Result<bool>> HasActiveSubscriptionAsync()
        //{
        //    var response = await ExecutorAppMode.ExecuteAsync<Result<List<SubscriptionResponseModel>>>(
        //         async () => await subscriptionApiClient.getAllAsync(),
        //          async () => {

        //              return await subscriptionApiClient.getAllAsync();
        //              //var email = await _sessionUserManager.GetEmailAsync();
        //              //if (email == null)
        //              //    return Result<List<SubscriptionResponseModel>>.Fail();

        //              //var data = seedsSubscriptionsData.getActiveSubscriptions(email);
        //              //if(data != null)
        //              //{
        //              //    var items=_mapper.Map<List<SubscriptionResponseModel>>(data);
        //              //    return Result<List<SubscriptionResponseModel>>.Success(items);
        //              //}


        //              //return Result<List<SubscriptionResponseModel>>.Fail();
        //          });

        //    if (response.Succeeded)
        //    {

        //        var subscriptions = response.Data;
        //        if (subscriptions != null && subscriptions?.Any() == true)
        //        {
        //            var result= subscriptions.Any(x => x.Status?.ToLower() == "active");
        //            return Result<bool>.Success(result);
        //        }

        //        return Result<bool>.Success(false);
        //    }
        //    else
        //    {
        //        return Result<bool>.Fail(response?.Messages?.Any() == true ? response?.Messages[0] ?? "Error" : "Error");
        //    }


        //}
        public async Task<Result<List<SubscriptionResponse>>> getAllAsync()
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<List<SubscriptionResponseModel>>>(
                 async () => await subscriptionApiClient.getAllAsync(),
                  async () => {
                      var email = await _sessionUserManager.GetEmailAsync();
                      if (email == null)
                          return Result<List<SubscriptionResponseModel>>.Fail();

                      var data = seedsSubscriptionsData.getAllUserSubscriptions(email);
                      if (data != null)
                      {
                          var items = _mapper.Map<List<SubscriptionResponseModel>>(data);
                          return Result<List<SubscriptionResponseModel>>.Success(items);
                      }


                      return Result<List<SubscriptionResponseModel>>.Fail();
                  });

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<List<SubscriptionResponse>>(response.Data) : null;
                return Result<List<SubscriptionResponse>>.Success(result);
            }
            else
            {
                return Result<List<SubscriptionResponse>>.Fail(response.Messages);
            }


        }

        public async Task<Result<SubscriptionResponse>> PauseAsync(string id)
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<SubscriptionResponseModel>>(
                 async () => await subscriptionApiClient.PauseAsync(id),
                  async () => Result<SubscriptionResponseModel>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<SubscriptionResponse>(response.Data) : null;
                return Result<SubscriptionResponse>.Success(result);
            }
            else
            {
                return Result<SubscriptionResponse>.Fail(response.Messages);
            }



        }

        public async Task<SubscriptionCreateResponse> CreateAsync(SubscriptionCreate request)
        {
            var smodel=_mapper.Map<SubscriptionCreateModel>(request);
            var response = await ExecutorAppMode.ExecuteAsync(
                  async () => await subscriptionApiClient.CreateSubscriptionAsync(smodel),
                  async () =>
                  {
                      return await subscriptionApiClient.CreateSubscriptionAsync(smodel);
                      //var email = await _sessionUserManager.GetEmailAsync();
                      //if(email == null)
                      //    return Result<SubscriptionResponseModel>.Fail();

                      //var plan= seedsPlans.getOne(request.PlanId);
                      //if (plan == null)
                      //    return Result<SubscriptionResponseModel>.Fail();

                      //var model=_mapper.Map<SubscriptionModel>(request);
                      //model.UserId = email;
                      //model.PlanId = plan.Id;
                      //model.SubscriptionPlan = plan;
                      //model.SubscriptionPlan.Active = true; 
                      //model.StartDate = DateTime.Now;
                      //model.CancelAtPeriodEnd = true;

                      //seedsSubscriptionsData.AddSubscription(model);
                      //var res = seedsSubscriptionsData.SearchSubscriptions(x => x.UserId == email).FirstOrDefault();
                      //if (res != null)
                      //{
                      //    var data = _mapper.Map<SubscriptionResponseModel>(res);
                      //    return Result<SubscriptionResponseModel>.Success(data);
                      //}
                      //return Result<SubscriptionResponseModel>.Fail();
                  });

            return _mapper.Map<SubscriptionCreateResponse>(response);

            //if (response.Succeeded)
            //{
            //    var result = (response.Data != null) ? _mapper.Map<SubscriptionCreateResponse>(response) : null;
            //    return Result<SubscriptionResponse>.Success(result);
            //}
            //else
            //{
            //    return Result<SubscriptionResponse>.Fail(response.Messages);
            //}
        }
        public async Task<Result<SubscriptionResponse>> ResumeAsync(string id)
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<SubscriptionResponseModel>>(
                 async () => await subscriptionApiClient.ResumeAsync(id),
                  async () => Result<SubscriptionResponseModel>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<SubscriptionResponse>(response.Data) : null;
                return Result<SubscriptionResponse>.Success(result);
            }
            else
            {
                return Result<SubscriptionResponse>.Fail(response.Messages);
            }

        }

        public async Task<Result<DeleteResponse>> DeleteAsync(string id)
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<SubscriptionResponseModel>>(
                 async () => await subscriptionApiClient.DeleteAsync(id),
                  async () => Result<SubscriptionResponseModel>.Success());

            if (response.Succeeded)
            {
                //var result = (response.Data != null) ? _mapper.Map<DeleteResponse>(response.Data) : null;
                return Result<DeleteResponse>.Success();
            }
            else
            {
                return Result<DeleteResponse>.Fail(response.Messages);
            }
        }

        public async Task<Result<SubscriptionResponse>> UpdateAsync(SubscriptionRequest request)
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<SubscriptionResponseModel>>(
                   async () => Result<SubscriptionResponseModel>.Success(),
                   async () =>
                   {
                       var email = await _sessionUserManager.GetEmailAsync();
                       if (email == null)
                           return Result<SubscriptionResponseModel>.Fail();

                       var plan = seedsPlans.getOne(request.PlanId);
                       if (plan == null)
                           return Result<SubscriptionResponseModel>.Fail();

                       var model = _mapper.Map<SubscriptionModel>(request);
                       model.UserId = email;
                       model.PlanId = plan.Id;
                       model.SubscriptionPlan = plan;
                       model.StartDate = DateTime.Now;
                       model.CancelAtPeriodEnd = true;

                       if (seedsSubscriptionsData.UpdateSubscription(model.Id, model))
                       {
                           var res= seedsSubscriptionsData.SearchSubscriptions(x=>x.UserId==email).FirstOrDefault();
                           if (res != null)
                           {
                               var data=_mapper.Map<SubscriptionResponseModel>(res);
                               return Result<SubscriptionResponseModel>.Success(data);
                           }
                              
                       }
                            
                       
                       return Result<SubscriptionResponseModel>.Fail();
                   });

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<SubscriptionResponse>(response.Data) : null;
                return Result<SubscriptionResponse>.Success(result);
            }
            else
            {
                return Result<SubscriptionResponse>.Fail(response.Messages);
            }
        }

      
    } 
}
