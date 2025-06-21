using Shared.Interfaces;
using Shared.Wrapper;
using AutoGenerator.Config.Attributes;
using Domain.Entity;
using Infrastructure.Nswag;
using Domain.IRepositories;
using System.Threading.Tasks;
using Infrastructure.DataSource.ApiClient2;
using System.Collections.Generic;
using AutoMapper;

namespace Infrastructure.Repositories;
public partial class SubscriptionRepository : ISubscriptionRepository
{
    private readonly ISubscriptionApiClient _apiClient;
    private readonly IMapper _mapper;
    public SubscriptionRepository(ISubscriptionApiClient apiClient, IMapper mapper)
    {
        _apiClient = apiClient;
        _mapper = mapper;
    }

    public async Task<ICollection<Subscription>> GetSubscriptionsAsync(CancellationToken cancellationToken)
    {
        var result = await _apiClient.GetSubscriptionsAsync(cancellationToken);
        return _mapper.Map<ICollection<Subscription>>(result);
    }

    public async Task<Subscription> GetSubscriptionAsync(CancellationToken cancellationToken)
    {
        var result = await _apiClient.GetSubscriptionsAsync(cancellationToken);
        return _mapper.Map<Subscription>(result);
    }

    public async Task<Subscription> GetOneAsync(String id, CancellationToken cancellationToken)
    {
        var result = await _apiClient.GetOneSubscriptionAsync(id, cancellationToken);
        return _mapper.Map<Subscription>(result);
    }

    public async Task PauseAsync(String id, Subscription model, CancellationToken cancellationToken)
    {
        var body = _mapper.Map<SubscriptionUpdateRequest>(model);
        await _apiClient.PauseCollectionAsync(body, cancellationToken);
    }

    public async Task RenewAsync(String id, CancellationToken cancellationToken)
    {
        await _apiClient.RenewAsync(id, cancellationToken);
    }

    public async Task ResumeAsync(String id, CancellationToken cancellationToken)
    {
        await _apiClient.ResumeCollection2Async(id, cancellationToken);
    }

    public async Task CancelAsync(String id, CancellationToken cancellationToken)
    {
        await _apiClient.Cancel2Async(id, cancellationToken);
    }
}