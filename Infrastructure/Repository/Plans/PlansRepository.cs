
using AutoMapper;
using Domain.Entities.Plans.Response;
using Domain.Repository.Plans;
using Domain.ShareData;
using Domain.ShareData.Base;
 using Shared.Wrapper;
using Infrastructure.DataSource.ApiClient.Plans;
using Infrastructure.DataSource.Seeds;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Plans.Response;

using Shared.Settings;

namespace Infrastructure.Repository.Plans
{
    public class PlansRepository : IPlansRepository
    {
        private readonly SeedsPlans seedsPlans;
        private readonly PlansApiClient plansApiClient;
        private readonly IManageLanguageService manageLanguageService;


        private readonly SeedsPlansContainers seedsPlansContainers;
        private readonly SeedsSubscriptionsPlans seedsSubscriptionsPlans;

        private readonly IMapper _mapper;
        private readonly ApplicationModeService appModeService;
        public PlansRepository(
            IMapper mapper,
            SeedsPlans seedsPlans,
            ApplicationModeService appModeService,
            SeedsPlansContainers seedsPlansContainers,
            PlansApiClient plansApiClient,
            IManageLanguageService manageLanguageService,
            SeedsSubscriptionsPlans seedsSubscriptionsPlans)
        {

            //seedsPlans = new SeedsPlans();
            _mapper = mapper;
     
            this.seedsPlans = seedsPlans;
            this.appModeService = appModeService;
            this.seedsPlansContainers = seedsPlansContainers;
            this.plansApiClient = plansApiClient;
            this.manageLanguageService = manageLanguageService;
            this.seedsSubscriptionsPlans = seedsSubscriptionsPlans;

        }
        /// <summary>
        /// Work
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public async Task<Result<IEnumerable<SubscriptionPlan>>> GetPlansAsync(FilterResponseData filter)
        {

            //var plans=await planRepository.UserAsync(CancellationToken.None);
            var response = await ExecutorAppMode.ExecuteAsync(
            async () => await plansApiClient.GetPlansAsync(filter),
            async () =>
            {
                seedsSubscriptionsPlans.Language = await manageLanguageService.GetLanguageAsync();
                return Result<IEnumerable<SubscriptionPlanModel>>.Success(seedsSubscriptionsPlans.GetAll());
            });


            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<IEnumerable<SubscriptionPlan>>(response.Data) : null;
                return Result<IEnumerable<SubscriptionPlan>>.Success(result);
            }
            else
            {
                return Result<IEnumerable<SubscriptionPlan>>.Fail(response.Messages);
            }
        }

        public async Task<Result<SubscriptionPlan>> GetPlanAsync(string id, string lg)
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<SubscriptionPlanModel>>(
              async () =>await plansApiClient.GetPlanAsync(id,lg),
              async () => Result<SubscriptionPlanModel>.Success(seedsSubscriptionsPlans.getOne(id)));


            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<SubscriptionPlan>(response.Data) : null;
                return Result<SubscriptionPlan>.Success(result);
            }
            else
            {
                return Result<SubscriptionPlan>.Fail(response.Messages);
            }
        }


        /// <summary>
        /// work
        /// </summary>
        /// <returns></returns>
        public async Task<Result<IEnumerable<ContainerPlans>>> GetContainersAsync(FilterResponseData filter)
        {


            var response = await ExecutorAppMode.ExecuteAsync<Result<IEnumerable<ContainerPlansModel>>>(
            async () => {
                seedsPlansContainers.Language = await manageLanguageService.GetLanguageAsync();
                return Result<IEnumerable<ContainerPlansModel>>.Success(await seedsPlansContainers.getAllAsync());
            },
            async () =>
            {

                seedsPlansContainers.Language = await manageLanguageService.GetLanguageAsync();
                return Result<IEnumerable<ContainerPlansModel>>.Success(await seedsPlansContainers.getAllAsync());

            });


            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<IEnumerable<ContainerPlans>>(response.Data) : null;
                return Result<IEnumerable<ContainerPlans>>.Success(result);
            }
            else
            {
                return Result<IEnumerable<ContainerPlans>>.Fail(response.Messages);
            }
        }





        /// /////////////////////////////////////////////////////////////////////////////

        //public async Task<Result<IEnumerable<SubscriptionPlan>>> getBasicSubscriptionsPlansAsync()
        //{


        //    var response = await ExecutorAppMode.ExecuteAsync<Result<List<SubscriptionPlanModel>>>(
        //         async () => Result<List<SubscriptionPlanModel>>.Success(),
        //         async () =>
        //         {
        //             seedsPlansContainers.Language = await manageLanguageService.GetLanguageAsync();
        //             return Result<List<SubscriptionPlanModel>>.Success(seedsPlansContainers.GetBasicSubscriptionsPlans());
        //         }

        //     );
        //    if (response.Succeeded)
        //    {
        //        var result = (response.Data != null) ? _mapper.Map<IEnumerable<SubscriptionPlan>>(response.Data) : null;
        //        return Result<IEnumerable<SubscriptionPlan>>.Success(result);
        //    }
        //    else
        //    {
        //        return Result<IEnumerable<SubscriptionPlan>>.Fail(response.Messages);
        //    }


        //}


        //public async Task<Result<IEnumerable<SubscriptionPlan>>> getSubscriptionsPlansAsync(string containerId)
        //{

        //    var response = await ExecutorAppMode.ExecuteAsync<Result<IEnumerable<SubscriptionPlanModel>>>(
        //     async () => Result<IEnumerable<SubscriptionPlanModel>>.Success(await seedsPlansContainers.getSubscriptionsPlansAsync(containerId)),
        //     async () =>
        //     {
        //         seedsPlansContainers.Language = await manageLanguageService.GetLanguageAsync();
        //         return Result<IEnumerable<SubscriptionPlanModel>>.Success(await seedsPlansContainers.getSubscriptionsPlansAsync(containerId));
        //     });
        //    if (response.Succeeded)
        //    {
        //        var result = (response.Data != null) ? _mapper.Map<IEnumerable<SubscriptionPlan>>(response.Data) : null;
        //        return Result<IEnumerable<SubscriptionPlan>>.Success(result);
        //    }
        //    else
        //    {
        //        return Result<IEnumerable<SubscriptionPlan>>.Fail(response.Messages);
        //    }
        //}


        //public async Task<Result<IEnumerable<PlanFeature>>> getSubscriptionsPlansFeaturesAsync(string planId)
        //{
        //    var response = await ExecutorAppMode.ExecuteAsync<Result<IEnumerable<PlanFeatureModel>>>(
        //      async () => Result<IEnumerable<PlanFeatureModel>>.Success(),
        //      async () => Result<IEnumerable<PlanFeatureModel>>.Success(await seedsPlansContainers.getSubscriptionsPlansFeaturesAsync(planId)));


        //    if (response.Succeeded)
        //    {
        //        var result = (response.Data != null) ? _mapper.Map<IEnumerable<PlanFeature>>(response.Data) : null;
        //        return Result<IEnumerable<PlanFeature>>.Success(result);
        //    }
        //    else
        //    {
        //        return Result<IEnumerable<PlanFeature>>.Fail(response.Messages);
        //    }
        //}




        public async Task<Result<SubscriptionPlan>> CreatePlanAsync(PlanCreate request)
        {

            var model = _mapper.Map<PlanCreateModel>(request);

            var response = await plansApiClient.CreatePlanAsync(model);

            if (response.Succeeded)
            {
                var resModel = _mapper.Map<SubscriptionPlan>(response);

                return Result<SubscriptionPlan>.Success(resModel);
            }
            else
            {
                return Result<SubscriptionPlan>.Fail(response.Messages);
            }


        }

        public async Task<Result<SubscriptionPlan>> UpdatePlanAsync(PlanUpdate request)
        {

            var model = _mapper.Map<PlanUpdateModel>(request);

            var response = await plansApiClient.UpdatePlanAsync(model);

            if (response.Succeeded)
            {
                var resModel = _mapper.Map<SubscriptionPlan>(response);

                return Result<SubscriptionPlan>.Success(resModel);
            }
            else
            {
                return Result<SubscriptionPlan>.Fail(response.Messages);
            }


        }


        public async Task<Result<DeleteResponse>> DeletePlanAsync(string id)
        {
            var response = await plansApiClient.DeletePlanAsync(id);

            if (response.Succeeded)
            {
                var resModel = _mapper.Map<DeleteResponse>(response);

                return Result<DeleteResponse>.Success(resModel);
            }
            else
            {
                return Result<DeleteResponse>.Fail(response.Messages);
            }
        }


        /// <summary>
        /// ////////////////////////////////////////////////None Active //////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>
        //public async Task<Result<IEnumerable<PlanResponse>>> getAllPlansAsync()
        //{


        //    var response = await ExecutorAppMode.ExecuteAsync<Result<IEnumerable<PlanResponseModel>>>(
        //         async () => await plansApiClient.getAllPlansAsync(),
        //         async () =>
        //         {
        //             seedsPlansContainers.Language = await manageLanguageService.GetLanguageAsync();
        //             return Result<IEnumerable<PlanResponseModel>>.Success(await seedsPlans.getAllPlansAsync());
        //         }

        //     );
        //    if (response.Succeeded)
        //    {
        //        var result = (response.Data != null) ? _mapper.Map<IEnumerable<PlanResponse>>(response.Data) : null;
        //        return Result<IEnumerable<PlanResponse>>.Success(result);
        //    }
        //    else
        //    {
        //        return Result<IEnumerable<PlanResponse>>.Fail(response.Messages);
        //    }


        //}
        //public async Task<Result<IEnumerable<PlansContainerResponse>>> getAllPlansContainerAsync()
        //{


        //    var response = await ExecutorAppMode.ExecuteAsync<Result<IEnumerable<PlansContainerModel>>>(
        //    async () => Result<IEnumerable<PlansContainerModel>>.Success(await seedsPlansContainers.getAllContainersAsync()),
        //    async () =>
        //    {
        //        seedsPlansContainers.Language = await manageLanguageService.GetLanguageAsync();
        //        return Result<IEnumerable<PlansContainerModel>>.Success(await seedsPlansContainers.getAllContainersAsync());
        //    });


        //    if (response.Succeeded)
        //    {
        //        var result = (response.Data != null) ? _mapper.Map<IEnumerable<PlansContainerResponse>>(response.Data) : null;
        //        return Result<IEnumerable<PlansContainerResponse>>.Success(result);
        //    }
        //    else
        //    {
        //        return Result<IEnumerable<PlansContainerResponse>>.Fail(response.Messages);
        //    }
        //}
        //public async Task<Result<IEnumerable<PlansGroupResponse>>> getPlansGroupAsync()
        //{

        //    var response = await ExecutorAppMode.ExecuteAsync<Result<IEnumerable<PlansGroupModel>>>(
        //         async () => await plansApiClient.getPlansGroupAsync(),
        //          async () => Result<IEnumerable<PlansGroupModel>>.Success(await seedsPlans.getPlansGroupAsync()
        //          ));

        //    if (response.Succeeded)
        //    {
        //        var result = (response.Data != null) ? _mapper.Map<IEnumerable<PlansGroupResponse>>(response.Data) : null;
        //        return Result<IEnumerable<PlansGroupResponse>>.Success(result);
        //    }
        //    else
        //    {
        //        return Result<IEnumerable<PlansGroupResponse>>.Fail(response.Messages);
        //    }



        //}
        //public async Task<Result<IEnumerable<PlansGroupResponse>>> getPlansByGroupIdAsync(string id)
        //{

        //    var response = await ExecutorAppMode.ExecuteAsync<Result<IEnumerable<PlansGroupModel>>>(
        //         async () => await plansApiClient.getPlansGroupAsync(),
        //          async () => Result<IEnumerable<PlansGroupModel>>.Success(await seedsPlans.getPlansGroupAsync()
        //          ));

        //    if (response.Succeeded)
        //    {
        //        var result = (response.Data != null) ? _mapper.Map<IEnumerable<PlansGroupResponse>>(response.Data) : null;
        //        return Result<IEnumerable<PlansGroupResponse>>.Success(result);
        //    }
        //    else
        //    {
        //        return Result<IEnumerable<PlansGroupResponse>>.Fail(response.Messages);
        //    }



        //}

        //public async Task<Result<PlanResponse>> getPlanByIdAsync(string id)
        //{
        //    var response = await ExecutorAppMode.ExecuteAsync<Result<PlanResponseModel>>(
        //     async () => await plansApiClient.getPlanByIdAsync(id),
        //     async () => Result<PlanResponseModel>.Success(await seedsPlans.getPlanByIdAsync(id)));
        //    if (response.Succeeded)
        //    {
        //        var result = (response.Data != null) ? _mapper.Map<PlanResponse>(response.Data) : null;
        //        return Result<PlanResponse>.Success(result);
        //    }
        //    else
        //    {
        //        return Result<PlanResponse>.Fail(response.Messages);
        //    }
        //}
        //public async Task<Result<PlanInfoResponse>> GetPlanInfoByIdAsync(string id)
        //{



        //    var response = await ExecutorAppMode.ExecuteAsync<Result<PlanResponseModel>>(
        //    async () => Result<PlanResponseModel>.Success(new PlanResponseModel()),
        //    async () => Result<PlanResponseModel>.Success(await seedsPlans.getPlanByIdAsync(id)));

        //    if (response.Succeeded)
        //    {
        //        var result = (response.Data != null) ? _mapper.Map<PlanInfoResponse>(response.Data) : null;
        //        return Result<PlanInfoResponse>.Success(result);
        //    }
        //    else
        //    {
        //        return Result<PlanInfoResponse>.Fail(response.Messages);
        //    }

        //}

    }
}
