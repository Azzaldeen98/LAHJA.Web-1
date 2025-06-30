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
public partial class PlanRepository : IPlanRepository
{
    private readonly IPlanApiClient _apiClient;
    private readonly IMapper _mapper;
    public PlanRepository(IPlanApiClient apiClient, IMapper mapper)
    {
        _apiClient = apiClient;
        _mapper = mapper;
    }

    public async Task<PaginatedResult<Plan>> GetAllPlansAsync(String lg, CancellationToken cancellationToken)
    {
        var result = await _apiClient.GetAllPlansAsync(lg, cancellationToken);
        return PaginatedResult<Plan>.Success(_mapper.Map<List<Plan>>(result.Data.ToList()), result.TotalRecords, result.PageNumber, result.PageSize, result.SortBy, result.SortDirection);
    }

    public async Task<ICollection<Plan>> GetPlansAsync(String lg, CancellationToken cancellationToken)
    {
       
        var result = await _apiClient.GetPlansAsync(lg, cancellationToken);
        return _mapper.Map<ICollection<Plan>>(result);
    }

    public async Task<int> CountAllPlansAsync(CancellationToken cancellationToken)
    {
        var result = await _apiClient.CountAllPlansAsync(cancellationToken);
        return result;
    }

    public async Task<Plan> GetByIdAsync(String lg, String id, CancellationToken cancellationToken)
    {
        var result = await _apiClient.GetPlanByIdAsync(lg, id, cancellationToken);
        return _mapper.Map<Plan>(result);
    }
}