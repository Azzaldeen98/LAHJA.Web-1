using Domain.Entities.Subscriptions.Response;
using Domain.Repository.Subscriptions;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class GetAllSubscriptionsUseCase
    {
        private readonly ISubscriptionsRepository repository;

        public GetAllSubscriptionsUseCase(ISubscriptionsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<List<SubscriptionResponse>>> ExecuteAsync()
        {
            return await repository.getAllAsync();
        }
    }






}
