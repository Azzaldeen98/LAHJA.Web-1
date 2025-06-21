using Application.UseCase.Plans.Get;
using AutoMapper;
using Domain.Entities.Subscriptions;
using Domain.Entities.Subscriptions.Request;
using Domain.Entities.Subscriptions.Response;
using Domain.ShareData.Base;
 using Shared.Wrapper;
using LAHJA.Helpers.Services;
using Shared.Helpers;

namespace LAHJA.ApplicationLayer.Subscription
{
    public class SubscriptionClientService
    {
        private readonly Application.Service.Subscriptions.SubscriptionService _subscriptionService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public SubscriptionClientService(Application.Service.Subscriptions.SubscriptionService subscriptionService, IMapper mapper, ITokenService tokenService)
        {
            this._subscriptionService = subscriptionService;
            this._mapper = mapper;
            this._tokenService = tokenService;
        }
        public async Task<Result<bool>> HasActiveSubscriptionAsync()
        {
            return await _subscriptionService.HasActiveSubscriptionAsync();
        }

        public async Task<Result<SubscriptionResponse>> GetUserActiveSubscriptionAsync()
        {
            return await _subscriptionService.GetUserActiveSubscriptionAsync();
        }
        public async Task<Result<SubscriptionResponse>> GetSubscriptionAsync(FilterResponseData filter)
        {
            return await _subscriptionService.GetSubscriptionAsync(filter);
        }

        public async Task<Result<SubscriptionCreateResponse>> CreateAsync(SubscriptionCreate request)
        {
            return await _subscriptionService.CreateAsync(request);
        }
        public async Task<Result<SubscriptionResponse>>UpdateAsync(SubscriptionRequest request)
        {
            return await _subscriptionService.UpdateAsync(request);
        }
        public async Task<Result<SubscriptionResponse>> PauseAsync(string id)
        {
            return await _subscriptionService.PauseAsync(id);
        }

        public async Task<Result<DeleteResponse>> DeleteAsync(string id)
        {
            return await _subscriptionService.DeleteAsync(id);
        }

        public async Task<Result<SubscriptionResponse>> ResumeAsync(string id)
        {
            return await _subscriptionService.ResumeAsync(id);
        }

        public async Task<Result<List<SubscriptionResponse>>> GetAllAsync()
        {
            return await _subscriptionService.GetAllAsync();
        }
    }

}
