using AutoMapper;
using Domain.Exceptions;
using Domain.ShareData.Base;
 using Shared.Wrapper;
using Infrastructure.DataSource.ApiClient.Base;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Middlewares;
using Infrastructure.Models.Subscriptions.Request;
using Infrastructure.Models.Subscriptions.Response;
using Infrastructure.Nswag;
using Infrastructure.Share.Invoker;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DataSource.ApiClient.Payment
{
    public class SubscriptionsApiClient : BuildApiClient<SubscriptionClient>
    {
      

        public SubscriptionsApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, 
            IApiInvoker apiSafelyHandler) : base(clientFactory, mapper, config,apiSafelyHandler)
        {
           
        }

    
   
        public async Task<Result<List<SubscriptionResponseModel>>> getAllAsync()
        {
            return await apiSafelyHandler.InvokeAsync(async () =>
            {
                //var model = _mapper.Map<CheckoutOptions>(request);
                var client = await GetApiClient();
                var response = await client.GetSubscriptionsAsync();

                var resModel = _mapper.Map<List<SubscriptionResponseModel>>(response);
                return Result<List<SubscriptionResponseModel>>.Success(resModel);

            });



        }
        public async Task<SubscriptionCreateResponseModel> CreateSubscriptionAsync(SubscriptionCreateModel request)
        {
            return await apiSafelyHandler.InvokeAsync(async () => 
            {
                    //var model = _mapper.Map<Nswag.SubscriptionCreateVM>(request);
                    //var client = await GetApiClient();

                    //var response = await client.Cr(model);

                    //var resModel = _mapper.Map<SubscriptionCreateResponseModel>(response);
                    return new SubscriptionCreateResponseModel();

            });
            
        }
        public async Task<Result<SubscriptionResponseModel>> PauseAsync(string id)
        {

                return await apiSafelyHandler.InvokeAsync(async () => {
                 var model= new SubscriptionUpdateRequest();
                var client = await GetApiClient();
                await client.PauseCollection2Async(id, model);
                return Result<SubscriptionResponseModel>.Success();

            });

       


        }
        public async Task<SubscriptionResponseModel> GetSubscriptionAsync(FilterResponseData filter)
        {
   
                return await apiSafelyHandler.InvokeAsync(async () =>
                {
                    var client = await GetApiClient();

                     var response = await client.GetSubscriptionAsync(filter.Id);

                    var resModel = _mapper.Map<SubscriptionResponseModel>(response);
                    return resModel;
                });

           



        }
        public async Task<Result<SubscriptionResponseModel>> ResumeAsync(string id)
        {
            return await apiSafelyHandler.InvokeAsync(async () =>
            {
                var model = _mapper.Map<SubscriptionResumeRequest>(new SubscriptionResumeRequestModel { ProrationBehavior = "create_prorations" });
                var client = await GetApiClient();
                await client.ResumeAsync(id, model);


                //var resModel = _mapper.Map<SubscriptionResponseModel>(response);
                return Result<SubscriptionResponseModel>.Success();

            });



        }

        public async Task<Result<SubscriptionResponseModel>> CancelAsync(string id)
        {
            return await apiSafelyHandler.InvokeAsync(async () =>
            {

                var client = await GetApiClient();
                 await client.CancelSubscriptionAsync();


                //var resModel = _mapper.Map<SubscriptionResponseModel>(response);
                return Result<SubscriptionResponseModel>.Success();

            });



        }

        public async Task<Result<SubscriptionResponseModel>> DeleteAsync(string id)
        {
            return await apiSafelyHandler.InvokeAsync(async () =>
            {

                var client = await GetApiClient();
                await client.CancelAtEnd2Async(id);
                //var resModel = _mapper.Map<SubscriptionResponseModel>(response);
                return Result<SubscriptionResponseModel>.Success();

            });


        }

    }
}
