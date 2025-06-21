
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


 public  class InvoiceApiClient : BuildApiClient<InvoiceClient>  , IInvoiceApiClient {

  
    public InvoiceApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<InvoiceOutputVM>> GetInvoicesAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetInvoicesAsync(cancellationToken);
        });
                
    }


    public   async Task<InvoiceOutputVM> CreateInvoiceAsync(InvoiceCreateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateInvoiceAsync(body, cancellationToken);
        });
                
    }


    public   async Task<InvoiceOutputVM> UpdateInvoiceAsync(InvoiceUpdateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.UpdateInvoiceAsync(body, cancellationToken);
        });
                
    }


    public   async Task<InvoiceInfoVM> GetInvoiceAsync(string id, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetInvoiceAsync(id, cancellationToken);
        });
                
    }


    public   async Task DeleteInvoiceAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.DeleteInvoiceAsync(id, cancellationToken);
        });
                
    }


    public   async Task<InvoiceOutputVM> GetInvoiceByLgAsync(InvoiceFilterVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetInvoiceByLgAsync(body, cancellationToken);
        });
                
    }


    public   async Task<ICollection<InvoiceOutputVM>> GetInvoicesByLgAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetInvoicesByLgAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<InvoiceOutputVM>> CreateRange7Async(IEnumerable<InvoiceCreateVM> body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateRange7Async(body, cancellationToken);
        });
                
    }


    public   async Task<int> CountInvoiceAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CountInvoiceAsync(cancellationToken);
        });
                
    }


}

