
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


 public  class RequestApiClient : BuildApiClient<RequestClient>  , IRequestApiClient {

  
    public RequestApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<RequestOutputVM>> GetRequests2Async(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetRequests2Async(cancellationToken);
        });
                
    }


    public   async Task<RequestOutputVM> CreateRequestAsync(RequestCreateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateRequestAsync(body, cancellationToken);
        });
                
    }


    public   async Task<RequestOutputVM> GetRequestAsync(string id, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetRequestAsync(id, cancellationToken);
        });
                
    }


    public   async Task<RequestOutputVM> UpdateRequestAsync(string id, RequestUpdateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.UpdateRequestAsync(id, body, cancellationToken);
        });
                
    }


    public   async Task DeleteRequestAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.DeleteRequestAsync(id, cancellationToken);
        });
                
    }


    public   async Task<ICollection<RequestOutputVM>> GetRequestsByLgAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetRequestsByLgAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<EventRequestOutputVM> CreateEventAsync(EventRequestCreateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateEventAsync(body, cancellationToken);
        });
                
    }


    public   async Task<int> CountRequestAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CountRequestAsync(cancellationToken);
        });
                
    }


}

