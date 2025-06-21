using Domain.Entities.Plans.Response;
using Domain.ShareData.Base;
 using Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.Plans
{
    public interface IPlansRepository
    {
        Task<Result<IEnumerable<SubscriptionPlan>>> GetPlansAsync(FilterResponseData filter);
        Task<Result<SubscriptionPlan>> GetPlanAsync(string id,string lg);
        Task<Result<SubscriptionPlan>> CreatePlanAsync(PlanCreate request);
        Task<Result<SubscriptionPlan>> UpdatePlanAsync(PlanUpdate request);
        Task<Result<DeleteResponse>> DeletePlanAsync(string id);

        Task<Result<IEnumerable<ContainerPlans>>> GetContainersAsync(FilterResponseData filter);
        //Task<Result<IEnumerable<SubscriptionPlan>>> getBasicSubscriptionsPlansAsync();
        //public Task<Result<PlanInfoResponse>> GetPlanInfoByIdAsync(string id);
        //public Task<Result<IEnumerable<PlansContainerResponse>>> getAllPlansContainerAsync();
        //public Task<Result<IEnumerable<SubscriptionPlan>>> getSubscriptionsPlansAsync(string containerId);
        //public Task<Result<IEnumerable<SubscriptionPlan>>> getAllSubscriptionsPlansAsync(int skip = 0, int take = 0);
        //public Task<Result<IEnumerable<PlanFeature>>> getSubscriptionsPlansFeaturesAsync(string planId);
        //public Task<Result<SubscriptionPlan>> getOneSubscriptionsPlanAsync(string planId);
        //public Task<Result<IEnumerable<ContainerPlans>>> getAllContainersPlansAsync();
        //public Task<Result<IEnumerable<PlansGroupResponse>>> getPlansGroupAsync();


    }
}
