
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


 public  class WebhookApiClient : BuildApiClient<WebhookClient>  , IWebhookApiClient {

  
    public WebhookApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task WebhookAsync(CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.WebhookAsync(cancellationToken);
        });
                
    }


}

