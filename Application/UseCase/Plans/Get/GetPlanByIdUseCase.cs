using Domain.Entities.Plans.Response;
using Domain.Repository.Plans;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class GetPlanByIdUseCase
    {
        private readonly IPlansRepository repository;
        public GetPlanByIdUseCase(IPlansRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<PlanResponse>> ExecuteAsync(string planId, string lg)
        {

            throw new NotImplementedException();



        }
    }
}
