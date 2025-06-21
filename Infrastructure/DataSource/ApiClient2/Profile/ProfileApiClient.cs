
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


 public  class ProfileApiClient : BuildApiClient<ProfileClient>  , IProfileApiClient {

  
    public ProfileApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ApplicationUserOutputVM> GetUserAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetUserAsync(cancellationToken);
        });
                
    }


    public   async Task UpdateAsync(ApplicationUserUpdateVM body, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.UpdateAsync(body, cancellationToken);
        });
                
    }


    public   async Task<SubscriptionOutputVMIEnumerablePagedResponse> GetUserSubscriptionsAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetUserSubscriptionsAsync(cancellationToken);
        });
                
    }


    public   async Task<ICollection<ModelAiOutputVM>> ModelAisAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.ModelAisAsync(cancellationToken);
        });
                
    }


    public   async Task<ICollection<ServiceOutputVM>> ServicesAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.ServicesAsync(cancellationToken);
        });
                
    }


    public   async Task<ICollection<SpaceOutputVM>> SpacesSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.SpacesSubscriptionAsync(subscriptionId, cancellationToken);
        });
                
    }


    public   async Task<SpaceOutputVM> SpaceSubscriptionAsync(string subscriptionId, string spaceId, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.SpaceSubscriptionAsync(subscriptionId, spaceId, cancellationToken);
        });
                
    }


    public   async Task<RequestOutputVMPagedResponse> RequestsSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.RequestsSubscriptionAsync(subscriptionId, cancellationToken);
        });
                
    }


    public   async Task<RequestOutputVMPagedResponse> RequestsServiceAsync(string serviceId, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.RequestsServiceAsync(serviceId, cancellationToken);
        });
                
    }


}

