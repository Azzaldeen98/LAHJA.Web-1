using Domain.Entities.Price.Request;
using Domain.Entities.Price.Response;
using Domain.Repository.Price;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class SearchPriceUseCase
    {
        private readonly IPriceRepository repository;
        public SearchPriceUseCase(IPriceRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<List<PriceResponse>>> ExecuteAsync(PriceSearchOptionsRequest request)
        {

            return await repository.SearchAsync(request);

        }
    }

}
