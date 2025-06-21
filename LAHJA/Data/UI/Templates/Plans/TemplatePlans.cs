using AutoMapper;
using Domain.ShareData.Base;
using Shared.Wrapper;
using LAHJA.Data.UI.Components;
using LAHJA.Data.UI.Components.Category;
using LAHJA.Data.UI.Components.Plan;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shared.Constants.Router;
using Client.Shared.Execution;
using AutoGenerator.Config.Attributes;
using Application.Service;
using LAHJA.Providers;
using LAHJA.UI.Components.General.DialogBox;
using Application.Services;
using Shared.Exceptions;

namespace LAHJA.Data.UI.Templates.Plans
{
    public interface IBuilderPlansComponent<T> : IBuilderComponents<T>
    {
        public Func<T, Task<Result<List<PlanViewModel>>>> GetPlans { get; set; }
        public Func<T, Task<Result<PlanViewModel>>> GetPlanById { get; set; }
        public Func<T, Task> SubmitContainerPlans { get; set; }
        //public Func<T, Task> SubmitCreatePlan { get; set; }
        //public Func<T, Task> SubmitUpdatePlan { get; set; }
        public Func<T, Task> SubmitSubscriptionPlan { get; set; }
    }

    public interface IBuilderPlansApi<T> : IBuilderApi<T>
    {
        //public Task<Result<List<CategoryComponent>>> GetAllCategories();
        public Task<PaginatedResult<PlanViewModel>> GetAllPlansAsync(string lg, CancellationToken cancellationToken);
        public Task<List<PlanViewModel>> GetPlansAsync(string lg, CancellationToken cancellationToken);
        public Task<PlanViewModel> GetPlanAsync(string lg, string planId, CancellationToken cancellationToken);
        //public Task<Result<PlanViewModel>> UpdatePlanAsync(T data);
        //public Task<Result<PlanViewModel>> CreatePlanAsync(T data);
        //public Task<Result<DeleteResponse>> DeletePlanAsync(T data);
    }

    public abstract class BuilderPlansApi<T, E> : BuilderApi<T, E>, IBuilderPlansApi<E>
    {
        public BuilderPlansApi(IMapper mapper, T service) : base(mapper, service)
        {
        }

        //public abstract Task<Result<List<CategoryComponent>>> GetAllCategories();
        public abstract Task<PaginatedResult<PlanViewModel>> GetAllPlansAsync(string lg,CancellationToken cancellationToken);
        public abstract Task<List<PlanViewModel>> GetPlansAsync(string lg, CancellationToken cancellationToken);
        public abstract Task<PlanViewModel> GetPlanAsync(string lg, string planId, CancellationToken cancellationToken);
        //public abstract Task<Result<PlanViewModel>> UpdatePlanAsync(E data);
        //public abstract Task<Result<PlanViewModel>> CreatePlanAsync(E data);
        //public abstract Task<Result<DeleteResponse>> DeletePlanAsync(E data);
    }

    public class BuilderPlansComponent<T> : IBuilderPlansComponent<T>
    {
        public Func<T, Task<Result<List<PlanViewModel>>>> GetPlans { get; set; }
        public Func<T, Task<Result<PlanViewModel>>> GetPlanById { get; set; }
        public Func<T, Task> SubmitContainerPlans { get; set; }
        public Func<T, Task> SubmitSubscriptionPlan { get; set; }
        public Func<T, Task> SubmitCreatePlan { get; set; }
        public Func<T, Task> SubmitUpdatePlan { get; set; }
    }

    public class TemplatePlansShare<T, E> : TemplateBase<T, E>
    {
        protected readonly NavigationManager navigation;
        protected readonly IDialogService dialogService;
        protected readonly ISnackbar Snackbar;
        protected IBuilderPlansApi<E> builderApi;
        private readonly IBuilderPlansComponent<E> builderComponents;
    
        public IBuilderPlansComponent<E> BuilderComponents { get => builderComponents; }

        public TemplatePlansShare(IMapper mapper, Helpers.Services.AuthService AuthService, T client, IBuilderPlansComponent<E> builderComponents, NavigationManager navigation, IDialogService dialogService, ISnackbar snackbar, ISafeInvoker safelyHandler) : base(mapper, AuthService, client, safelyHandler)
        {
            builderComponents = new BuilderPlansComponent<E>();
            this.navigation = navigation;
            this.dialogService = dialogService;
            this.Snackbar = snackbar;
            //this.builderApi = builderApi;
            this.builderComponents = builderComponents;
            //this.providerLanguage = providerLanguage;
        }
    }

    public class BuilderPlansApiClient : BuilderPlansApi<IPlanService, DataBuildPlansBase>, IBuilderPlansApi<DataBuildPlansBase>
    {
        public BuilderPlansApiClient(IMapper mapper, IPlanService service) : base(mapper, service)
        {
        }


        public override async Task<List<PlanViewModel>> GetPlansAsync(string lg, CancellationToken cancellationToken)
        {
            var res = await Service.getPlansAsync(lg, cancellationToken);

            var map= Mapper.Map<List<PlanViewModel>>(res);
            return map;


        }

        public override async Task<PaginatedResult<PlanViewModel>> GetAllPlansAsync(string lg, CancellationToken cancellationToken)
        {
            var res = await Service.getAllPlansAsync(lg,cancellationToken);
            if (res.Succeeded)
            {
                var data = Mapper.Map<List<PlanViewModel>>(res.Data);
                return PaginatedResult<PlanViewModel>.Success(data, res.TotalCount, res.PageNumber, res.PageSize, res.SortBy, res.SortDirection);
            }
            else
            {
                return PaginatedResult<PlanViewModel>.Failure(res.Messages);
            }
        }

        public override async Task<PlanViewModel> GetPlanAsync(string lg, string planId, CancellationToken cancellationToke)
        {
            var res = await Service.getByIdPlanAsync(lg, planId, cancellationToke);
            if (res != null)
            {
                return Mapper.Map<PlanViewModel>(res);
            }
            else
            {
                return null;
            }
        }

        
        
    }

    [AutoSafeInvoke]
    public class TemplatePlans : TemplatePlansShare<IPlanService, DataBuildPlansBase>
    {
        private readonly ISafeInvoker safeInvoker;
        private readonly ICancelableTaskExecutor taskExecutor;
    

        private List<CategoryComponent> _categories = new List<CategoryComponent>();
        private List<PlanViewModel> _plans = new List<PlanViewModel>();
        private List<PlanViewModel> _allPlans = new List<PlanViewModel>();
        private PlanViewModel _plan = new PlanViewModel();
        private readonly IProviderLanguage providerLanguage;

        public TemplatePlans(IMapper mapper, Helpers.Services.AuthService AuthService, ICancelableTaskExecutor taskExecutor, IPlanService service, 
            IBuilderPlansComponent<DataBuildPlansBase> builderComponents, NavigationManager navigation, IDialogService dialogService, ISnackbar snackbar, 
            ISafeInvoker safeInvoker, IServiceProvider provider, IProviderLanguage providerLanguage)
            : base(mapper, AuthService, service, builderComponents, navigation, dialogService, snackbar, safeInvoker)
        {
            this.safeInvoker = safeInvoker;
            this.BuilderComponents.GetPlans = getPlansAsync;
            this.BuilderComponents.GetPlanById = getPlanById;
            //this.BuilderComponents.SubmitSubscriptionPlan = OnSubmitSubscriptionPlan;
            //this.BuilderComponents.SubmitUpdatePlan = OnSubmitUpdatePlans;
            //this.BuilderComponents.SubmitCreatePlan = OnSubmitCreatePlans;
            this.builderApi = new BuilderPlansApiClient(mapper, service);
            this.providerLanguage = providerLanguage;
            this.taskExecutor = taskExecutor;

            //_self = provider.GetRequiredService<TemplatePlans>();
        }

        public List<CategoryComponent> Categories { get => _categories; }
        public List<PlanViewModel> SubscriptionPlans { get => _plans; }
        public List<PlanViewModel> AllSubscriptionPlans { get => _allPlans; }
        public PlanViewModel SubscriptionPlan { get => _plan; }
        public List<string> Errors { get => _errors; }

        //public async Task<Result<List<CategoryComponent>>> GetAllCategoriesAsync()
        //{
        //    return await safeInvoker.InvokeAsync(async () =>
        //    {
        //        return await builderApi.GetAllCategories();
        //    });
        //}

        [IgnoreSafeInvoke]
        private async Task<Result<List<PlanViewModel>>> getPlansAsync(DataBuildPlansBase buildData)
        {
            return await getPlansAsync(buildData.Take, buildData.PremiumPlanNumber, buildData.Lg);
        }

        //private  void InitializeCancellationToken()
        //{
        //    if (cancellationTokenSource == null || cancellationTokenSource.IsCancellationRequested)
        //    {
        //        cancellationTokenSource = new CancellationTokenSource();
        //    }

        //}
        //public void CancelCurrentTask()
        //{
        //    if (cancellationTokenSource != null && !cancellationTokenSource.IsCancellationRequested)
        //    {
        //        cancellationTokenSource.Cancel();
        //    }
        //}


        //private async Task<PaginatedResult<PlanViewModel>> getPlansAsync(int take, int premiumPlanNumber = 0, string lg = "en")
        //{
           
        //    return (await safeInvoker.InvokeAsync(async () =>
        //    {
        //      return await taskExecutor.RunAsync<PaginatedResult<PlanViewModel>?>(async (token) =>
        //        {

        //                var response = await builderApi.GetPlansAsync(providerLanguage.Language, token);
        //                if (response.Succeeded)
        //                {
        //                    if (premiumPlanNumber > 0 && take > 0)
        //                    {
        //                        var allPlans = response.Data.Take(take).ToList();
        //                        if (allPlans.Count() > premiumPlanNumber)
        //                        {
        //                            allPlans[premiumPlanNumber].ClassImport = "plan-import-card";
        //                            allPlans[premiumPlanNumber].HeaderImport = "textHeader";
        //                        }
        //                        return PaginatedResult<PlanViewModel>.Success(allPlans, response.TotalCount, response.PageNumber, response.PageSize, response.SortBy, response.SortDirection);
        //                    }
                                                    
        //                }

        //               return response;
              
        //        });
            
        //    }))?? PaginatedResult<PlanViewModel>.Success();
        //}\



        private async Task<Result<List<PlanViewModel>>> getPlansAsync(int take, int premiumPlanNumber = 0, string lg = "en")
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await taskExecutor.RunAsync(async (token) =>
                {
                    var response = await builderApi.GetPlansAsync(providerLanguage.Language, token);

                    if (response!=null)
                    {
                        var plans = response ?? new List<PlanViewModel>();

                        //  ÿ»Ìﬁ «· ‰”Ìﬁ «·Œ«’ ≈–«  Ê›—  «·‘—Êÿ
                        if (premiumPlanNumber > 0 && take > 0)
                        {
                            var allPlans = plans.Take(take).ToList();

                            if (allPlans.Count > premiumPlanNumber)
                            {
                                allPlans[premiumPlanNumber].ClassImport = "plan-import-card";
                                allPlans[premiumPlanNumber].HeaderImport = "textHeader";
                            }

                            //return PaginatedResult<PlanViewModel>.Success(
                            //    allPlans,
                            //    response.TotalCount,
                            //    response.PageNumber,
                            //    response.PageSize,
                            //    response.SortBy,
                            //    response.SortDirection
                            //);
                            return allPlans;
                        }

                        // ≈–« ·„   Õﬁﬁ ‘—Êÿ take √Ê premiumPlanNumber° ‰⁄Ìœ «·«” Ã«»… ﬂ„« ÂÌ
                        return plans;
                    }

                    throw new  NotFoundException("Not found");

                });

            });
        }

        [IgnoreSafeInvoke]
        public async Task<Result<List<PlanViewModel>>> getAllPlansAsync(FilterResponseData filter, int premiumPlanNumber = 0)
        {
            return await getPlansAsync(filter.Take, premiumPlanNumber, filter.lg);
        }

        //private async Task OnSubmitCreatePlans(DataBuildPlansBase dataBuildPlansBase)
        //{
        //    if (dataBuildPlansBase != null)
        //    {
        //        var response = await safeInvoker.InvokeAsync(async () => await builderApi.CreatePlanAsync(dataBuildPlansBase));
        //        if (response.Succeeded)
        //        {
        //        }
        //        else
        //        {
        //            _errors = response.Messages;
        //        }
        //    }
        //}

        //private async Task OnSubmitUpdatePlans(DataBuildPlansBase dataBuildPlansBase)
        //{
        //    if (dataBuildPlansBase != null)
        //    {
        //        //var response = await builderApi.UpdatePlanAsync(dataBuildPlansBase);
        //        var response = await safeInvoker.InvokeAsync(async () => await builderApi.UpdatePlanAsync(dataBuildPlansBase));
        //        if (response.Succeeded)
        //        {
        //        }
        //        else
        //        {
        //            _errors = response.Messages;
        //        }
        //    }
        //}

        public async Task OnSubmitSubscriptionPlan(DataBuildPlansBase dataBuildPlansBase)
        {
            await safeInvoker.InvokeAsync(async () =>
            {
                if (dataBuildPlansBase != null)
                {
                    navigation.NavigateTo($"{RouterPage.PAYMENT}/{dataBuildPlansBase.PlanId}");
                }
            });
        }

        private async Task<Result<PlanViewModel>> getPlanById(DataBuildPlansBase dataBuildPlansBase)
        {
            return (await safeInvoker.InvokeAsync(async () =>
            {
                return await taskExecutor.RunAsync<PlanViewModel>(async (token) =>
                {

     
                        if (dataBuildPlansBase != null && !string.IsNullOrWhiteSpace(dataBuildPlansBase.PlanId))
                        {
                            var response= await builderApi.GetPlanAsync(providerLanguage.Language, dataBuildPlansBase.PlanId, token);
                            return response;
                        }
                        else
                        {
                            throw new Exception("Plan id is Required");
                        
                        }
            });

            }))?? Result<PlanViewModel>.Success();
           
        }
    }
}