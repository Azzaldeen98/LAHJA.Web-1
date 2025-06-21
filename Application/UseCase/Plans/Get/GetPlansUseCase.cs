using Domain.Entities.Plans.Response;
using Domain.Repository.Plans;
using Domain.ShareData.Base;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class GetPlansUseCase
    {
        private readonly IPlansRepository repository;
        public GetPlansUseCase(IPlansRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<IEnumerable<SubscriptionPlan>>> ExecuteAsync(FilterResponseData filter)
        {

            return await repository.GetPlansAsync(filter);

        }
    }

}
