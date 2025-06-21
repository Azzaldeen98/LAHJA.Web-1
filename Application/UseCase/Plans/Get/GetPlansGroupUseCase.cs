using Domain.Entities.Plans.Response;
using Domain.Repository.Plans;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class GetPlansGroupUseCase
    {
        private readonly IPlansRepository repository;
        public GetPlansGroupUseCase(IPlansRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<IEnumerable<PlansGroupResponse>>> ExecuteAsync()
        {

            throw new NotImplementedException();

        }
    }

}
