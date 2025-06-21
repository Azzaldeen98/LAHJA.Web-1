
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


 public  class CategoryTabApiClient : BuildApiClient<CategoryTabClient>  , ICategoryTabApiClient {

  
    public CategoryTabApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<CategoryTabOutputVM>> GetCategoryTabsAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetCategoryTabsAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<CategoryTabOutputVM> CreateCategoryTabAsync(CategoryTabCreateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateCategoryTabAsync(body, cancellationToken);
        });
                
    }


    public   async Task<ICollection<CategoryTabOutputVM>> GetActiveCategoryTabsAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetActiveCategoryTabsAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<CategoryTabOutputVM> GetCategoryTabAsync(string id, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetCategoryTabAsync(id, lg, cancellationToken);
        });
                
    }


    public   async Task<CategoryTabOutputVM> UpdateCategoryTabAsync(string id, CategoryTabUpdateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.UpdateCategoryTabAsync(id, body, cancellationToken);
        });
                
    }


    public   async Task DeleteCategoryTabAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.DeleteCategoryTabAsync(id, cancellationToken);
        });
                
    }


    public   async Task<CategoryTabOutputVM> GetCategoryTabByLanguageAsync(string id, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetCategoryTabByLanguageAsync(id, lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<CategoryTabOutputVM>> GetCategoryTabsByLanguageAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetCategoryTabsByLanguageAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<CategoryTabOutputVM>> CreateRange4Async(IEnumerable<CategoryTabCreateVM> body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateRange4Async(body, cancellationToken);
        });
                
    }


    public   async Task<int> CountCategoryTabsAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CountCategoryTabsAsync(cancellationToken);
        });
                
    }


}

