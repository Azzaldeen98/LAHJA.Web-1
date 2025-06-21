using Domain.Entities.Billing.Request;
using Domain.Entities.Billing.Response;
using Domain.Entities.Price.Request;
using Domain.Entities.Price.Response;
using Domain.ShareData.Base;
 using Shared.Wrapper;


namespace Domain.Repository.Billing
{
    public interface IBillingRepository
    {
        //Task<Result<List<CardDetailsResponse>>> GetSubscriptionCreditCardsAsync();
        Task<Result<BillingDetailsResponse>> GetBillingDetailsAsync();
        Task<Result<BillingDetailsResponse>> CreateBillingAsync(BillingDetailsRequest request);
        Task<Result<DeleteResponse>> DeleteBillingAsync(string id);
        Task<Result<BillingDetailsResponse>> UpdateBillingAsync(BillingDetailsRequest request);

        //Task<Result<CardDetailsResponse>> CreateCardAsync(CardDetailsRequest request);
        //Task<Result<DeleteResponse>> DeleteCardAsync(string id);
        //Task<Result<CardDetailsResponse>> UpdateCardAsync(CardDetailsRequest request);
        //Task<Result<CardDetailsResponse>> ActiveCreditCardAsync(CardDetailsRequest request);
    }
}