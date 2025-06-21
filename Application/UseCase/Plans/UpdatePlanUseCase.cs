using Domain.Entities.Plans.Response;
using Domain.Repository.Plans;
 using Shared.Wrapper;

namespace Application.UseCase.Plans
{
    public class UpdatePlanUseCase
    {
        private readonly IPlansRepository repository;
        public UpdatePlanUseCase(IPlansRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<SubscriptionPlan>> ExecuteAsync(PlanUpdate request)
        {

            return await repository.UpdatePlanAsync(request);

        }
    }
}
