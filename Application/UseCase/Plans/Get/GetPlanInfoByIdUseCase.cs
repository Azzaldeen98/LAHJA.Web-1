using Domain.Entities.Plans.Response;
using Domain.Repository.Plans;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class GetPlanInfoByIdUseCase
    {
        private readonly IPlansRepository repository;
        public GetPlanInfoByIdUseCase(IPlansRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<PlanInfoResponse>> ExecuteAsync(string id)
        {

            throw new NotImplementedException();

        }
    }
}
