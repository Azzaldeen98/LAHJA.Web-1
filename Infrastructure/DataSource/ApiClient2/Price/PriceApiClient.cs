
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


 public  class PriceApiClient : BuildApiClient<PriceClient>  , IPriceApiClient {

  
    public PriceApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<PriceResponse>> GetPricesAsync(string productId, bool? active, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetPricesAsync(productId, active, cancellationToken);
        });
                
    }


    public   async Task<PriceResponse> CreatePriceAsync(PriceCreate body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreatePriceAsync(body, cancellationToken);
        });
                
    }


    public   async Task<PriceResponse> GetPriceAsync(string id, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetPriceAsync(id, cancellationToken);
        });
                
    }


    public   async Task<PriceResponse> UpdatePriceAsync(string id, PriceUpdate body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.UpdatePriceAsync(id, body, cancellationToken);
        });
                
    }


    public   async Task SearchAsync(PriceSearchOptions body, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.SearchAsync(body, cancellationToken);
        });
                
    }


}

