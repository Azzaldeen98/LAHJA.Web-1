//using ApexCharts;
//using AutoMapper;
//using Domain.Entities.Plans.Response;
//using Domain.ShareData.Base;
//using Shared.Wrapper;
//using Infrastructure.Middlewares;
//using LAHJA.ApplicationLayer.Plans;
//using LAHJA.Data.UI.Components;
//using LAHJA.Data.UI.Components.Category;
//using LAHJA.Data.UI.Components.Plan;
//using LAHJA.Data.UI.Templates.Base;
//using LAHJA.Helpers.Services;
//using Microsoft.AspNetCore.Components;
//using MudBlazor;
//using MudBlazor.Extensions;
//using Shared.Constants.Router;
//using Client.Shared.Execution;
//using AutoGenerator.Attributes;

//namespace LAHJA.Data.UI.Templates.Plans
//{
//    public interface IBuilderPlansComponent<T> : IBuilderComponents<T>
//    {
//        public Func<T, Task<Result<List<PlanViewModel>>>> GetPlans { get; set; }
//        public Func<T, Task> SubmitContainerPlans { get; set; }
//        public Func<T, Task> SubmitCreatePlan { get; set; }
//        public Func<T, Task> SubmitUpdatePlan { get; set; }
//        public Func<T, Task> SubmitSubscriptionPlan { get; set; }
//    }

//    public interface IBuilderPlansApi<T> : IBuilderApi<T>
//    {
//        public Task<Result<List<CategoryComponent>>> GetAllCategories();
//        public Task<Result<List<PlanViewModel>>> GetPlansAsync(FilterResponseData filter);
//        public Task<Result<PlanViewModel>> GetPlanAsync(T data);
//        public Task<Result<PlanViewModel>> UpdatePlanAsync(T data);
//        public Task<Result<PlanViewModel>> CreatePlanAsync(T data);
//        public Task<Result<DeleteResponse>> DeletePlanAsync(T data);
//    }

//    public abstract class BuilderPlansApi<T, E> : BuilderApi<T, E>, IBuilderPlansApi<E>
//    {
//        public BuilderPlansApi(IMapper mapper, T service) : base(mapper, service)
//        {
//        }

//        public abstract Task<Result<List<CategoryComponent>>> GetAllCategories();
//        public abstract Task<Result<List<PlanViewModel>>> GetPlansAsync(FilterResponseData filter);
//        public abstract Task<Result<PlanViewModel>> GetPlanAsync(E data);
//        public abstract Task<Result<PlanViewModel>> UpdatePlanAsync(E data);
//        public abstract Task<Result<PlanViewModel>> CreatePlanAsync(E data);
//        public abstract Task<Result<DeleteResponse>> DeletePlanAsync(E data);
//    }

//    public class BuilderPlansComponent<T> : IBuilderPlansComponent<T>
//    {
//        public Func<T, Task<Result<List<PlanViewModel>>>> GetPlans { get; set; }
//        public Func<T, Task> SubmitContainerPlans { get; set; }
//        public Func<T, Task> SubmitSubscriptionPlan { get; set; }
//        public Func<T, Task> SubmitCreatePlan { get; set; }
//        public Func<T, Task> SubmitUpdatePlan { get; set; }
//    }

//    public class TemplatePlansShare<T, E> : TemplateBase<T, E>
//    {
//        protected readonly NavigationManager navigation;
//        protected readonly IDialogService dialogService;
//        protected readonly ISnackbar Snackbar;
//        protected IBuilderPlansApi<E> builderApi;
//        private readonly IBuilderPlansComponent<E> builderComponents;
//        public IBuilderPlansComponent<E> BuilderComponents { get => builderComponents; }

//        public TemplatePlansShare(IMapper mapper, AuthService AuthService, T client, IBuilderPlansComponent<E> builderComponents, NavigationManager navigation, IDialogService dialogService, ISnackbar snackbar, ISafeInvoker safelyHandler) : base(mapper, AuthService, client, safelyHandler)
//        {
//            builderComponents = new BuilderPlansComponent<E>();
//            this.navigation = navigation;
//            this.dialogService = dialogService;
//            this.Snackbar = snackbar;
//            //this.builderApi = builderApi;
//            this.builderComponents = builderComponents;
//        }
//    }

//    public class BuilderPlansApiClient : BuilderPlansApi<PlansClientService, DataBuildPlansBase>, IBuilderPlansApi<DataBuildPlansBase>
//    {
//        public BuilderPlansApiClient(IMapper mapper, PlansClientService service) : base(mapper, service)
//        {
//        }

//        public override async Task<Result<PlanViewModel>> UpdatePlanAsync(DataBuildPlansBase data)
//        {
//            var model = Mapper.Map<PlanUpdate>(data);
//            var res = await Service.UpdatePlanAsync(model);
//            if (res.Succeeded)
//            {
//                try
//                {
//                    var map = Mapper.Map<PlanViewModel>(res.Data);
//                    return Result<PlanViewModel>.Success(map);
//                }
//                catch (Exception e)
//                {
//                    return Result<PlanViewModel>.Fail();
//                }
//            }
//            else
//            {
//                return Result<PlanViewModel>.Fail(res.Messages);
//            }
//        }

//        public override async Task<Result<PlanViewModel>> CreatePlanAsync(DataBuildPlansBase data)
//        {
//            var model = Mapper.Map<PlanCreate>(data);
//            var res = await Service.CreatePlanAsync(model);
//            if (res.Succeeded)
//            {
//                try
//                {
//                    var map = Mapper.Map<PlanViewModel>(res.Data);
//                    return Result<PlanViewModel>.Success(map);
//                }
//                catch (Exception e)
//                {
//                    return Result<PlanViewModel>.Fail();
//                }
//            }
//            else
//            {
//                return Result<PlanViewModel>.Fail(res.Messages);
//            }
//        }

//        public override async Task<Result<List<PlanViewModel>>> GetPlansAsync(FilterResponseData filter)
//        {
//            var res = await Service.GetPlansAsync(filter);
//            if (res.Succeeded)
//            {
//                var map = Mapper.Map<List<PlanViewModel>>(res.Data);
//                return Result<List<PlanViewModel>>.Success(map);
//            }
//            else
//            {
//                return Result<List<PlanViewModel>>.Fail(res.Messages);
//            }
//        }

//        public override async Task<Result<PlanViewModel>> GetPlanAsync(DataBuildPlansBase data)
//        {
//            var res = await Service.GetPlanAsync(data.PlanId, data.Lg);
//            if (res.Succeeded)
//            {
//                var map = Mapper.Map<PlanViewModel>(res.Data);
//                return Result<PlanViewModel>.Success(map);
//            }
//            else
//            {
//                return Result<PlanViewModel>.Fail(res.Messages);
//            }
//        }

//        public override async Task<Result<DeleteResponse>> DeletePlanAsync(DataBuildPlansBase data)
//        {
//            return await Service.DeletePlanAsync(data.PlanId);
//        }

//        public override async Task<Result<List<CategoryComponent>>> GetAllCategories()
//        {
//            var res = await Service.GetCategories(new FilterResponseData());
//            if (res.Succeeded)
//            {
//                try
//                {
//                    var map = Mapper.Map<List<CategoryComponent>>(res.Data);
//                    return Result<List<CategoryComponent>>.Success(map);
//                }
//                catch (Exception e)
//                {
//                    return Result<List<CategoryComponent>>.Fail();
//                }
//            }
//            else
//            {
//                return Result<List<CategoryComponent>>.Fail(res.Messages);
//            }
//        }
//    }

//    [AutoSafeInvoke]
//    public class TemplatePlans : TemplatePlansShare<PlansClientService, DataBuildPlansBase>
//    {
//        private readonly ISafeInvoker safeInvoker;
//        private readonly TemplatePlans _self;
//        private List<CategoryComponent> _categories = new List<CategoryComponent>();
//        private List<PlanViewModel> _plans = new List<PlanViewModel>();
//        private List<PlanViewModel> _allPlans = new List<PlanViewModel>();
//        private PlanViewModel _plan = new PlanViewModel();
//        public TemplatePlans(IMapper mapper, AuthService AuthService, PlansClientService client, IBuilderPlansComponent<DataBuildPlansBase> builderComponents, NavigationManager navigation, IDialogService dialogService, ISnackbar snackbar, ISafeInvoker safeInvoker, IServiceProvider provider) : base(mapper, AuthService, client, builderComponents, navigation, dialogService, snackbar, safeInvoker)
//        {
//            this.safeInvoker = safeInvoker;
//            this.BuilderComponents.GetPlans = getPlansAsync;
//            this.BuilderComponents.SubmitSubscriptionPlan = OnSubmitSubscriptionPlan;
//            this.BuilderComponents.SubmitUpdatePlan = OnSubmitUpdatePlans;
//            this.BuilderComponents.SubmitCreatePlan = OnSubmitCreatePlans;
//            this.builderApi = new BuilderPlansApiClient(mapper, client);
//        //_self = provider.GetRequiredService<TemplatePlans>();
//        }

//        public List<CategoryComponent> Categories { get => _categories; }
//        public List<PlanViewModel> SubscriptionPlans { get => _plans; }
//        public List<PlanViewModel> AllSubscriptionPlans { get => _allPlans; }
//        public PlanViewModel SubscriptionPlan { get => _plan; }
//        public List<string> Errors { get => _errors; }

//        public async Task<Result<List<CategoryComponent>>> GetAllCategoriesAsync()
//        {
//            return await safeInvoker.InvokeAsync(async () =>
//            {
//                return await builderApi.GetAllCategories();
//            });
//        }

//        [IgnoreSafeInvoke]
//        private async Task<Result<List<PlanViewModel>>> getPlansAsync(DataBuildPlansBase buildData)
//        {
//            return await getSubscriptionsPlansAsync(buildData.Take, buildData.PremiumPlanNumber, buildData.Lg);
//        }

//        private async Task<Result<List<PlanViewModel>>> getSubscriptionsPlansAsync(int take, int premiumPlanNumber = 0, string lg = "en")
//        {
//            return await safeInvoker.InvokeAsync(async () =>
//            {
//                try
//                {
//                    var response = await builderApi.GetPlansAsync(new FilterResponseData { lg = lg });
//                    if (response.Succeeded)
//                    {
//                        if (premiumPlanNumber > 0 && take > 0)
//                        {
//                            var allPlans = response.Data.Take(take).ToList();
//                            if (allPlans.Count() > premiumPlanNumber)
//                            {
//                                allPlans[premiumPlanNumber].ClassImport = "plan-import-card";
//                                allPlans[premiumPlanNumber].HeaderImport = "textHeader";
//                            }
//                        }
//                        else
//                        {
//                            return Result<List<PlanViewModel>>.Success(response.Data);
//                        }

//                        return Result<List<PlanViewModel>>.Success(response.Data);
//                    }
//                    else
//                    {
//                        return response;
//                    }
//                }
//                catch (Exception e)
//                {
//                    return Result<List<PlanViewModel>>.Fail(e.Message);
//                }
//            });
//        }

//        [IgnoreSafeInvoke]
//        public async Task<Result<List<PlanViewModel>>> getAllSubscriptionsPlansAsync(FilterResponseData filter, int premiumPlanNumber = 0)
//        {
//            return await getSubscriptionsPlansAsync(filter.Take, premiumPlanNumber, filter.lg);
//        }

//        private async Task OnSubmitCreatePlans(DataBuildPlansBase dataBuildPlansBase)
//        {
//            if (dataBuildPlansBase != null)
//            {
//                var response = await safeInvoker.InvokeAsync(async () => await builderApi.CreatePlanAsync(dataBuildPlansBase));
//                if (response.Succeeded)
//                {
//                }
//                else
//                {
//                    _errors = response.Messages;
//                }
//            }
//        }

//        private async Task OnSubmitUpdatePlans(DataBuildPlansBase dataBuildPlansBase)
//        {
//            if (dataBuildPlansBase != null)
//            {
//                //var response = await builderApi.UpdatePlanAsync(dataBuildPlansBase);
//                var response = await safeInvoker.InvokeAsync(async () => await builderApi.UpdatePlanAsync(dataBuildPlansBase));
//                if (response.Succeeded)
//                {
//                }
//                else
//                {
//                    _errors = response.Messages;
//                }
//            }
//        }

//        public async Task OnSubmitSubscriptionPlan(DataBuildPlansBase dataBuildPlansBase)
//        {
//            await safeInvoker.InvokeAsync(async () =>
//            {
//                if (dataBuildPlansBase != null)
//                {
//                    navigation.NavigateTo($"{RouterPage.PAYMENT}/{dataBuildPlansBase.PlanId}");
//                }
//            });
//        }

//        public async Task<Result<PlanViewModel>> GetSubmitSubscriptionPlan(DataBuildPlansBase dataBuildPlansBase)
//        {
//            var response = await safeInvoker.InvokeAsync(async () => await builderApi.GetPlanAsync(dataBuildPlansBase));
//            return response;
//        }
//    }
//}