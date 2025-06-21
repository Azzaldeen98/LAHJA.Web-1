
using AutoMapper;
 using Shared.Wrapper;
using Infrastructure.DataSource.Seeds;
using Shared.Settings;
using Infrastructure.Models.BaseFolder.Response;
using Domain.ShareData.Base;
using Domain.Repository.Billing;
using Infrastructure.DataSource.ApiClient.Billing;
using Infrastructure.Models.Billing.Response;
using Domain.Entities.Billing.Response;
using Domain.Entities.Billing.Request;
using Infrastructure.Models.Billing.Request;
using Domain.ShareData;

namespace Infrastructure.Repository.Price
{
    public class BillingRepository : IBillingRepository
    {
        private readonly SeedsBillings seeds;
        private readonly SeedsCreditCards seedsCardit;
        private readonly BillingApiClient apiClient;
        private readonly IMapper _mapper;
        private readonly ApplicationModeService appModeService;
        private readonly ISessionUserManager sessionUserManager;
        public BillingRepository(
            IMapper mapper,
            SeedsPlans seedsPlans,
            ApplicationModeService appModeService,
            BillingApiClient apiClient,
            SeedsBillings seeds,
            SeedsCreditCards seedsCardit,
            ISessionUserManager sessionUserManager)
        {

            //seedsPlans = new SeedsPlans();
            _mapper = mapper;

            this.appModeService = appModeService;

            this.apiClient = apiClient;
            this.seeds = seeds;
            this.seedsCardit = seedsCardit;
            this.sessionUserManager = sessionUserManager;
        }



        public async Task<Result<BillingDetailsResponse>> GetBillingDetailsAsync()
        {
           
            var response = await ExecutorAppMode.ExecuteAsync<Result<BillingDetailsResponseModel>>(
               async () => {
                   var email = await sessionUserManager.GetEmailAsync();
                   var res = seeds.GetBillingDetailsByEmail(email);
                   var model = _mapper.Map<BillingDetailsResponseModel>(res);

                   return Result<BillingDetailsResponseModel>.Success(model);
               },
                async () => {
                    var email = await sessionUserManager.GetEmailAsync();
                    var res =  seeds.GetBillingDetailsByEmail(email);
                    var model= _mapper.Map<BillingDetailsResponseModel>(res);

                    return Result<BillingDetailsResponseModel>.Success(model);
                    });

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<BillingDetailsResponse>(response.Data) : null;
                return Result<BillingDetailsResponse>.Success(result);
            }
            else
            {
                return Result<BillingDetailsResponse>.Fail(response.Messages);
            }
        }
    

        public async Task<Result<BillingDetailsResponse>> CreateBillingAsync(BillingDetailsRequest request)
        {
            var model = _mapper.Map<BillingDetailsRequestModel>(request);
            var response = await ExecutorAppMode.ExecuteAsync<Result<BillingDetailsResponseModel>>(
                 async () => await apiClient.CreateBillingAsync(model),
                  async () => {
                      seeds.AddBillingDetails(model);
                      return Result<BillingDetailsResponseModel>.Success();
                  });

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<BillingDetailsResponse>(response.Data) : null;
                return Result<BillingDetailsResponse>.Success(result);
            }
            else
            {
                return Result<BillingDetailsResponse>.Fail(response.Messages);
            }
        }

        public async Task<Result<DeleteResponse>> DeleteBillingAsync(string id)
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<DeleteResponseModel>>(
              async () => await apiClient.DeleteBillingAsync(id),
               async () => {
                   if (seeds.DeleteBillingDetails(id))
                       return Result<DeleteResponseModel>.Success();
                   else
                       return Result<DeleteResponseModel>.Fail();
               });

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

        public async Task<Result<BillingDetailsResponse>> UpdateBillingAsync(BillingDetailsRequest request)
        {
            var model = _mapper.Map<BillingDetailsRequestModel>(request);
            var response = await ExecutorAppMode.ExecuteAsync<Result<BillingDetailsResponseModel>>(
                 async () => await apiClient.UpdateBillingAsync(model),
                  async () => {
                      if (seeds.UpdateBillingDetails(model))
                          return Result<BillingDetailsResponseModel>.Success();
                      else
                          return Result<BillingDetailsResponseModel>.Fail();
                  });

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<BillingDetailsResponse>(response.Data) : null;
                return Result<BillingDetailsResponse>.Success(result);
            }
            else
            {
                return Result<BillingDetailsResponse>.Fail(response.Messages);
            }
        }

    } 
}
