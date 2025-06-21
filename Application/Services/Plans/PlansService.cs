using Application.UseCase.Plans;
using Application.UseCase.Plans.Get;
using Domain.Entities.Plans.Response;
using Domain.ShareData.Base;
 using Shared.Wrapper;
using Infrastructure.Models.Profile.Response;

namespace Application.Service.Plans
{
    public class PlansService
    {
        private readonly GetPlansUseCase getPlansUseCase;
        private readonly GetPlanUseCase getPlanUseCase;
        private readonly UpdatePlanUseCase updatePlanUseCase;
        private readonly CreatePlanUseCase createPlanUseCase;
        private readonly DeletePlanUseCase deletePlanUseCase;
        private readonly GetAllContainersPlansUseCase _getContainersUseCase;



        public PlansService(GetPlansUseCase getPlansUseCase, GetPlanUseCase getPlanUseCase, UpdatePlanUseCase updatePlanUseCase, CreatePlanUseCase createPlanUseCase, DeletePlanUseCase deletePlanUseCase, GetAllContainersPlansUseCase getAllContainersPlansUseCase)
        {
            this.getPlansUseCase = getPlansUseCase;
            this.getPlanUseCase = getPlanUseCase;
            this.updatePlanUseCase = updatePlanUseCase;
            this.createPlanUseCase = createPlanUseCase;
            this.deletePlanUseCase = deletePlanUseCase;
            _getContainersUseCase = getAllContainersPlansUseCase;
        }






        public async Task<Result<SubscriptionPlan>> CreatePlanAsync(PlanCreate request)
        {
            return await createPlanUseCase.ExecuteAsync(request);

        }
        public async Task<Result<SubscriptionPlan>> UpdatePlanAsync(PlanUpdate request)
        {
            return await updatePlanUseCase.ExecuteAsync(request);

        }
        public async Task<Result<IEnumerable<SubscriptionPlan>>> GetPlansAsync(FilterResponseData filter)
        {
            return await getPlansUseCase.ExecuteAsync(filter);

        }   
        public async Task<Result<IEnumerable<ContainerPlans>>> GetCategories(FilterResponseData filter)
        {
            return await _getContainersUseCase.ExecuteAsync(filter);

        }
   
    
        public async Task<Result<SubscriptionPlan>> GetPlanAsync(string planId,string lg)
        {
            return await getPlanUseCase.ExecuteAsync(planId,lg);

        }
        public async Task<Result<DeleteResponse>> DeletePlanAsync(string id)
        {
            return await deletePlanUseCase.ExecuteAsync(id);

        }
        
    } 
}
