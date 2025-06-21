
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


 public  class PlanApiClient : BuildApiClient<PlanClient>  , IPlanApiClient {

  
    public PlanApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }

    public async Task<PlanOutputVMIEnumerablePagedResponse> GetAllPlansAsync(string lg, CancellationToken cancellationToken)
    {

        return await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
            return await client.GetAllPlansAsync(lg, cancellationToken);
        });

    }
    public   async Task<ICollection<PlanOutputVM>> GetPlansAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetPlansAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<PlanOutputVM> GetPlanByIdAsync(string id, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetPlanByIdAsync(id, lg, cancellationToken);
        });
                
    }


    public   async Task<int> CountAllPlansAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CountAllPlansAsync(cancellationToken);
        });
                
    }


}

