
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


 public  class FAQItemApiClient : BuildApiClient<FAQItemClient>  , IFAQItemApiClient {

  
    public FAQItemApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<FAQItemOutputVM>> GetFAQItemsAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetFAQItemsAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<FAQItemOutputVM> CreateFAQItemAsync(FAQItemCreateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateFAQItemAsync(body, cancellationToken);
        });
                
    }


    public   async Task<FAQItemOutputVM> GetFAQItemAsync(string id, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetFAQItemAsync(id, lg, cancellationToken);
        });
                
    }


    public   async Task<FAQItemOutputVM> UpdateFAQItemAsync(string id, FAQItemUpdateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.UpdateFAQItemAsync(id, body, cancellationToken);
        });
                
    }


    public   async Task DeleteFAQItemAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.DeleteFAQItemAsync(id, cancellationToken);
        });
                
    }


    public   async Task<FAQItemOutputVM> GetFAQItemByLgAsync(string id, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetFAQItemByLgAsync(id, lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<FAQItemOutputVM>> GetFAQItemsByLgAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetFAQItemsByLgAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<FAQItemOutputVM>> CreateRange6Async(IEnumerable<FAQItemCreateVM> body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateRange6Async(body, cancellationToken);
        });
                
    }


    public   async Task<int> CountFAQItemsAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CountFAQItemsAsync(cancellationToken);
        });
                
    }


}

