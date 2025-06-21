
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


 public  class ModelAiApiClient : BuildApiClient<ModelAiClient>  , IModelAiApiClient {

  
    public ModelAiApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<ModelAiOutputVM>> GetModelAisAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetModelAisAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<ModelAiOutputVM> CreateModelAiAsync(ModelAiCreateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateModelAiAsync(body, cancellationToken);
        });
                
    }


    public   async Task<ModelAiOutputVM> GetModelAiAsync(string id, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetModelAiAsync(id, lg, cancellationToken);
        });
                
    }


    public   async Task<ModelAiOutputVM> UpdateModelAiAsync(string id, ModelAiUpdateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.UpdateModelAiAsync(id, body, cancellationToken);
        });
                
    }


    public   async Task DeleteModelAiAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.DeleteModelAiAsync(id, cancellationToken);
        });
                
    }


    public   async Task<ICollection<ModelAiOutputVM>> GetModelsByTypeAsync(string type, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetModelsByTypeAsync(type, cancellationToken);
        });
                
    }


    public   async Task<ICollection<string>> GetCategoriesByTypeAsync(string type, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetCategoriesByTypeAsync(type, cancellationToken);
        });
                
    }


    public   async Task<ICollection<string>> GetLanguagesByAsync(string type, string category, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetLanguagesByAsync(type, category, cancellationToken);
        });
                
    }


    public   async Task<ICollection<ModelAiOutputVM>> GetModelsByCategoryAsync(string category, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetModelsByCategoryAsync(category, cancellationToken);
        });
                
    }


    public   async Task<ModelAiOutputVMPagedResponse> FilterMaodelAiAsync(ModelAiFilterVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.FilterMaodelAiAsync(body, cancellationToken);
        });
                
    }


    public   async Task<ICollection<ModelAiOutputVM>> GetModelAisByLanguageAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetModelAisByLanguageAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<ModelAiOutputVM>> CreateRange9Async(IEnumerable<ModelAiCreateVM> body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateRange9Async(body, cancellationToken);
        });
                
    }


    public   async Task<int> CountModelAisAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CountModelAisAsync(cancellationToken);
        });
                
    }


}

