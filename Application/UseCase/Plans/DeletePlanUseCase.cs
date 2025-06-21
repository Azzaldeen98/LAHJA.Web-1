using Domain.Repository.Plans;
using Domain.ShareData.Base;
 using Shared.Wrapper;

namespace Application.UseCase.Plans
{
    public class DeletePlanUseCase
    {
        private readonly IPlansRepository repository;
        public DeletePlanUseCase(IPlansRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<DeleteResponse>> ExecuteAsync(string id)
        {

            return await repository.DeletePlanAsync(id);

        }
    }

}
