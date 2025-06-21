
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


 public  class ProductApiClient : BuildApiClient<ProductClient>  , IProductApiClient {

  
    public ProductApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<ProductResponse>> GetProductsAsync(string startingAfter, string endingBefore, long? limit, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetProductsAsync(startingAfter, endingBefore, limit, cancellationToken);
        });
                
    }


    public   async Task<ProductResponse> CreateProductAsync(ProductCreate body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateProductAsync(body, cancellationToken);
        });
                
    }


    public   async Task<ProductResponse> GetProductAsync(string id, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetProductAsync(id, cancellationToken);
        });
                
    }


    public   async Task<ProductResponse> UpdateProductAsync(string id, ProductUpdate body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.UpdateProductAsync(id, body, cancellationToken);
        });
                
    }


    public   async Task DeleteProductAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.DeleteProductAsync(id, cancellationToken);
        });
                
    }


    public   async Task<ICollection<ProductResponse>> SearchAllAsync(string query, int? limit, string page, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.SearchAllAsync(query, limit, page, cancellationToken);
        });
                
    }


}

