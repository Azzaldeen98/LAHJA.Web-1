
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


public interface IServiceApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<ServiceOutputVM>> GetServicesAsync(CancellationToken cancellationToken);

    public Task<ServiceOutputVM> CreateServiceAsync(ServiceCreateVM body, CancellationToken cancellationToken);

    public Task<ServiceOutputVM> GetServiceAsync(string id, CancellationToken cancellationToken);

    public Task<ServiceOutputVM> UpdateServiceAsync(string id, ServiceUpdateVM body, CancellationToken cancellationToken);

    public Task DeleteServiceAsync(string id, CancellationToken cancellationToken);

    public Task<ServiceOutputVM> GetServiceByLgAsync(ServiceFilterVM body, CancellationToken cancellationToken);

    public Task<ICollection<ServiceOutputVM>> GetServicesByLgAsync(string lg, CancellationToken cancellationToken);

    public Task<ServiceOutputVMPagedResponse> GetServicesByModelAiAsync(string modelAiId, string lg, CancellationToken cancellationToken);

    public Task<ModelAiOutputVM> GetModelAiByServiceAsync(string serviceId, string lg, CancellationToken cancellationToken);

    public Task<ICollection<ServiceOutputVM>> CreateRange13Async(IEnumerable<ServiceCreateVM> body, CancellationToken cancellationToken);

    public Task<int> CountServiceAsync(CancellationToken cancellationToken);

}

