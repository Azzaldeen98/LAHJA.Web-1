using Domain.Entities.Subscriptions.Request;
using Domain.Entities.Subscriptions.Response;
using Domain.Repository.Subscriptions;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class UpdateSubscriptionUseCase
    {
        private readonly ISubscriptionsRepository repository;
        public UpdateSubscriptionUseCase(ISubscriptionsRepository repository)
        {

            this.repository = repository;
        }

        public async Task<Result<SubscriptionResponse>> ExecuteAsync(SubscriptionRequest request)
        {

            return await repository.UpdateAsync(request);

        }
    }






}
