using Domain.Entities.Subscriptions.Response;
using Domain.Repository.Subscriptions;
using Domain.ShareData.Base;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class GetSubscriptionUseCase
    {
        private readonly ISubscriptionsRepository repository;
        public GetSubscriptionUseCase(ISubscriptionsRepository repository)
        {

            this.repository = repository;
        }

        public async Task<Result<SubscriptionResponse>> ExecuteAsync(FilterResponseData filter)
        {

            return await repository.GetSubscriptionAsync(filter);

        }
    }



}
