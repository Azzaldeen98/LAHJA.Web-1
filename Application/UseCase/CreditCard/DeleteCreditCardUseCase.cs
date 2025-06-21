using Domain.Repository.Billing;
using Domain.Repository.CreditCard;
using Domain.ShareData.Base;
 using Shared.Wrapper;

namespace Application.Service.Plans
{
    public class DeleteCreditCardUseCase
    {
        private readonly ICreditCardRepository repository;

        public DeleteCreditCardUseCase(ICreditCardRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<DeleteResponse>> ExecuteAsync(string cardId)
        {
   
            return await repository.DeleteAsync(cardId);
        }
    }



}