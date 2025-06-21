
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


public interface IPriceApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<PriceResponse>> GetPricesAsync(string productId, bool? active, CancellationToken cancellationToken);

    public Task<PriceResponse> CreatePriceAsync(PriceCreate body, CancellationToken cancellationToken);

    public Task<PriceResponse> GetPriceAsync(string id, CancellationToken cancellationToken);

    public Task<PriceResponse> UpdatePriceAsync(string id, PriceUpdate body, CancellationToken cancellationToken);

    public Task SearchAsync(PriceSearchOptions body, CancellationToken cancellationToken);

}

