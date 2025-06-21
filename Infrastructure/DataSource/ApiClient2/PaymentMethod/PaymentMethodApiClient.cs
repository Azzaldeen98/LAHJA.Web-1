
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


 public  class PaymentMethodApiClient : BuildApiClient<PaymentMethodClient>  , IPaymentMethodApiClient {

  
    public PaymentMethodApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<PaymentMethodResponse>> GetMethodsAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetMethodsAsync(cancellationToken);
        });
                
    }


    public   async Task<CustomerResponse> UpdateBillingInformationAsync(BillingInformationRequest body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.UpdateBillingInformationAsync(body, cancellationToken);
        });
                
    }


    public   async Task MakePaymentMethodDefaultAsync(string paymentMethodId, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.MakePaymentMethodDefaultAsync(paymentMethodId, cancellationToken);
        });
                
    }


    public   async Task DeleteMethodAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.DeleteMethodAsync(id, cancellationToken);
        });
                
    }


    public   async Task GetSetupIntentsAsync(CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.GetSetupIntentsAsync(cancellationToken);
        });
                
    }


    public   async Task CancelAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.CancelAsync(id, cancellationToken);
        });
                
    }


    public   async Task ConfirmAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.ConfirmAsync(id, cancellationToken);
        });
                
    }


    public   async Task<ResponseClientSecret> CreatePaymentMethodAsync(PaymentMethodsRequest body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreatePaymentMethodAsync(body, cancellationToken);
        });
                
    }


}

