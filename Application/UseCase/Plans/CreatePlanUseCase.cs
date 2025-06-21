using Domain.Entities.Plans.Response;
using Domain.Repository.Plans;
 using Shared.Wrapper;

namespace Application.UseCase.Plans
{
    public class CreatePlanUseCase
    {
        private readonly IPlansRepository repository;
        public CreatePlanUseCase(IPlansRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<SubscriptionPlan>> ExecuteAsync(PlanCreate request)
        {

            return await repository.CreatePlanAsync(request);

        }
    }

}
