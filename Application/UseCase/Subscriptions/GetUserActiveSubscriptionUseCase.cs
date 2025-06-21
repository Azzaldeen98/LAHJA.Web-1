using Domain.Entities.Subscriptions.Response;
using Domain.Repository.Subscriptions;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class GetUserActiveSubscriptionUseCase
    {
        private readonly ISubscriptionsRepository repository;
        public GetUserActiveSubscriptionUseCase(ISubscriptionsRepository repository)
        {

            this.repository = repository;
        }

        public async Task<Result<SubscriptionResponse>> ExecuteAsync()
        {

            return await repository.GetUserActiveSubscriptionAsync();

        }
    }



}
