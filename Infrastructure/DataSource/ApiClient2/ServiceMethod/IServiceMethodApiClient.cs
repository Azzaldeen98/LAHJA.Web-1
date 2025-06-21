
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


public interface IServiceMethodApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<ServiceMethodOutputVM>> GetServiceMethodsAsync(CancellationToken cancellationToken);

    public Task<ServiceMethodOutputVM> CreateServiceMethodAsync(ServiceMethodCreateVM body, CancellationToken cancellationToken);

    public Task<ServiceMethodInfoVM> GetServiceMethodAsync(string id, CancellationToken cancellationToken);

    public Task<ServiceMethodOutputVM> UpdateServiceMethodAsync(string id, ServiceMethodUpdateVM body, CancellationToken cancellationToken);

    public Task DeleteServiceMethodAsync(string id, CancellationToken cancellationToken);

    public Task<ServiceMethodOutputVM> GetServiceMethodByLgAsync(ServiceMethodFilterVM body, CancellationToken cancellationToken);

    public Task<ICollection<ServiceMethodOutputVM>> GetServiceMethodsByLgAsync(string lg, CancellationToken cancellationToken);

    public Task<ICollection<ServiceMethodOutputVM>> CreateRange14Async(IEnumerable<ServiceMethodCreateVM> body, CancellationToken cancellationToken);

    public Task<int> CountServiceMethodAsync(CancellationToken cancellationToken);

}

