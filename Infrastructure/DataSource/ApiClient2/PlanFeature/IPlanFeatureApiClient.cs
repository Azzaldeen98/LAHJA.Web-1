
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Infrastructure.Share.Invoker;
using AutoMapper;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Share.Invoker;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.DataSource.ApiClient2;


public interface IPlanFeatureApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<PlanFeatureOutputVM>> GetPlanFeaturesAsync(CancellationToken cancellationToken);

    public Task<PlanFeatureOutputVM> CreatePlanFeatureAsync(PlanFeatureCreateVM body, CancellationToken cancellationToken);

    public Task<PlanFeatureOutputVM> UpdatePlanFeatureAsync(PlanFeatureUpdateVM body, CancellationToken cancellationToken);

    public Task<PlanFeatureOutputVMIEnumerablePagedResponse> GetPlanFeaturesByPlanIdAsync(string planId, string lg, CancellationToken cancellationToken);

    public Task<PlanFeatureInfoVM> GetPlanFeatureAsync(string id, CancellationToken cancellationToken);

    public Task DeletePlanFeatureAsync(string id, CancellationToken cancellationToken);

    public Task<PlanFeatureOutputVM> GetPlanFeatureByLgAsync(PlanFeatureFilterVM body, CancellationToken cancellationToken);

    public Task<ICollection<PlanFeatureOutputVM>> GetPlanFeaturesByLgAsync(string lg, CancellationToken cancellationToken);

    public Task<ICollection<PlanFeatureOutputVM>> CreateRange12Async(IEnumerable<PlanFeatureCreateVM> body, CancellationToken cancellationToken);

    public Task<int> CountPlanFeatureAsync(CancellationToken cancellationToken);

    public Task<int> NumberRequestsAsync(CancellationToken cancellationToken);

}

