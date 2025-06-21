
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


 public  class TypeModelApiClient : BuildApiClient<TypeModelClient>  , ITypeModelApiClient {

  
    public TypeModelApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<TypeModelOutputVM>> GetTypeModelsAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetTypeModelsAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<TypeModelOutputVM> CreateTypeModelAsync(TypeModelCreateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateTypeModelAsync(body, cancellationToken);
        });
                
    }


    public   async Task<TypeModelOutputVM> GetTypeModelAsync(string id, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetTypeModelAsync(id, lg, cancellationToken);
        });
                
    }


    public   async Task<TypeModelOutputVM> UpdateTypeModelAsync(string id, TypeModelUpdateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.UpdateTypeModelAsync(id, body, cancellationToken);
        });
                
    }


    public   async Task DeleteTypeModelAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.DeleteTypeModelAsync(id, cancellationToken);
        });
                
    }


    public   async Task<TypeModelOutputVM> GetTypeModelByNameAsync(string name, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetTypeModelByNameAsync(name, lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<TypeModelOutputVM>> GetActiveTypeModelsAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetActiveTypeModelsAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<TypeModelOutputVM> GetTypeModelByLanguageAsync(string id, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetTypeModelByLanguageAsync(id, lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<TypeModelOutputVM>> GetTypeModelsByLanguageAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetTypeModelsByLanguageAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<TypeModelOutputVM>> CreateRange17Async(IEnumerable<TypeModelCreateVM> body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateRange17Async(body, cancellationToken);
        });
                
    }


    public   async Task<int> CountTypeModelsAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CountTypeModelsAsync(cancellationToken);
        });
                
    }


}

