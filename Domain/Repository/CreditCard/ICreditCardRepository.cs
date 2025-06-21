using Domain.Entities.Billing.Request;
using Domain.Entities.Billing.Response;
using Domain.ShareData.Base;
 
using Shared.Wrapper;


namespace Domain.Repository.CreditCard
{
    public interface ICreditCardRepository
    {
        Task<Result<List<CardDetailsResponse>>> GetAllAsync();

        Task<Result<CardDetailsResponse>> CreateAsync(CardDetailsRequest request);
        Task<Result<DeleteResponse>> DeleteAsync(string id);
        Task<Result<CardDetailsResponse>> UpdateAsync(CardDetailsRequest request);
        Task<Result<CardDetailsResponse>> ActiveAsync(CardDetailsRequest request);
    }
}