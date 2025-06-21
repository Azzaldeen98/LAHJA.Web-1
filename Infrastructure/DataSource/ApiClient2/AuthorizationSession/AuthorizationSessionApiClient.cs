
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


 public  class AuthorizationSessionApiClient : BuildApiClient<AuthorizationSessionClient>  , IAuthorizationSessionApiClient {

  
    public AuthorizationSessionApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<AuthorizationSessionOutputVM>> GetAuthorizationSessionsAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetAuthorizationSessionsAsync(cancellationToken);
        });
                
    }


    public   async Task<AuthorizationSessionOutputVM> CreateAuthorizationSessionAsync(AuthorizationSessionCreateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateAuthorizationSessionAsync(body, cancellationToken);
        });
                
    }


    public   async Task<AuthorizationSessionOutputVM> GetAuthorizationSessionAsync(string id, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetAuthorizationSessionAsync(id, lg, cancellationToken);
        });
                
    }


    public   async Task DeleteAuthorizationSessionAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.DeleteAuthorizationSessionAsync(id, cancellationToken);
        });
                
    }


    public   async Task<ICollection<AuthorizationSessionOutputVM>> GetAuthorizationSessionsByLgAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetAuthorizationSessionsByLgAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<AuthorizationSessionCoreResponse> AuthorizationSessionAsync(ValidateTokenRequest body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.AuthorizationSessionAsync(body, cancellationToken);
        });
                
    }


    public   async Task<AuthorizationSessionOutputVM> CreateForDashboardAsync(CreateAuthorizationForDashboard body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateForDashboardAsync(body, cancellationToken);
        });
                
    }


    public   async Task<AuthorizationSessionOutputVM> CreateForListServicesAsync(CreateAuthorizationForListServices body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateForListServicesAsync(body, cancellationToken);
        });
                
    }


    public   async Task<AuthorizationSessionOutputVM> CreateForAllServicesAsync(CreateAuthorizationForServices body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateForAllServicesAsync(body, cancellationToken);
        });
                
    }


    public   async Task<int> CountAuthorizationSessionAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CountAuthorizationSessionAsync(cancellationToken);
        });
                
    }


    public   async Task<string> SimulationPlatFormAsync(EncryptTokenRequest body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.SimulationPlatFormAsync(body, cancellationToken);
        });
                
    }


    public   async Task<string> SimulationCoreAsync(string encrptedToken, string coreToken, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.SimulationCoreAsync(encrptedToken, coreToken, cancellationToken);
        });
                
    }


    public   async Task ValidateWebTokenAsync(string token, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.ValidateWebTokenAsync(token, cancellationToken);
        });
                
    }


    public   async Task ValidateCreateTokenAsync(string token, string coreToken, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.ValidateCreateTokenAsync(token, coreToken, cancellationToken);
        });
                
    }


    public   async Task ValidateCoreTokenAsync(string token, string coreToken, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.ValidateCoreTokenAsync(token, coreToken, cancellationToken);
        });
                
    }


    public   async Task PauseAuthorizationSessionAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.PauseAuthorizationSessionAsync(id, cancellationToken);
        });
                
    }


    public   async Task ResumeAuthorizationSessionAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.ResumeAuthorizationSessionAsync(id, cancellationToken);
        });
                
    }


}

