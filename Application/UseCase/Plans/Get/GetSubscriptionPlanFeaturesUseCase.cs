using Domain.Entities.Plans.Response;
using Domain.Repository.Plans;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class GetSubscriptionPlanFeaturesUseCase
    {
        private readonly IPlansRepository repository;
        public GetSubscriptionPlanFeaturesUseCase(IPlansRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<IEnumerable<PlanFeature>>> ExecuteAsync(string planId)
        {

            //return await repository.getSubscriptionsPlansFeaturesAsync(planId);

            throw new NotImplementedException();

        }
    }
}
