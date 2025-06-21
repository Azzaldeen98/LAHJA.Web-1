using Domain.Entities.Plans.Response;
using Domain.Repository.Plans;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class GetPlanUseCase
    {
        private readonly IPlansRepository repository;
        public GetPlanUseCase(IPlansRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<SubscriptionPlan>> ExecuteAsync(string planId,string lg)
        {

            return await repository.GetPlanAsync(planId,lg);

        }
    }
}
