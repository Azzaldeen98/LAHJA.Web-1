using Application.UseCase.Plans;
using Application.UseCase.Plans.Get;
using Domain.Entities.Billing.Request;
using Domain.Entities.Billing.Response;
using Domain.Entities.Checkout;
using Domain.Entities.Checkout.Request;
using Domain.Entities.Checkout.Response;
using Domain.Entities.Plans.Response;
using Domain.ShareData.Base;
 using Shared.Wrapper;
using Infrastructure.Models.Profile.Response;

namespace Application.Service.Plans
{
    public class CreditCardService
    {
       
        private readonly GetCreditCardsUseCase _getCreditCardsUseCase;
        private readonly CreateCreditCardUseCase _createCreditCardUseCase;
        private readonly UpdateCreditCardUseCase _updateCreditCardUseCase;
        private readonly DeleteCreditCardUseCase _deleteCreditCardUseCase;

        public CreditCardService(
            GetCreditCardsUseCase getCreditCardsUseCase,
            CreateCreditCardUseCase createCreditCardUseCase,
            UpdateCreditCardUseCase updateCreditCardUseCase,
            DeleteCreditCardUseCase deleteCreditCardUseCase)
        {
            _getCreditCardsUseCase = getCreditCardsUseCase;
            _createCreditCardUseCase = createCreditCardUseCase;
            _updateCreditCardUseCase = updateCreditCardUseCase;
            _deleteCreditCardUseCase = deleteCreditCardUseCase;
        }

        public async Task<Result<List<CardDetailsResponse>>> GetSubscriptionCreditCardsAsync()
        {
            return await  _getCreditCardsUseCase.ExecuteAsync();
        }

        public async Task<Result<CardDetailsResponse>> CreateAsync(CardDetailsRequest request)
        {
            return await _createCreditCardUseCase.ExecuteAsync(request);
        }
        public async Task<Result<DeleteResponse>> DeleteAsync(string id)
        {
            return await _deleteCreditCardUseCase.ExecuteAsync(id);
        }

        public async Task<Result<CardDetailsResponse>> UpdateAsync(CardDetailsRequest request)
        {
            return await _updateCreditCardUseCase.ExecuteAsync(request);
        }
         public async Task<Result<CardDetailsResponse>> ActiveCreditCardAsync(CardDetailsRequest request)
        {
            return await _updateCreditCardUseCase.ExecuteAsync(request);
        }




    } 
}
