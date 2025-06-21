
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


 public  class DialectApiClient : BuildApiClient<DialectClient>  , IDialectApiClient {

  
    public DialectApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<DialectOutputVM>> GetDialectsAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetDialectsAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<DialectOutputVM> CreateDialectAsync(DialectCreateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateDialectAsync(body, cancellationToken);
        });
                
    }


    public   async Task<DialectOutputVM> GetDialectAsync(string id, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetDialectAsync(id, lg, cancellationToken);
        });
                
    }


    public   async Task<DialectOutputVM> UpdateDialectAsync(string id, DialectUpdateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.UpdateDialectAsync(id, body, cancellationToken);
        });
                
    }


    public   async Task DeleteDialectAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.DeleteDialectAsync(id, cancellationToken);
        });
                
    }


    public   async Task<DialectOutputVM> GetDialectByLanguageAsync(string langId, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetDialectByLanguageAsync(langId, lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<DialectOutputVM>> GetDialectsByLanguageAsync(string langId, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetDialectsByLanguageAsync(langId, lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<DialectOutputVM>> CreateRange5Async(IEnumerable<DialectCreateVM> body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateRange5Async(body, cancellationToken);
        });
                
    }


    public   async Task<int> CountDialectAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CountDialectAsync(cancellationToken);
        });
                
    }


}

