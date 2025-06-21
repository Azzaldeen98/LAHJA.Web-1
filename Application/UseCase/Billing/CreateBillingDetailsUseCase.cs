using Domain.Entities.Billing.Request;
using Domain.Entities.Billing.Response;
using Domain.Repository.Billing;
 using Shared.Wrapper;

namespace Application.Service.Plans
{
    public class CreateBillingDetailsUseCase
    {
        private readonly IBillingRepository repository;

        public CreateBillingDetailsUseCase(IBillingRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<BillingDetailsResponse>> ExecuteAsync(BillingDetailsRequest request)
        {


            return await repository.CreateBillingAsync(request);
        }
    }


}
