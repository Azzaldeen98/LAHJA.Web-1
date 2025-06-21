
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


 public  class CategoryModelApiClient : BuildApiClient<CategoryModelClient>  , ICategoryModelApiClient {

  
    public CategoryModelApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<CategoryModelOutputVM>> GetCategoryModelsAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetCategoryModelsAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<CategoryModelOutputVM> CreateCategoryModelAsync(CategoryModelCreateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateCategoryModelAsync(body, cancellationToken);
        });
                
    }


    public   async Task<CategoryModelOutputVM> GetCategoryModelAsync(string id, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetCategoryModelAsync(id, lg, cancellationToken);
        });
                
    }


    public   async Task<CategoryModelOutputVM> UpdateCategoryModelAsync(string id, CategoryModelUpdateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.UpdateCategoryModelAsync(id, body, cancellationToken);
        });
                
    }


    public   async Task DeleteCategoryModelAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.DeleteCategoryModelAsync(id, cancellationToken);
        });
                
    }


    public   async Task<CategoryModelOutputVM> GetCategoryModelByNameAsync(string name, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetCategoryModelByNameAsync(name, lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<CategoryModelOutputVM>> GetCategoryModelsByLgAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetCategoryModelsByLgAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<CategoryModelOutputVM>> CreateRange3Async(IEnumerable<CategoryModelCreateVM> body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateRange3Async(body, cancellationToken);
        });
                
    }


    public   async Task<int> CountCategoryModelAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CountCategoryModelAsync(cancellationToken);
        });
                
    }


}

