
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


public interface IProductApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<ProductResponse>> GetProductsAsync(string startingAfter, string endingBefore, long? limit, CancellationToken cancellationToken);

    public Task<ProductResponse> CreateProductAsync(ProductCreate body, CancellationToken cancellationToken);

    public Task<ProductResponse> GetProductAsync(string id, CancellationToken cancellationToken);

    public Task<ProductResponse> UpdateProductAsync(string id, ProductUpdate body, CancellationToken cancellationToken);

    public Task DeleteProductAsync(string id, CancellationToken cancellationToken);

    public Task<ICollection<ProductResponse>> SearchAllAsync(string query, int? limit, string page, CancellationToken cancellationToken);

}

