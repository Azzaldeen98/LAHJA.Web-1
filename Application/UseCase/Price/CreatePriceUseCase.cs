using Domain.Entities.Price.Request;
using Domain.Entities.Price.Response;
using Domain.Repository.Price;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class CreatePriceUseCase
    {
        private readonly IPriceRepository repository;
        public CreatePriceUseCase(IPriceRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<PriceResponse>> ExecuteAsync(PriceCreate request)
        {

            return await repository.CreateAsync(request);

        }
    }




   

}
