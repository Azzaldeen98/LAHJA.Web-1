
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


 public  class LanguageApiClient : BuildApiClient<LanguageClient>  , ILanguageApiClient {

  
    public LanguageApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<LanguageOutputVM>> GetLanguagesAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetLanguagesAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<LanguageOutputVM> CreateLanguageAsync(LanguageCreateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateLanguageAsync(body, cancellationToken);
        });
                
    }


    public   async Task<LanguageOutputVM> GetLanguageAsync(string id, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetLanguageAsync(id, cancellationToken);
        });
                
    }


    public   async Task<LanguageOutputVM> UpdateLanguageAsync(string id, LanguageUpdateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.UpdateLanguageAsync(id, body, cancellationToken);
        });
                
    }


    public   async Task DeleteLanguageAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.DeleteLanguageAsync(id, cancellationToken);
        });
                
    }


    public   async Task<LanguageOutputVM> GetLanguageByLgAsync(string id, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetLanguageByLgAsync(id, lg, cancellationToken);
        });
                
    }


    public   async Task<LanguageOutputVM> GetLanguageByCodeAsync(string code, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetLanguageByCodeAsync(code, lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<LanguageOutputVM>> GetLanguagesByLgAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetLanguagesByLgAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<LanguageOutputVM>> CreateRange8Async(IEnumerable<LanguageCreateVM> body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateRange8Async(body, cancellationToken);
        });
                
    }


    public   async Task<int> CountLanguageAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CountLanguageAsync(cancellationToken);
        });
                
    }


}

