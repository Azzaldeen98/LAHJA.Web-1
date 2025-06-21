
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


 public  class MasterApiClient : BuildApiClient<MasterClient>  , IMasterApiClient {

  
    public MasterApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<LanguageOutputVM>> GetLanguages2Async(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetLanguages2Async(lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<LanguageOutputVM>> GetLanguageByCodeAllAsync(string code, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetLanguageByCodeAllAsync(code, lg, cancellationToken);
        });
                
    }


    public   async Task GetCategoryModelByName2Async(string name, string lg, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.GetCategoryModelByName2Async(name, lg, cancellationToken);
        });
                
    }


    public   async Task GetTypeByNameAsync(string name, string lg, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.GetTypeByNameAsync(name, lg, cancellationToken);
        });
                
    }


    public   async Task ActiveAsync(string lg, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.ActiveAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<DialectOutputVM> DialectAsync(string languageId, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.DialectAsync(languageId, lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<DialectOutputVM>> DialectsAsync(string languageId, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.DialectsAsync(languageId, lg, cancellationToken);
        });
                
    }


    public   async Task<AdvertisementOutputVM> AdvertisementsAsync(string id, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.AdvertisementsAsync(id, lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<AdvertisementOutputVM>> GetActiveAdvertisements2Async(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetActiveAdvertisements2Async(lg, cancellationToken);
        });
                
    }


    public   async Task<AdvertisementTabOutputVM> AdvertisementtabAsync(string id, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.AdvertisementtabAsync(id, lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<AdvertisementTabOutputVM>> AdvertisementtabsAsync(string advertisementId, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.AdvertisementtabsAsync(advertisementId, lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<LanguageOutputVM>> GetLanguages3Async(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetLanguages3Async(lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<LanguageOutputVM>> GetLanguageByCodeAll2Async(string code, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetLanguageByCodeAll2Async(code, lg, cancellationToken);
        });
                
    }


    public   async Task CreateLanguage2Async(LanguageCreateVM body, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.CreateLanguage2Async(body, cancellationToken);
        });
                
    }


    public   async Task GetCategoryModelByName3Async(string name, string lg, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.GetCategoryModelByName3Async(name, lg, cancellationToken);
        });
                
    }


    public   async Task CreateCategoryModel2Async(CategoryModelCreateVM body, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.CreateCategoryModel2Async(body, cancellationToken);
        });
                
    }


    public   async Task GetTypeByName2Async(string name, string lg, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.GetTypeByName2Async(name, lg, cancellationToken);
        });
                
    }


    public   async Task Active2Async(string lg, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.Active2Async(lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<TypeModelOutputVM>> CreateTypesAsync(TypeModelCreateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateTypesAsync(body, cancellationToken);
        });
                
    }


    public   async Task<DialectOutputVM> Dialect2Async(string languageId, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.Dialect2Async(languageId, lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<DialectOutputVM>> Dialects2Async(string languageId, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.Dialects2Async(languageId, lg, cancellationToken);
        });
                
    }


    public   async Task<AdvertisementOutputVM> Advertisements2Async(string id, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.Advertisements2Async(id, lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<AdvertisementOutputVM>> GetActiveAdvertisements3Async(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetActiveAdvertisements3Async(lg, cancellationToken);
        });
                
    }


    public   async Task<AdvertisementTabOutputVM> Advertisementtab2Async(string id, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.Advertisementtab2Async(id, lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<AdvertisementTabOutputVM>> Advertisementtabs2Async(string advertisementId, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.Advertisementtabs2Async(advertisementId, lg, cancellationToken);
        });
                
    }


}

