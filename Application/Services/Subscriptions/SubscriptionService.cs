using Application.UseCase.Plans.Get;
using Domain.Entities.Subscriptions.Request;
using Domain.Entities.Subscriptions.Response;
using Domain.ShareData.Base;
 using Shared.Wrapper;


namespace Application.Service.Subscriptions
{
    public class SubscriptionService
    {
        private readonly PauseSubscriptionUseCase pauseSubscriptionUseCase;
        private readonly DeleteSubscriptionUseCase deleteSubscriptionUseCase;
        private readonly ResumeSubscriptionUseCase resumeSubscriptionUseCase;
        private readonly GetAllSubscriptionsUseCase getAllSubscriptionsUseCase;
        private readonly CreateSubscriptionUseCase createSubscriptionUseCase;
        private readonly UpdateSubscriptionUseCase updateSubscriptionUseCase;
        private readonly HasActiveSubscriptionUseCase hasActiveSubscriptionUseCase;
        private readonly GetUserActiveSubscriptionUseCase  getUserActiveSubscriptionUseCase;
        private readonly GetSubscriptionUseCase getSubscriptionUseCase;

        public SubscriptionService(
            PauseSubscriptionUseCase pauseSubscriptionUseCase,
            DeleteSubscriptionUseCase deleteSubscriptionUseCase,
            ResumeSubscriptionUseCase resumeSubscriptionUseCase,
            GetAllSubscriptionsUseCase getAllSubscriptionsUseCase,
            CreateSubscriptionUseCase createSubscriptionUseCase,
            UpdateSubscriptionUseCase updateSubscriptionUseCase,
            HasActiveSubscriptionUseCase hasActiveSubscriptionUseCase,
            GetUserActiveSubscriptionUseCase getUserActiveSubscriptionUseCase,
            GetSubscriptionUseCase getSubscriptionUseCase)
        {
            this.pauseSubscriptionUseCase = pauseSubscriptionUseCase;
            this.deleteSubscriptionUseCase = deleteSubscriptionUseCase;
            this.resumeSubscriptionUseCase = resumeSubscriptionUseCase;
            this.getAllSubscriptionsUseCase = getAllSubscriptionsUseCase;
            this.createSubscriptionUseCase = createSubscriptionUseCase;
            this.updateSubscriptionUseCase = updateSubscriptionUseCase;
            this.hasActiveSubscriptionUseCase = hasActiveSubscriptionUseCase;
            this.getUserActiveSubscriptionUseCase = getUserActiveSubscriptionUseCase;
            this.getSubscriptionUseCase = getSubscriptionUseCase;
        }
        public async Task<Result<bool>> HasActiveSubscriptionAsync()
        {
            return await hasActiveSubscriptionUseCase.ExecuteAsync();
        }
        public async Task<Result<SubscriptionCreateResponse>> CreateAsync(SubscriptionCreate request)
        {
            return await createSubscriptionUseCase.ExecuteAsync(request);
        }
        public async Task<Result<SubscriptionResponse>> GetUserActiveSubscriptionAsync()
        {
            return await getUserActiveSubscriptionUseCase.ExecuteAsync();
        }
        public async Task<Result<SubscriptionResponse>> GetSubscriptionAsync(FilterResponseData filter)
        {
            return await getSubscriptionUseCase.ExecuteAsync(filter);
        }
        public async Task<Result<SubscriptionResponse>> UpdateAsync(SubscriptionRequest request)
        {
            return await updateSubscriptionUseCase.ExecuteAsync(request);
        }
        public async Task<Result<SubscriptionResponse>> PauseAsync(string id)
        {
            return await pauseSubscriptionUseCase.ExecuteAsync(id);
        }

        public async Task<Result<DeleteResponse>> DeleteAsync(string id)
        {
            return await deleteSubscriptionUseCase.ExecuteAsync(id);
        }

        public async Task<Result<SubscriptionResponse>> ResumeAsync(string id)
        {
            return await resumeSubscriptionUseCase.ExecuteAsync(id);
        }

        public async Task<Result<List<SubscriptionResponse>>> GetAllAsync()
        {
            return await getAllSubscriptionsUseCase.ExecuteAsync();
        }
    }

}
