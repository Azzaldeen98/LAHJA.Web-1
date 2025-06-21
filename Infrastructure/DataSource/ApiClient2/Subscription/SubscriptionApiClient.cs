
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


 public  class SubscriptionApiClient : BuildApiClient<SubscriptionClient>  , ISubscriptionApiClient {

  
    public SubscriptionApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<SubscriptionOutputVM>> GetSubscriptionsAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetSubscriptionsAsync(cancellationToken);
        });
                
    }


    public   async Task<SubscriptionOutputVM> GetSubscriptionAsync(string id, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetSubscriptionAsync(id, cancellationToken);
        });
                
    }


    public   async Task<SubscriptionOutputVM> GetMySubscriptionAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetMySubscriptionAsync(cancellationToken);
        });
                
    }


    public   async Task PauseCollectionAsync(SubscriptionUpdateRequest body, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.PauseCollectionAsync(body, cancellationToken);
        });
                
    }


    public   async Task ResumeCollectionAsync(CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.ResumeCollectionAsync(cancellationToken);
        });
                
    }


    public   async Task CancelSubscriptionAsync(CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.CancelSubscriptionAsync(cancellationToken);
        });
                
    }


    public   async Task CancelAtEndAsync(CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.CancelAtEndAsync(cancellationToken);
        });
                
    }


    public   async Task RenewSubscriptionAsync(CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.RenewSubscriptionAsync(cancellationToken);
        });
                
    }


    public   async Task ResumeSubscriptionAsync(SubscriptionResumeRequest body, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.ResumeSubscriptionAsync(body, cancellationToken);
        });
                
    }


    public   async Task CheckSubscriptionAsync(CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.CheckSubscriptionAsync(cancellationToken);
        });
                
    }


    public   async Task<ICollection<SubscriptionOutputVM>> GetAllSubscriptionsAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetAllSubscriptionsAsync(cancellationToken);
        });
                
    }


    public   async Task<SubscriptionOutputVM> GetOneSubscriptionAsync(string id, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetOneSubscriptionAsync(id, cancellationToken);
        });
                
    }


    public   async Task PauseCollection2Async(string id, SubscriptionUpdateRequest body, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.PauseCollection2Async(id, body, cancellationToken);
        });
                
    }


    public   async Task ResumeCollection2Async(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.ResumeCollection2Async(id, cancellationToken);
        });
                
    }


    public   async Task Cancel2Async(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.Cancel2Async(id, cancellationToken);
        });
                
    }


    public   async Task CancelAtEnd2Async(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.CancelAtEnd2Async(id, cancellationToken);
        });
                
    }


    public   async Task RenewAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.RenewAsync(id, cancellationToken);
        });
                
    }


    public   async Task ResumeAsync(string id, SubscriptionResumeRequest body, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.ResumeAsync(id, body, cancellationToken);
        });
                
    }


}

