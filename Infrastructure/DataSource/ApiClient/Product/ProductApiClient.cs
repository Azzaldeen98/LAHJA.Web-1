using AutoMapper;
using Domain.ShareData.Base;
 using Shared.Wrapper;
using Infrastructure.DataSource.ApiClient.Base;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Middlewares;
using Infrastructure.Models.BaseFolder.Response;
using Infrastructure.Models.Product.Request;
using Infrastructure.Models.Product.Response;
using Infrastructure.Nswag;
using Infrastructure.Share.Invoker;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DataSource.ApiClient.Payment
{
    public class ProductApiClient: BuildApiClient<ProductClient>
    {

        public ProductApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, IApiInvoker apiSafelyHandler) : base(clientFactory, mapper, config,apiSafelyHandler)
        {
        }

    
        public async Task<Result<List<ProductResponseModel>>> SearchAsync(ProductSearchRequestModel request)
        {
            try
            {
                //var model = _mapper.Map<CheckoutOptions>(request);
                var client = await GetApiClient();
                
                var response = await client.SearchAllAsync(request.query, request.limit, request.page);


                var resModel = _mapper.Map<List<ProductResponseModel>>(response);
                return Result<List<ProductResponseModel>>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<List<ProductResponseModel>>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }
        public async Task<Result<List<ProductResponseModel>>> GetAllAsync(FilterResponseData filter)
        {
            try
            {
                //var model = _mapper.Map<CheckoutOptions>(request);
                var client = await GetApiClient();
                var response = await client.GetProductsAsync(filter.StartingAfter, filter.EndingBefore, filter.Limit);


                var resModel = _mapper.Map<List<ProductResponseModel>>(response);
                return Result<List<ProductResponseModel>>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<List<ProductResponseModel>>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }  
        
        public async Task<Result<ProductResponseModel>> UpdateAsync(ProductUpdateModel request)
        {
            try
            {
                var model = _mapper.Map<ProductUpdate>(request);
                var client = await GetApiClient();
                var response = await client.UpdateProductAsync(request.Id,model);


                var resModel = _mapper.Map<ProductResponseModel>(response);
                return Result<ProductResponseModel>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<ProductResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }

        public async Task<Result<ProductResponseModel>> CreateAsync(ProductCreateModel request)
        {
            try
            {
                var model = _mapper.Map<ProductCreate>(request);
                var client = await GetApiClient();
                var response = await client.CreateProductAsync(model);


                var resModel = _mapper.Map<ProductResponseModel>(response);
                return Result<ProductResponseModel>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<ProductResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }

        public async Task<Result<DeleteResponseModel>> DeleteAsync(string id)
        {
            try
            {
                //var model = _mapper.Map<ProductCreate>(request);
                var client = await GetApiClient();
               await client.DeleteProductAsync(id);


                //var resModel = _mapper.Map<DeleteResponseModel>(response);
                return Result<DeleteResponseModel>.Success();

            }
            catch (ApiException e)
            {

                return Result<DeleteResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }

    }
}
