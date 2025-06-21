using Domain.Repository.Profile;
using Domain.Repository.Subscriptions;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class HasActiveSubscriptionUseCase
    {
        private readonly ISubscriptionsRepository repository;
        private readonly IProfileRepository profileRepository;
        public HasActiveSubscriptionUseCase(ISubscriptionsRepository repository, IProfileRepository profileRepository)
        {

            this.repository = repository;
            this.profileRepository = profileRepository;
        }

        public async Task<Result<bool>> ExecuteAsync()
        {

            return await repository.HasActiveSubscriptionAsync();

        }
    }   






}
