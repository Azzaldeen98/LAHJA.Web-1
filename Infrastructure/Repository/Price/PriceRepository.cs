
using AutoMapper;
using Domain.Entities.Price.Response;
 using Shared.Wrapper;
using Infrastructure.DataSource.Seeds;
using Infrastructure.Models.Price.Request;
using Infrastructure.Models.Price.Response;
using Shared.Settings;
using Infrastructure.DataSource.ApiClient.Payment;
using Domain.Entities.Price.Request;
using Infrastructure.Models.BaseFolder.Response;
using Domain.Repository.Price;
using Domain.ShareData.Base;

namespace Infrastructure.Repository.Price
{
    public class PriceRepository : IPriceRepository
    {
        private readonly SeedsPlans seedsPlans;
        private readonly PriceApiClient priceApiClient;
        private readonly IMapper _mapper;
        private readonly ApplicationModeService appModeService;
        public PriceRepository(
            IMapper mapper,
            SeedsPlans seedsPlans,
            ApplicationModeService appModeService,
            PriceApiClient PriceApiClient)
        {

            //seedsPlans = new SeedsPlans();
            _mapper = mapper;
            this.seedsPlans = seedsPlans;
            this.appModeService = appModeService;

            this.priceApiClient = PriceApiClient;
        }

        
        public async Task<Result<List<PriceResponse>>> SearchAsync(PriceSearchOptionsRequest request)
        {
            var model = _mapper.Map<PriceSearchOptionsRequestModel>(request);
            var response = await ExecutorAppMode.ExecuteAsync<Result<List<PriceResponseModel>>>(
                 async () => await priceApiClient.SearchAsync(model),
                  async () => Result<List<PriceResponseModel>>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<List<PriceResponse>>(response.Data) : null;
                return Result<List<PriceResponse>>.Success(result);
            }
            else
            {
                return Result<List<PriceResponse>>.Fail(response.Messages);
            }



        }

        public async Task<Result<PriceResponse>> CreateAsync(PriceCreate request)
        {

            var model = _mapper.Map<PriceCreateRequestModel>(request);
            var response = await ExecutorAppMode.ExecuteAsync<Result<PriceResponseModel>>(
                 async () => await priceApiClient.CreateAsync(model),
                  async () => Result<PriceResponseModel>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<PriceResponse>(response.Data) : null;
                return Result<PriceResponse>.Success(result);
            }
            else
            {
                return Result<PriceResponse>.Fail(response.Messages);
            }



        }

        public async Task<Result<PriceResponse>> UpdateAsync(PriceUpdate request)
        {

            var model = _mapper.Map<PriceUpdateRequestModel>(request);
            var response = await ExecutorAppMode.ExecuteAsync<Result<PriceResponseModel>>(
                 async () => await priceApiClient.UpdateAsync(model),
                  async () => Result<PriceResponseModel>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<PriceResponse>(response.Data) : null;
                return Result<PriceResponse>.Success(result);
            }
            else
            {
                return Result<PriceResponse>.Fail(response.Messages);
            }



        }
        public async Task<Result<DeleteResponse>> DeleteAsync(string id)
        {

            var response = await ExecutorAppMode.ExecuteAsync<Result<DeleteResponseModel>>(
                 async () => await priceApiClient.DeleteAsync(id),
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
