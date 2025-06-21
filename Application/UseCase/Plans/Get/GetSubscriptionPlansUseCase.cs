using Domain.Entities.Plans.Response;
using Domain.Repository.Plans;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class GetSubscriptionPlansUseCase
    {
        private readonly IPlansRepository repository;
        public GetSubscriptionPlansUseCase(IPlansRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<IEnumerable<SubscriptionPlan>>> ExecuteAsync(string containerId)
        {

            throw new NotImplementedException();

        }
    }  

}
