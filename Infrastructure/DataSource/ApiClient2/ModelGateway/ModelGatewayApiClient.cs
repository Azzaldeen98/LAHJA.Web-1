
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


 public  class ModelGatewayApiClient : BuildApiClient<ModelGatewayClient>  , IModelGatewayApiClient {

  
    public ModelGatewayApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<ModelGatewayOutputVM>> GetModelGatewaysAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetModelGatewaysAsync(cancellationToken);
        });
                
    }


    public   async Task<ModelGatewayOutputVM> CreateModelGatewayAsync(ModelGatewayCreateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateModelGatewayAsync(body, cancellationToken);
        });
                
    }


    public   async Task<ModelGatewayOutputVM> GetModelGatewayAsync(string id, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetModelGatewayAsync(id, cancellationToken);
        });
                
    }


    public   async Task<ModelGatewayOutputVM> UpdateModelGatewayAsync(string id, ModelGatewayUpdateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.UpdateModelGatewayAsync(id, body, cancellationToken);
        });
                
    }


    public   async Task DeleteModelGatewayAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.DeleteModelGatewayAsync(id, cancellationToken);
        });
                
    }


    public   async Task<ModelGatewayOutputVM> GetModelGatewayByLgAsync(ModelGatewayFilterVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetModelGatewayByLgAsync(body, cancellationToken);
        });
                
    }


    public   async Task<ICollection<ModelGatewayOutputVM>> GetModelGatewaysByLgAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetModelGatewaysByLgAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<ModelGatewayOutputVM>> CreateRange10Async(IEnumerable<ModelGatewayCreateVM> body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateRange10Async(body, cancellationToken);
        });
                
    }


    public   async Task ChangeDefaultModelGatewayAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.ChangeDefaultModelGatewayAsync(id, cancellationToken);
        });
                
    }


    public   async Task<int> CountModelGatewayAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CountModelGatewayAsync(cancellationToken);
        });
                
    }


}

