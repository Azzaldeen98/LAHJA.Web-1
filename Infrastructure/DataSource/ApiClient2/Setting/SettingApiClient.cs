
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


 public  class SettingApiClient : BuildApiClient<SettingClient>  , ISettingApiClient {

  
    public SettingApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<SettingOutputVM>> GetSettingsAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetSettingsAsync(cancellationToken);
        });
                
    }


    public   async Task<SettingOutputVM> CreateSettingAsync(SettingCreateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateSettingAsync(body, cancellationToken);
        });
                
    }


    public   async Task<SettingInfoVM> GetSettingAsync(string id, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetSettingAsync(id, cancellationToken);
        });
                
    }


    public   async Task DeleteSettingAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.DeleteSettingAsync(id, cancellationToken);
        });
                
    }


    public   async Task<SettingOutputVM> GetSettingByLgAsync(SettingFilterVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetSettingByLgAsync(body, cancellationToken);
        });
                
    }


    public   async Task<ICollection<SettingOutputVM>> GetSettingsByLgAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetSettingsByLgAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<SettingOutputVM>> CreateRange15Async(IEnumerable<SettingCreateVM> body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateRange15Async(body, cancellationToken);
        });
                
    }


    public   async Task<SettingOutputVM> UpdateSettingAsync(string name, SettingUpdateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.UpdateSettingAsync(name, body, cancellationToken);
        });
                
    }


    public   async Task<int> CountSettingAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CountSettingAsync(cancellationToken);
        });
                
    }


}

