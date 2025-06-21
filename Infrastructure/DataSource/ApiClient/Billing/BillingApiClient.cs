using AutoMapper;
 using Shared.Wrapper;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Models.Checkout.Request;
using Infrastructure.Models.Checkout.Response;
using Infrastructure.Nswag;
using Microsoft.Extensions.Configuration;
using Infrastructure.DataSource.ApiClient.Base;
using Infrastructure.Models.Billing.Response;
using Domain.Entities.Billing.Request;
using Domain.ShareData.Base;
using Infrastructure.Models.Billing.Request;
using Infrastructure.Models.BaseFolder.Response;
using Infrastructure.Middlewares;
using Infrastructure.Share.Invoker;

namespace Infrastructure.DataSource.ApiClient.Billing
{
    public class BillingApiClient : BuildApiClient<BillingApiClient>
    {


        private readonly ClientFactory _clientFactory;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public BillingApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, IApiInvoker apiSafelyHandler) 
            : base(clientFactory, mapper, config, apiSafelyHandler)
        {
        }

     
        
        public async Task<Result<BillingDetailsResponseModel>> getBillingDetailsAsync()
        {
            try
            {
        
                var client = await GetApiClient();
                var response = await client.getBillingDetailsAsync();
                //var response = await Main(model);


                //var resModel = _mapper.Map<BillingDetailsResponseModel>(response);
                return Result<BillingDetailsResponseModel>.Success();

            }
            catch (ApiException e)
            {

                return Result<BillingDetailsResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }


        public async Task<Result<List<CardDetailsResponseModel>>> getSubscriptionPaymentCardsAsync()
        {
            try
            {
                //var model = _mapper.Map<SessionCreate>(request);
                //var client = await GetApiClient();
                //var response = await client.ManageAsync(model);


                //var resModel = _mapper.Map<CheckoutOptionsModel>(response);
                return Result<List<CardDetailsResponseModel>>.Success();

            }
            catch (ApiException e)
            {

                return Result<List<CardDetailsResponseModel>>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }

        public async Task<Result<BillingDetailsResponseModel>> CreateBillingAsync(BillingDetailsRequestModel request) { throw new NotImplementedException(); }
        public async Task<Result<DeleteResponseModel>> DeleteBillingAsync(string id) { throw new NotImplementedException();}
        public async Task<Result<BillingDetailsResponseModel>> UpdateBillingAsync(BillingDetailsRequestModel request) { throw new NotImplementedException(); }

        public async Task<Result<CardDetailsResponseModel>> CreateCardAsync(CardDetailsRequestModel request) { throw new NotImplementedException(); }
        public async Task<Result<DeleteResponseModel>> DeleteCardAsync(string id) { throw new NotImplementedException(); }
        public async Task<Result<CardDetailsResponseModel>> UpdateCardAsync(CardDetailsRequestModel request) { throw new NotImplementedException(); }

    }
}
