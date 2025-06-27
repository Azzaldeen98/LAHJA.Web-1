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
        var result = await _apiClient.GetMySubscriptionAsync(cancellationToken);
        return _mapper.Map<Subscription>(result);
    }

    public async Task<Subscription> GetOneAsync(String id, CancellationToken cancellationToken)
    {
        var result = await _apiClient.GetOneSubscriptionAsync(id, cancellationToken);
        return _mapper.Map<Subscription>(result);
    }

    [RouteTo("PauseCollectionAsync")]
    public async Task PauseAsync(Subscription model, CancellationToken cancellationToken)
    {
        var _body = _mapper.Map<SubscriptionUpdateRequest>(model);
        await _apiClient.PauseCollectionAsync(_body, cancellationToken);
    }

    public async Task RenewAsync(CancellationToken cancellationToken)
    {
        await _apiClient.RenewSubscriptionAsync(cancellationToken);
    }

    [RouteTo("ResumeCollection2Async")]
    public async Task ResumeAsync(CancellationToken cancellationToken)
    {
        await _apiClient.ResumeCollectionAsync(cancellationToken);
    }

    [RouteTo("Cancel2Async")]
    public async Task CancelAsync(CancellationToken cancellationToken)
    {
        await _apiClient.CancelAtEndAsync(cancellationToken);
    }
}