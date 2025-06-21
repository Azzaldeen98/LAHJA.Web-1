
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


 public  class SpaceApiClient : BuildApiClient<SpaceClient>  , ISpaceApiClient {

  
    public SpaceApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<SpaceOutputVM>> GetSpacesAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetSpacesAsync(cancellationToken);
        });
                
    }


    public   async Task<SpaceOutputVM> CreateSpaceAsync(SpaceCreateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateSpaceAsync(body, cancellationToken);
        });
                
    }


    public   async Task<SpaceOutputVM> GetSpaceAsync(string id, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetSpaceAsync(id, cancellationToken);
        });
                
    }


    public   async Task<SpaceOutputVM> UpdateSpaceAsync(string id, SpaceUpdateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.UpdateSpaceAsync(id, body, cancellationToken);
        });
                
    }


    public   async Task DeleteSpaceAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.DeleteSpaceAsync(id, cancellationToken);
        });
                
    }


    public   async Task<SpaceOutputVM> GetSpaceByLgAsync(SpaceFilterVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetSpaceByLgAsync(body, cancellationToken);
        });
                
    }


    public   async Task<ICollection<SpaceOutputVM>> GetSpacesByLgAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetSpacesByLgAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<SpaceOutputVM>> CreateRange16Async(IEnumerable<SpaceCreateVM> body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateRange16Async(body, cancellationToken);
        });
                
    }


    public   async Task<int> CountSpaceAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CountSpaceAsync(cancellationToken);
        });
                
    }


}

