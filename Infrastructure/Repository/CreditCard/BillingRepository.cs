
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
using Domain.Repository.CreditCard;

namespace Infrastructure.Repository.CreditCard
{
    public class CreditCardRepository : ICreditCardRepository
    {
  
        private readonly SeedsCreditCards seedsCardit;
        private readonly BillingApiClient apiClient;
        private readonly IMapper _mapper;
        private readonly ApplicationModeService appModeService;
        private readonly ISessionUserManager sessionUserManager;
        public CreditCardRepository(
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
            this.seedsCardit = seedsCardit;
            this.sessionUserManager = sessionUserManager;
        }

        public async Task<Result<List<CardDetailsResponse>>> GetAllAsync()
        {
            

            var response = await ExecutorAppMode.ExecuteAsync<Result<List<CardDetailsResponseModel>>>(
                 async () => {
                     var email = await sessionUserManager.GetEmailAsync();
                     var res = seedsCardit.GetCardDetailsByEmail(email);
                     var model = _mapper.Map<List<CardDetailsResponseModel>>(res);

                     return Result<List<CardDetailsResponseModel>>.Success(model);
                 },
                  async () => {
                      var email = await sessionUserManager.GetEmailAsync();
                      var res = seedsCardit.GetCardDetailsByEmail(email);
                      var model = _mapper.Map<List<CardDetailsResponseModel>>(res);

                      return Result<List<CardDetailsResponseModel>>.Success(model);
                  });

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<List<CardDetailsResponse>>(response.Data) : null;
                return Result<List<CardDetailsResponse>>.Success(result);
            }
            else
            {
                return Result<List<CardDetailsResponse>>.Fail(response.Messages);
            }
        }

        public async Task<Result<CardDetailsResponse>> CreateAsync(CardDetailsRequest request)
        {
            var model = _mapper.Map<CardDetailsRequestModel>(request);
            var response = await ExecutorAppMode.ExecuteAsync<Result<CardDetailsResponseModel>>(
                 async () => await apiClient.CreateCardAsync(model),
                  async ()=>{
                      seedsCardit.AddCardDetails(model);
                     return Result<CardDetailsResponseModel>.Success();
                  });

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<CardDetailsResponse>(response.Data) : null;
                return Result<CardDetailsResponse>.Success(result);
            }
            else
            {
                return Result<CardDetailsResponse>.Fail(response.Messages);
            }
        }

        public async Task<Result<DeleteResponse>> DeleteAsync(string id)
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<DeleteResponseModel>>(
              async () => await apiClient.DeleteCardAsync(id),
            async () => {
                   if(seedsCardit.DeleteCardDetails(id))
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


        public async Task<Result<CardDetailsResponse>> UpdateAsync(CardDetailsRequest request)
        {
            var model = _mapper.Map<CardDetailsRequestModel>(request);
            var response = await ExecutorAppMode.ExecuteAsync<Result<CardDetailsResponseModel>>(
                 async () => await apiClient.UpdateCardAsync(model),
                  async () => {
                      if (seedsCardit.UpdateCardDetails(model))
                          return Result<CardDetailsResponseModel>.Success();
                      else
                          return Result<CardDetailsResponseModel>.Fail();
                  });

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<CardDetailsResponse>(response.Data) : null;
                return Result<CardDetailsResponse>.Success(result);
            }
            else
            {
                return Result<CardDetailsResponse>.Fail(response.Messages);
            }
        }

        public Task<Result<CardDetailsResponse>> ActiveAsync(CardDetailsRequest request)
        {
            throw new NotImplementedException();
        }
    } 
}
