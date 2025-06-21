
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


 public  class ApplicationUserApiClient : BuildApiClient<ApplicationUserClient>  , IApplicationUserApiClient {

  
    public ApplicationUserApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<ApplicationUserOutputVM>> GetApplicationUsersAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetApplicationUsersAsync(cancellationToken);
        });
                
    }


    public   async Task<ApplicationUserOutputVM> GetApplicationUserAsync(string id, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetApplicationUserAsync(id, lg, cancellationToken);
        });
                
    }


    public   async Task DeleteApplicationUserAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.DeleteApplicationUserAsync(id, cancellationToken);
        });
                
    }


    public   async Task<ICollection<ApplicationUserOutputVM>> GetApplicationUsersByLgAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetApplicationUsersByLgAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<string> AssignServiceAsync(AssignServiceRequestVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.AssignServiceAsync(body, cancellationToken);
        });
                
    }


    public   async Task<string> AssignModelAiAsync(AssignModelRequestVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.AssignModelAiAsync(body, cancellationToken);
        });
                
    }


    public   async Task<int> CountApplicationUserAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CountApplicationUserAsync(cancellationToken);
        });
                
    }


}

