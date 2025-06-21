
using AutoMapper;
using Domain.Entities.Product.Response;
 using Shared.Wrapper;
using Infrastructure.DataSource.Seeds;
using Infrastructure.Models.Product.Request;
using Infrastructure.Models.Product.Response;
using Shared.Settings;
using Infrastructure.DataSource.ApiClient.Payment;
using Domain.Entities.Product.Request;
using Infrastructure.Models.BaseFolder.Response;
using Domain.Repository.Product;
using Domain.ShareData.Base;

namespace Infrastructure.Repository.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly SeedsPlans seedsPlans;
        private readonly ProductApiClient productApiClient;
        private readonly IMapper _mapper;
        private readonly ApplicationModeService appModeService;
        public ProductRepository(
            IMapper mapper,
            SeedsPlans seedsPlans,
            ApplicationModeService appModeService,
            ProductApiClient ProductApiClient)
        {

            //seedsPlans = new SeedsPlans();
            _mapper = mapper;
            this.seedsPlans = seedsPlans;
            this.appModeService = appModeService;

            this.productApiClient = ProductApiClient;
        }


     

        public async Task<Result<List<ProductResponse>>> GetAllAsync(FilterResponseData filter)
        {
            
            var response = await ExecutorAppMode.ExecuteAsync<Result<List<ProductResponseModel>>>(
                 async () => await productApiClient.GetAllAsync(filter),
                  async () => Result<List<ProductResponseModel>>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<List<ProductResponse>>(response.Data) : null;
                return Result<List<ProductResponse>>.Success(result);
            }
            else
            {
                return Result<List<ProductResponse>>.Fail(response.Messages);
            }
        }

        public async Task<Result<List<ProductResponse>>> SearchAsync(ProductSearchRequest request)
        {
            var model = _mapper.Map<ProductSearchRequestModel>(request);
            var response = await ExecutorAppMode.ExecuteAsync<Result<List<ProductResponseModel>>>(
                 async () => await productApiClient.SearchAsync(model),
                  async () => Result<List<ProductResponseModel>>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<List<ProductResponse>>(response.Data) : null;
                return Result<List<ProductResponse>>.Success(result);
            }
            else
            {
                return Result<List<ProductResponse>>.Fail(response.Messages);
            }



        }

        public async Task<Result<ProductResponse>> CreateAsync(ProductCreate request)
        {

            var model = _mapper.Map<ProductCreateModel>(request);
            var response = await ExecutorAppMode.ExecuteAsync<Result<ProductResponseModel>>(
                 async () => await productApiClient.CreateAsync(model),
                  async () => Result<ProductResponseModel>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<ProductResponse>(response.Data) : null;
                return Result<ProductResponse>.Success(result);
            }
            else
            {
                return Result<ProductResponse>.Fail(response.Messages);
            }



        }

        public async Task<Result<ProductResponse>> UpdateAsync(ProductUpdate request)
        {


            var model = _mapper.Map<ProductUpdateModel>(request);
            var response = await ExecutorAppMode.ExecuteAsync<Result<ProductResponseModel>>(
                 async () => await productApiClient.UpdateAsync(model),
                  async () => Result<ProductResponseModel>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<ProductResponse>(response.Data) : null;
                return Result<ProductResponse>.Success(result);
            }
            else
            {
                return Result<ProductResponse>.Fail(response.Messages);
            }



        }
        public async Task<Result<DeleteResponse>> DeleteAsync(string id)
        {

            var response = await ExecutorAppMode.ExecuteAsync<Result<DeleteResponseModel>>(
                 async () => await productApiClient.DeleteAsync(id),
                  async () => Result<DeleteResponseModel>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<DeleteResponse>(response.Data) : null;
                return Result<DeleteResponse>.Success(result);
            }
            else
            {
                return Result<DeleteResponse>.Fail(response.Messages);
            }



        }

      
    } 
}
