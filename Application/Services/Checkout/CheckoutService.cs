using Application.UseCase.Plans.Get;
using Domain.Entities.Checkout;
using Domain.Entities.Checkout.Request;
using Domain.Entities.Checkout.Response;
 using Shared.Wrapper;

namespace Application.Service.Checkout
{
    public class CheckoutService
    {
        private readonly CheckoutUseCase getCheckoutUseCase;
        private readonly CheckoutManageUseCase getCheckoutManageUseCase;


        public CheckoutService(CheckoutUseCase getCheckoutUseCase, CheckoutManageUseCase CheckoutManageAsync)
        {
            this.getCheckoutUseCase = getCheckoutUseCase;
            this.getCheckoutManageUseCase = CheckoutManageAsync;
        }

        public async Task<Result<CheckoutResponse>> CheckoutAsync(CheckoutRequest  request)
        {
            return await getCheckoutUseCase.ExecuteAsync(request);

        }

        public async Task<Result<CheckoutResponse>> CheckoutManageAsync(SessionCreate request)
        {
            return await getCheckoutManageUseCase.ExecuteAsync(request);

        }




    } 
}
