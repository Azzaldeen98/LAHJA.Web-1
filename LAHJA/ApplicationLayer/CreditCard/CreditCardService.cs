using Domain.Entities.Billing.Request;
using Domain.Entities.Billing.Response;
using Domain.ShareData.Base;
 using Shared.Wrapper;

namespace Application.Service.Plans
{
    public class CreditCardClientService
    {

        private readonly CreditCardService service;

        public CreditCardClientService(CreditCardService service)
        {
            this.service = service;
        }




        public async Task<Result<List<CardDetailsResponse>>> GetSubscriptionCreditCardsAsync()
        {
            return await service.GetSubscriptionCreditCardsAsync();
        }

        public async Task<Result<CardDetailsResponse>> CreateAsync(CardDetailsRequest request)
        {
            return await service.CreateAsync(request);
        }
        public async Task<Result<DeleteResponse>> DeleteAsync(string id)
        {
            return await service.DeleteAsync(id);
        }

        public async Task<Result<CardDetailsResponse>> UpdateAsync(CardDetailsRequest request)
        {
            return await service.UpdateAsync(request);
        } 
        public async Task<Result<CardDetailsResponse>> ActiveCreditCardAsync(CardDetailsRequest request)
        {
            return await service.UpdateAsync(request);
        }




    } 
}
