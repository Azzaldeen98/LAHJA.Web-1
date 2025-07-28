using Shared.Interfaces;
using Shared.Wrapper;
using AutoGenerator.Attributes;
using Domain.Entity;
using Infrastructure.Nswag;
using Domain.IRepositories;
using System.Threading.Tasks;
using Infrastructure.DataSource.ApiClient2;
using System.Collections.Generic;
using AutoMapper;

namespace Infrastructure.Repositories;
public partial class ProfileRepository : IProfileRepository
{
    private readonly IProfileApiClient _apiClient;
    private readonly IMapper _mapper;
    public ProfileRepository(IProfileApiClient apiClient, IMapper mapper)
    {
        _apiClient = apiClient;
        _mapper = mapper;
    }

    public async Task<User> GetUserAsync(CancellationToken cancellationToken)
    {
        var result = await _apiClient.GetUserAsync(cancellationToken);
        return _mapper.Map<User>(result);
    }

    public async Task UpdateAsync(User body, CancellationToken cancellationToken)
    {
        var _body = _mapper.Map<ApplicationUserUpdateVM>(body);
        await _apiClient.UpdateAsync(_body, cancellationToken);
    }

 
    public async Task<PaginatedResult<Subscription>> GetUserSubscriptionsAsync(CancellationToken cancellationToken)
    {
        var result = await _apiClient.GetUserSubscriptionsAsync(cancellationToken);
        return PaginatedResult<Subscription>.Success(_mapper.Map<List<Subscription>>(result.Data.ToList()), result.TotalRecords, result.PageNumber, result.PageSize, result.SortBy, result.SortDirection);
    }

    [RouteTo("ModelAisAsync")]
    public async Task<ICollection<ModelAi>> GetModelsAiAsync(CancellationToken cancellationToken)
    {
        var result = await _apiClient.ModelAisAsync(cancellationToken);
        return _mapper.Map<ICollection<ModelAi>>(result);
    }

    [RouteTo("ServicesAsync")]
    public async Task<ICollection<Service>> GetServicesAsync(CancellationToken cancellationToken)
    {
        var result = await _apiClient.ServicesAsync(cancellationToken);
        return _mapper.Map<ICollection<Service>>(result);
    }

    [RouteTo("SpacesSubscriptionAsync")]
    public async Task<ICollection<Space>> GetSpacesSubscriptionAsync(String subscriptionId, CancellationToken cancellationToken)
    {
        var result = await _apiClient.SpacesSubscriptionAsync(subscriptionId, cancellationToken);
        return _mapper.Map<ICollection<Space>>(result);
    }

    [RouteTo("SpaceSubscriptionAsync")]
    public async Task<Space> GetSpaceSubscriptionAsync(String subscriptionId, String spaceId, CancellationToken cancellationToken)
    {
        var result = await _apiClient.SpaceSubscriptionAsync(subscriptionId, spaceId, cancellationToken);
        return _mapper.Map<Space>(result);
    }

    public async Task<PaginatedResult<Request>> RequestsSubscriptionAsync(String subscriptionId, CancellationToken cancellationToken)
    {
        var result = await _apiClient.RequestsSubscriptionAsync(subscriptionId, cancellationToken);
        return PaginatedResult<Request>.Success(_mapper.Map<List<Request>>(result.Data.ToList()), result.TotalRecords, result.PageNumber, result.PageSize, result.SortBy, result.SortDirection);
    }

    public async Task<PaginatedResult<Request>> RequestsServiceAsync(String serviceId, CancellationToken cancellationToken)
    {
        var result = await _apiClient.RequestsServiceAsync(serviceId, cancellationToken);
        return PaginatedResult<Request>.Success(_mapper.Map<List<Request>>(result.Data.ToList()), result.TotalRecords, result.PageNumber, result.PageSize, result.SortBy, result.SortDirection);
    }
}