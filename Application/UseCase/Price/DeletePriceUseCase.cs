using Domain.Repository.Price;
using Domain.ShareData.Base;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class DeletePriceUseCase
    {
        private readonly IPriceRepository repository;
        public DeletePriceUseCase(IPriceRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<DeleteResponse>> ExecuteAsync(string id)
        {

            return await repository.DeleteAsync(id);

        }
    }

}
