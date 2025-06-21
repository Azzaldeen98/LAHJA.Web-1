using Domain.Entities.Subscriptions.Response;
using Domain.Repository.Subscriptions;
using Domain.ShareData.Base;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class DeleteSubscriptionUseCase
    {
        private readonly ISubscriptionsRepository repository;

        public DeleteSubscriptionUseCase(ISubscriptionsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<DeleteResponse>> ExecuteAsync(string id)
        {
            return await repository.DeleteAsync(id);
        }
    }






}
