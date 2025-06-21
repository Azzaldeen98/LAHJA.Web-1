using Domain.Entities.Checkout;
using Domain.Entities.Checkout.Response;
using Domain.Entities.Plans.Response;
using Domain.Entities.Price.Request;
using Domain.Entities.Price.Response;
using Domain.Repository.Checkout;
using Domain.Repository.Plans;
using Domain.Repository.Price;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class UpdatePriceUseCase
    {
        private readonly IPriceRepository    repository;
        public UpdatePriceUseCase(IPriceRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<PriceResponse>> ExecuteAsync(PriceUpdate request)
        {

            return await repository.UpdateAsync(request);

        }
    }
  







}
