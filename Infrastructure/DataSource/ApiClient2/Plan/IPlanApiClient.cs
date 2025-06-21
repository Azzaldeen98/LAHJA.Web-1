
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


public interface IPlanApiClient : ITBaseShareApiClient 
{

    public Task<PlanOutputVMIEnumerablePagedResponse> GetAllPlansAsync(string lg, CancellationToken cancellationToken);
    public Task<ICollection<PlanOutputVM>> GetPlansAsync(string lg, CancellationToken cancellationToken);


    public Task<PlanOutputVM> GetPlanByIdAsync(string id, string lg, CancellationToken cancellationToken);

    public Task<int> CountAllPlansAsync(CancellationToken cancellationToken);

}

