
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


 public  class AdvertisementTabApiClient : BuildApiClient<AdvertisementTabClient>  , IAdvertisementTabApiClient {

  
    public AdvertisementTabApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<AdvertisementTabOutputVM>> GetAdvertisementTabsAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetAdvertisementTabsAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<AdvertisementTabOutputVM> CreateAdvertisementTabAsync(AdvertisementTabCreateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateAdvertisementTabAsync(body, cancellationToken);
        });
                
    }


    public   async Task<AdvertisementTabOutputVM> GetAdvertisementTabAsync(string id, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetAdvertisementTabAsync(id, lg, cancellationToken);
        });
                
    }


    public   async Task<AdvertisementTabOutputVM> UpdateAdvertisementTabAsync(string id, AdvertisementTabUpdateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.UpdateAdvertisementTabAsync(id, body, cancellationToken);
        });
                
    }


    public   async Task DeleteAdvertisementTabAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.DeleteAdvertisementTabAsync(id, cancellationToken);
        });
                
    }


    public   async Task<AdvertisementTabOutputVM> GetByAdvertisementIdAsync(string advertisementId, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetByAdvertisementIdAsync(advertisementId, lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<AdvertisementTabOutputVM>> GetAdvertisementTabsByLgAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetAdvertisementTabsByLgAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<AdvertisementTabOutputVM>> CreateRange2Async(IEnumerable<AdvertisementTabCreateVM> body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateRange2Async(body, cancellationToken);
        });
                
    }


    public   async Task<int> CountAdvertisementTabAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CountAdvertisementTabAsync(cancellationToken);
        });
                
    }


}

