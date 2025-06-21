using Domain.Entities.Billing.Response;
using Domain.Repository.Billing;
 using Shared.Wrapper;

namespace Application.Service.Plans
{
    public class GetBillingDetailsUseCase
    {

        private readonly IBillingRepository repository;
        public GetBillingDetailsUseCase(IBillingRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<BillingDetailsResponse>> ExecuteAsync()
        {

            return await repository.GetBillingDetailsAsync();

        }


    }


}
