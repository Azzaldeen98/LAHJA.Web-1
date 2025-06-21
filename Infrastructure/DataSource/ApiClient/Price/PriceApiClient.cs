using AutoMapper;
 using Shared.Wrapper;
using Infrastructure.DataSource.ApiClient.Base;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Middlewares;
using Infrastructure.Models.BaseFolder.Response;
using Infrastructure.Models.Price.Request;
using Infrastructure.Models.Price.Response;
using Infrastructure.Nswag;
using Infrastructure.Share.Invoker;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DataSource.ApiClient.Payment
{
    public class PriceApiClient: BuildApiClient<PriceClient>
    {

        public PriceApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, IApiInvoker apiSafelyHandler) 
            : base(clientFactory, mapper, config, apiSafelyHandler)
        {
        }

    
        public async Task<Result<PriceResponseModel>> getAsync(string id)
        {
            try
            {
                //var model = _mapper.Map<CheckoutOptions>(request);
                var client = await GetApiClient();
                
                var response = await client.GetPriceAsync(id);


                var resModel = _mapper.Map<PriceResponseModel>(response);
                return Result<PriceResponseModel>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<PriceResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }
        public async Task<Result<List<PriceResponseModel>>> getAllAsync(string productId, bool? active)
        {
            try
            {
                //var model = _mapper.Map<CheckoutOptions>(request);
                var client = await GetApiClient();
                var response = await client.GetPricesAsync(productId,  active);


                var resModel = _mapper.Map<List<PriceResponseModel>>(response);
                return Result<List<PriceResponseModel>>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<List<PriceResponseModel>>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }


        /// <summary>
        /// TODO \\  add return type to SearchAsync
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<Result<List<PriceResponseModel>>> SearchAsync(PriceSearchOptionsRequestModel requestModel)
        {
            try
            {
                var model = _mapper.Map<PriceSearchOptions>(requestModel);
                var client = await GetApiClient();
                 await client.SearchAsync(model);


                //var resModel = _mapper.Map<List<PriceResponseModel>>(response);
                //return Result<List<PriceResponseModel>>.Success(resModel);

                return Result<List<PriceResponseModel>>.Fail("The service is still under development From  Api !! ");

            }
            catch (ApiException e)
            {

                return Result<List<PriceResponseModel>>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }  
        
        public async Task<Result<PriceResponseModel>> CreateAsync(PriceCreateRequestModel request)
        {
            try
            {
                var model = _mapper.Map<PriceCreate>(request);
                var client = await GetApiClient();
                var response = await client.CreatePriceAsync(model);


                var resModel = _mapper.Map<PriceResponseModel>(response);
                return Result<PriceResponseModel>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<PriceResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }

        public async Task<Result<PriceResponseModel>> UpdateAsync(PriceUpdateRequestModel request)
        {
            try
            {
                var model = _mapper.Map<PriceUpdate>(request);
                var client = await GetApiClient();
                var response = await client.UpdatePriceAsync(request.Id,model);


                var resModel = _mapper.Map<PriceResponseModel>(response);
                return Result<PriceResponseModel>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<PriceResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }

        /// <summary>
        /// TODO :// Add Delete Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<DeleteResponseModel>> DeleteAsync(string id)
        {
            try
            {
                //var model = _mapper.Map<ProductCreate>(request);
                var client = await GetApiClient();
                //var response = await client.(id);


                //var resModel = _mapper.Map<DeleteResponseModel>(response);
                //return Result<DeleteResponseModel>.Success(resodel);
                return Result<DeleteResponseModel>.Fail("The service is still under development From  Api !! ");

            }
            catch (ApiException e)
            {

                return Result<DeleteResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }

    }
}
