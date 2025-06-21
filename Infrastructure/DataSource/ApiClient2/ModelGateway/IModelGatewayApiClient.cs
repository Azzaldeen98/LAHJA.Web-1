
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


public interface IModelGatewayApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<ModelGatewayOutputVM>> GetModelGatewaysAsync(CancellationToken cancellationToken);

    public Task<ModelGatewayOutputVM> CreateModelGatewayAsync(ModelGatewayCreateVM body, CancellationToken cancellationToken);

    public Task<ModelGatewayOutputVM> GetModelGatewayAsync(string id, CancellationToken cancellationToken);

    public Task<ModelGatewayOutputVM> UpdateModelGatewayAsync(string id, ModelGatewayUpdateVM body, CancellationToken cancellationToken);

    public Task DeleteModelGatewayAsync(string id, CancellationToken cancellationToken);

    public Task<ModelGatewayOutputVM> GetModelGatewayByLgAsync(ModelGatewayFilterVM body, CancellationToken cancellationToken);

    public Task<ICollection<ModelGatewayOutputVM>> GetModelGatewaysByLgAsync(string lg, CancellationToken cancellationToken);

    public Task<ICollection<ModelGatewayOutputVM>> CreateRange10Async(IEnumerable<ModelGatewayCreateVM> body, CancellationToken cancellationToken);

    public Task ChangeDefaultModelGatewayAsync(string id, CancellationToken cancellationToken);

    public Task<int> CountModelGatewayAsync(CancellationToken cancellationToken);

}

