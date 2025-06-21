using Domain.Entities.Subscriptions.Response;
using Domain.Repository.Subscriptions;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{

    public class PauseSubscriptionUseCase
    {
        private readonly ISubscriptionsRepository repository;
        public PauseSubscriptionUseCase(ISubscriptionsRepository repository)
        {

            this.repository = repository;
        }

        public async Task<Result<SubscriptionResponse>> ExecuteAsync(string id)
        {

            return await repository.PauseAsync(id);

        }
    }  






}
