using AutoMapper;
 using Shared.Wrapper;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Models.Checkout.Request;
using Infrastructure.Models.Checkout.Response;
using Infrastructure.Nswag;
using Microsoft.Extensions.Configuration;
using Infrastructure.DataSource.ApiClient.Base;
using Infrastructure.Middlewares;
using Infrastructure.Share.Invoker;


namespace Infrastructure.DataSource.ApiClient.Payment
{
    public class CheckoutApiClient : BuildApiClient<CheckoutClient>
    {


        public CheckoutApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, IApiInvoker apiSafelyHandler) 
            : base(clientFactory, mapper, config, apiSafelyHandler)
        {
        }

        private async Task<CheckoutClient> GetApiClient(string token="")
        {

            var client = await _clientFactory.CreateClientWithAuthAsync<CheckoutClient>("ApiClient", token);
            return client;
        }
       
        public async Task<Result<CheckoutResponseModel>> CheckoutAsync(CheckoutRequestModel request)
        {
            try
            {
                var model = _mapper.Map<CheckoutOptions>(request);
                var client = await GetApiClient();
				var response = await client.CreateCheckoutAsync(model);

                var resModel = _mapper.Map<CheckoutResponseModel>(response);
                return Result<CheckoutResponseModel>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<CheckoutResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }


        public async Task<Result<CheckoutResponseModel>> CheckoutManageAsync(SessionCreateModel request)
        {
            try
            {
                var model = _mapper.Map<SessionCreate>(request);
                var client = await GetApiClient();
                var response = await client.ManageAsync(model);


                var resModel = _mapper.Map<CheckoutResponseModel>(response);
                return Result<CheckoutResponseModel>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<CheckoutResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }

    }
}
