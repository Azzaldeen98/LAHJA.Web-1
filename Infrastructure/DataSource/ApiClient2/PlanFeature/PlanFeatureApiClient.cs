
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


 public  class PlanFeatureApiClient : BuildApiClient<PlanFeatureClient>  , IPlanFeatureApiClient {

  
    public PlanFeatureApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task<ICollection<PlanFeatureOutputVM>> GetPlanFeaturesAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetPlanFeaturesAsync(cancellationToken);
        });
                
    }


    public   async Task<PlanFeatureOutputVM> CreatePlanFeatureAsync(PlanFeatureCreateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreatePlanFeatureAsync(body, cancellationToken);
        });
                
    }


    public   async Task<PlanFeatureOutputVM> UpdatePlanFeatureAsync(PlanFeatureUpdateVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.UpdatePlanFeatureAsync(body, cancellationToken);
        });
                
    }


    public   async Task<PlanFeatureOutputVMIEnumerablePagedResponse> GetPlanFeaturesByPlanIdAsync(string planId, string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetPlanFeaturesByPlanIdAsync(planId, lg, cancellationToken);
        });
                
    }


    public   async Task<PlanFeatureInfoVM> GetPlanFeatureAsync(string id, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetPlanFeatureAsync(id, cancellationToken);
        });
                
    }


    public   async Task DeletePlanFeatureAsync(string id, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.DeletePlanFeatureAsync(id, cancellationToken);
        });
                
    }


    public   async Task<PlanFeatureOutputVM> GetPlanFeatureByLgAsync(PlanFeatureFilterVM body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetPlanFeatureByLgAsync(body, cancellationToken);
        });
                
    }


    public   async Task<ICollection<PlanFeatureOutputVM>> GetPlanFeaturesByLgAsync(string lg, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.GetPlanFeaturesByLgAsync(lg, cancellationToken);
        });
                
    }


    public   async Task<ICollection<PlanFeatureOutputVM>> CreateRange12Async(IEnumerable<PlanFeatureCreateVM> body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CreateRange12Async(body, cancellationToken);
        });
                
    }


    public   async Task<int> CountPlanFeatureAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.CountPlanFeatureAsync(cancellationToken);
        });
                
    }


    public   async Task<int> NumberRequestsAsync(CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             return    await client.NumberRequestsAsync(cancellationToken);
        });
                
    }


}

