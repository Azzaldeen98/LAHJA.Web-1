
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


 public  class PaymentApiClient : BuildApiClient<PaymentClient>  , IPaymentApiClient {

  
    public PaymentApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<PaymentOutputVM>> GetPaymentsAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetPaymentsAsync(cancellationToken);
        });
                
    }


    public   async Task<PaymentOutputVM> CreatePaymentAsync(PaymentCreateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreatePaymentAsync(body, cancellationToken);
        });
                
    }


    public   async Task<PaymentOutputVM> UpdatePaymentAsync(PaymentUpdateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.UpdatePaymentAsync(body, cancellationToken);
        });
                
    }


    public   async Task<PaymentInfoVM> GetPaymentAsync(string id, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetPaymentAsync(id, cancellationToken);
        });
                
    }


    public   async Task DeletePaymentAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.DeletePaymentAsync(id, cancellationToken);
        });
                
    }


    public   async Task<PaymentOutputVM> GetPaymentByLgAsync(PaymentFilterVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetPaymentByLgAsync(body, cancellationToken);
        });
                
    }


    public   async Task<ICollection<PaymentOutputVM>> GetPaymentsByLgAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetPaymentsByLgAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<PaymentOutputVM>> CreateRange11Async(IEnumerable<PaymentCreateVM> body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateRange11Async(body, cancellationToken);
        });
                
    }


    public   async Task<int> CountPaymentAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CountPaymentAsync(cancellationToken);
        });
                
    }


}

