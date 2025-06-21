using Domain.Repository.Service;
using Domain.ShareData.Base;
 using Shared.Wrapper;

namespace Application.UseCase.Service
{
    public class DeleteServiceUseCase
    {
        private readonly IServiceRepository repository;

        public DeleteServiceUseCase(IServiceRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<DeleteResponse>> ExecuteAsync(string id)
        {
            return await repository.DeleteAsync(id);
        }
    }


}
