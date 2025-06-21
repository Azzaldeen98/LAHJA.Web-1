
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


 public  class AdvertisementApiClient : BuildApiClient<AdvertisementClient>  , IAdvertisementApiClient {

  
    public AdvertisementApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<AdvertisementOutputVM>> GetAdvertisementsAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetAdvertisementsAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<AdvertisementOutputVM> CreateAdvertisementAsync(AdvertisementCreateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateAdvertisementAsync(body, cancellationToken);
        });
                
    }


    public   async Task<ICollection<AdvertisementOutputVM>> GetActiveAdvertisementsAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetActiveAdvertisementsAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<AdvertisementOutputVM> GetAdvertisementAsync(string id, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetAdvertisementAsync(id, lg, cancellationToken);
        });
                
    }


    public   async Task<AdvertisementOutputVM> UpdateAdvertisementAsync(string id, AdvertisementUpdateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.UpdateAdvertisementAsync(id, body, cancellationToken);
        });
                
    }


    public   async Task DeleteAdvertisementAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.DeleteAdvertisementAsync(id, cancellationToken);
        });
                
    }


    public   async Task<ICollection<AdvertisementOutputVM>> GetAdvertisementsByLgAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetAdvertisementsByLgAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<AdvertisementOutputVM>> CreateRangeAsync(IEnumerable<AdvertisementCreateVM> body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateRangeAsync(body, cancellationToken);
        });
                
    }


    public   async Task<int> CountAdvertisementAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CountAdvertisementAsync(cancellationToken);
        });
                
    }


}

