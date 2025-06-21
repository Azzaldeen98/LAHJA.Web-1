
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


 public  class ServiceApiClient : BuildApiClient<ServiceClient>  , IServiceApiClient {

  
    public ServiceApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<ServiceOutputVM>> GetServicesAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetServicesAsync(cancellationToken);
        });
                
    }


    public   async Task<ServiceOutputVM> CreateServiceAsync(ServiceCreateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateServiceAsync(body, cancellationToken);
        });
                
    }


    public   async Task<ServiceOutputVM> GetServiceAsync(string id, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetServiceAsync(id, cancellationToken);
        });
                
    }


    public   async Task<ServiceOutputVM> UpdateServiceAsync(string id, ServiceUpdateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.UpdateServiceAsync(id, body, cancellationToken);
        });
                
    }


    public   async Task DeleteServiceAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.DeleteServiceAsync(id, cancellationToken);
        });
                
    }


    public   async Task<ServiceOutputVM> GetServiceByLgAsync(ServiceFilterVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetServiceByLgAsync(body, cancellationToken);
        });
                
    }


    public   async Task<ICollection<ServiceOutputVM>> GetServicesByLgAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetServicesByLgAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<ServiceOutputVMPagedResponse> GetServicesByModelAiAsync(string modelAiId, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetServicesByModelAiAsync(modelAiId, lg, cancellationToken);
        });
                
    }


    public   async Task<ModelAiOutputVM> GetModelAiByServiceAsync(string serviceId, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetModelAiByServiceAsync(serviceId, lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<ServiceOutputVM>> CreateRange13Async(IEnumerable<ServiceCreateVM> body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateRange13Async(body, cancellationToken);
        });
                
    }


    public   async Task<int> CountServiceAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CountServiceAsync(cancellationToken);
        });
                
    }


}

