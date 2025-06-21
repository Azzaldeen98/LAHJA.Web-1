using Domain.Entities.Checkout;
using Domain.Entities.Checkout.Response;
using Domain.Entities.Plans.Response;
using Domain.Repository.Checkout;
using Domain.Repository.Plans;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class CheckoutUseCase
    {
        private readonly ICheckoutRepository repository;
        public CheckoutUseCase(ICheckoutRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<CheckoutResponse>> ExecuteAsync(CheckoutRequest request)
        {

            return await repository.CheckoutAsync(request);

        }
    }

}
