
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


 public  class ServiceMethodApiClient : BuildApiClient<ServiceMethodClient>  , IServiceMethodApiClient {

  
    public ServiceMethodApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<ServiceMethodOutputVM>> GetServiceMethodsAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetServiceMethodsAsync(cancellationToken);
        });
                
    }


    public   async Task<ServiceMethodOutputVM> CreateServiceMethodAsync(ServiceMethodCreateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateServiceMethodAsync(body, cancellationToken);
        });
                
    }


    public   async Task<ServiceMethodInfoVM> GetServiceMethodAsync(string id, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetServiceMethodAsync(id, cancellationToken);
        });
                
    }


    public   async Task<ServiceMethodOutputVM> UpdateServiceMethodAsync(string id, ServiceMethodUpdateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.UpdateServiceMethodAsync(id, body, cancellationToken);
        });
                
    }


    public   async Task DeleteServiceMethodAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.DeleteServiceMethodAsync(id, cancellationToken);
        });
                
    }


    public   async Task<ServiceMethodOutputVM> GetServiceMethodByLgAsync(ServiceMethodFilterVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetServiceMethodByLgAsync(body, cancellationToken);
        });
                
    }


    public   async Task<ICollection<ServiceMethodOutputVM>> GetServiceMethodsByLgAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetServiceMethodsByLgAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<ServiceMethodOutputVM>> CreateRange14Async(IEnumerable<ServiceMethodCreateVM> body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateRange14Async(body, cancellationToken);
        });
                
    }


    public   async Task<int> CountServiceMethodAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CountServiceMethodAsync(cancellationToken);
        });
                
    }


}

