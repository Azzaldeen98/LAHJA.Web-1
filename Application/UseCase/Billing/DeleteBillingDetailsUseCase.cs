using Domain.Repository.Billing;
using Domain.ShareData.Base;
 using Shared.Wrapper;

namespace Application.Service.Plans
{
    public class DeleteBillingDetailsUseCase
    {
        private readonly IBillingRepository repository;

        public DeleteBillingDetailsUseCase(IBillingRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<DeleteResponse>> ExecuteAsync(string billingId)
        {

            return await repository.DeleteBillingAsync(billingId);
        }
    }


}
