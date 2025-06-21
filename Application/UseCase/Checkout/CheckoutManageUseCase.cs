using Domain.Entities.Checkout.Request;
using Domain.Entities.Checkout.Response;
using Domain.Repository.Checkout;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class CheckoutManageUseCase
    {
        private readonly ICheckoutRepository repository;
        public CheckoutManageUseCase(ICheckoutRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<CheckoutResponse>> ExecuteAsync(SessionCreate request)
        {

            return await repository.CheckoutManageAsync(request);

        }
    }

}
