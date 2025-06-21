
using AutoMapper;
 using Shared.Wrapper;
using LAHJA.Helpers.Services;
using Domain.Entities.Plans.Response;
using Application.UseCase.Plans.Get;
using Application.UseCase.Plans;
using Domain.ShareData.Base;
using Application.Service;
using Application.Service.Plans;

namespace LAHJA.ApplicationLayer.Plans
{
    public class PlansClientService
    {
        private readonly PlansService plansService;




        public PlansClientService(PlansService plansService)
        {

            this.plansService = plansService;

        }

        public async Task<Result<SubscriptionPlan>> CreatePlanAsync(PlanCreate request)
        {
            return await plansService.CreatePlanAsync(request);

        }
        public async Task<Result<SubscriptionPlan>> UpdatePlanAsync(PlanUpdate request)
        {
            return await plansService.UpdatePlanAsync(request);

        }
        public async Task<Result<IEnumerable<ContainerPlans>>> GetCategories(FilterResponseData filter)
        {
            return await plansService.GetCategories(filter);

        }  
        
        public async Task<Result<IEnumerable<SubscriptionPlan>>> GetPlansAsync(FilterResponseData filter)
        {
            return await plansService.GetPlansAsync(filter);

        }


        public async Task<Result<SubscriptionPlan>> GetPlanAsync(string planId, string lg)
        {
            return await plansService.GetPlanAsync(planId, lg);

        }
        public async Task<Result<DeleteResponse>> DeletePlanAsync(string id)
        {
            return await plansService.DeletePlanAsync(id);

        }
    }
}
