using Infrastructure.Nswag;
using Infrastructure.Share.Invoker;
using AutoMapper;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClientFactory;
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
            var client = await GetBasicApiClient();
             return new List<PlanOutputVM>();// await client.GetPlansAsync(lg,cancellationToken);
        });
                
    }


    public   async Task<PlanOutputVM> GetPlanByIdAsync(string id, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetBasicApiClient();
             return    await client.GetPlanByIdAsync(id, lg, cancellationToken);
        });
                
    }


    public   async Task<int> CountAllPlansAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetBasicApiClient();
             return    await client.CountAllPlansAsync(cancellationToken);
        });
                
    }


}

