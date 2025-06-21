using AutoMapper;
using Domain.Entities.Subscriptions.Request;
using Domain.Entities.Subscriptions.Response;
using Domain.ShareData.Base;
using Shared.Wrapper;
using LAHJA.ApplicationLayer.Subscription;
using LAHJA.Data.UI.Components.Subscription;
using LAHJA.Data.UI.Models.Profile;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shared.Constants.Router;
using System.Threading.Tasks;
using Client.Shared.Execution;
using AutoGenerator.Config.Attributes;

namespace LAHJA.Data.UI.Templates.Subscription
{
    //public class DataBuildUserSubscriptionInfo
    //{
    //    public string? Id { get; set; }
    //    public string? UserId { get; set; }
    //    public string? PlanId { get; set; }
    //    public string? CustomerId { get; set; }
    //    public string? BillingPeriod { get; set; }
    //    public DateTimeOffset? StartDate { get; set; }
    //    public string? Status { get; set; }
    //    public bool? CancelAtPeriodEnd { get; set; }
    //}
    public interface IBuilderSubscriptionComponent<T> : IBuilderComponents<T>
    {
        public Func<T, Task> SubmitSearch { get; set; }
        public Func<Task> SubmitGetAll { get; set; }
        public Func<FilterResponseData, Task<Result<DataBuildUserSubscriptionInfo>>> SubmitGetSubscription { get; set; }
        public Func<T, Task> SubmitPause { get; set; }
        public Func<T, Task> SubmitResume { get; set; }
        public Func<T, Task<Result<DeleteResponse>>> SubmitDelete { get; set; }
        //public Func<T, Task<Result<ICollection<ProfileSubscriptionResponse>>>> GetUserSubscriptions { get; set; }
        //public Func<T, Task<Result<ICollection<ProfileSubscriptionResponse>>>> GetUserActiveSubscriptions { get; set; }
        public Func<T, Task<Result<SubscriptionCreateResponse>>> SubmitCreate { get; set; }
        public Func<T, Task> SubmitUpdate { get; set; }
    }

    public interface IBuilderSubscriptionApi<T> : IBuilderApi<T>
    {
        //Task<Result<List<SubscriptionResponse>>> SearchAsync(T data);
        Task<Result<List<UserSubscription>>> GetAllAsync();
        Task<Result<SubscriptionResponse>> GetUserActiveSubscriptionAsync();
        Task<Result<SubscriptionResponse>> GetSubscriptionAsync(FilterResponseData filter);
        Task<Result<bool>> HasActiveSubscriptionAsync();
        Task<Result<SubscriptionCreateResponse>> CreateAsync(T data);
        Task<Result<UserSubscription>> ResumeAsync(T data);
        Task<Result<UserSubscription>> PauseAsync(T data);
        Task<Result<DeleteResponse>> DeleteAsync(T data);
        Task<Result<UserSubscription>> UpdateAsync(T data);
    }

    public abstract class BuilderSubscriptionApi<T, E> : BuilderApi<T, E>, IBuilderSubscriptionApi<E>
    {
        public BuilderSubscriptionApi(IMapper mapper, T service) : base(mapper, service)
        {
        }

        //public abstract Task<Result<SubscriptionResponse>> CreateAsync(E data);
        public abstract Task<Result<List<UserSubscription>>> GetAllAsync();
        public abstract Task<Result<bool>> HasActiveSubscriptionAsync();
        public abstract Task<Result<SubscriptionResponse>> GetUserActiveSubscriptionAsync();
        //public abstract Task<ICollection<ProfileSubscriptionResponse>> GetUserSubscriptionsAsync();
        public abstract Task<Result<SubscriptionResponse>> GetSubscriptionAsync(FilterResponseData filter);
        public abstract Task<Result<SubscriptionCreateResponse>> CreateAsync(E data);
        public abstract Task<Result<UserSubscription>> PauseAsync(E data);
        public abstract Task<Result<UserSubscription>> ResumeAsync(E data);
        public abstract Task<Result<DeleteResponse>> DeleteAsync(E dataId);
        public abstract Task<Result<UserSubscription>> UpdateAsync(E data);
    }

    public class BuilderSubscriptionComponent<T> : IBuilderSubscriptionComponent<T>
    {
        public Func<FilterResponseData, Task<Result<DataBuildUserSubscriptionInfo>>> SubmitGetSubscription { get; set; }
        public Func<T, Task> SubmitSearch { get; set; }
        public Func<Task> SubmitGetAll { get; set; }
        public Func<T, Task> SubmitPause { get; set; }
        public Func<T, Task> SubmitResume { get; set; }
        public Func<T, Task<Result<DeleteResponse>>> SubmitDelete { get; set; }
        public Func<T, Task> SubmitUpdate { get; set; }
        public Func<T, Task<Result<SubscriptionCreateResponse>>> SubmitCreate { get; set; }
    }

    public class TemplateSubscriptionShare<T, E> : TemplateBase<T, E>
    {
        protected readonly NavigationManager navigation;
        protected readonly IDialogService dialogService;
        protected readonly ISnackbar Snackbar;
        protected IBuilderSubscriptionApi<E> builderApi;
        private readonly IBuilderSubscriptionComponent<E> builderComponents;
        public IBuilderSubscriptionComponent<E> BuilderComponents { get => builderComponents; }

        public TemplateSubscriptionShare(IMapper mapper, AuthService AuthService, T client, IBuilderSubscriptionComponent<E> builderComponents, NavigationManager navigation, IDialogService dialogService, ISnackbar snackbar) : base(mapper, AuthService, client)
        {
            builderComponents = new BuilderSubscriptionComponent<E>();
            this.navigation = navigation;
            this.dialogService = dialogService;
            this.Snackbar = snackbar;
            //this.builderApi = builderApi;
            this.builderComponents = builderComponents;
        }
    }

    public class BuilderSubscriptionApiClient : BuilderSubscriptionApi<SubscriptionClientService, DataBuildUserSubscriptionInfo>, IBuilderSubscriptionApi<DataBuildUserSubscriptionInfo>
    {
        public BuilderSubscriptionApiClient(IMapper mapper, SubscriptionClientService service) : base(mapper, service)
        {
        }

        public override async Task<Result<SubscriptionResponse>> GetSubscriptionAsync(FilterResponseData filter)
        {
            return await Service.GetSubscriptionAsync(filter);
        }

        public override async Task<Result<SubscriptionResponse>> GetUserActiveSubscriptionAsync()
        {
            return await Service.GetUserActiveSubscriptionAsync();
        }

        public override async Task<Result<bool>> HasActiveSubscriptionAsync()
        {
            return await Service.HasActiveSubscriptionAsync();
        }

        public override async Task<Result<UserSubscription>> PauseAsync(DataBuildUserSubscriptionInfo data)
        {
            //var model = Mapper.Map<SubscriptionCreate>(data);
            var res = await Service.PauseAsync(data.Id);
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<UserSubscription>(res.Data);
                    return Result<UserSubscription>.Success(map);
                }
                catch (Exception e)
                {
                    return Result<UserSubscription>.Fail();
                }
            }
            else
            {
                return Result<UserSubscription>.Fail(res.Messages);
            }
        }

        public override async Task<Result<DeleteResponse>> DeleteAsync(DataBuildUserSubscriptionInfo data)
        {
            var res = await Service.DeleteAsync(data.Id);
            if (res.Succeeded)
            {
                try
                {
                    return Result<DeleteResponse>.Success(res.Data);
                }
                catch (Exception e)
                {
                    return Result<DeleteResponse>.Fail();
                }
            }
            else
            {
                return Result<DeleteResponse>.Fail(res.Messages);
            }
        }

        public override async Task<Result<List<UserSubscription>>> GetAllAsync()
        {
            //var model = Mapper.Map<FilterResponseData>(filter);
            var res = await Service.GetAllAsync();
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<List<UserSubscription>>(res.Data);
                    return Result<List<UserSubscription>>.Success(map);
                }
                catch (Exception e)
                {
                    return Result<List<UserSubscription>>.Fail();
                }
            }
            else
            {
                return Result<List<UserSubscription>>.Fail(res.Messages);
            }
        }

        public override async Task<Result<UserSubscription>> ResumeAsync(DataBuildUserSubscriptionInfo data)
        {
            //var model = Mapper.Map<SubscriptionSearchRequest>(data);
            var res = await Service.ResumeAsync(data.Id);
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<UserSubscription>(res.Data);
                    return Result<UserSubscription>.Success(map);
                }
                catch (Exception e)
                {
                    return Result<UserSubscription>.Fail();
                }
            }
            else
            {
                return Result<UserSubscription>.Fail(res.Messages);
            }
        }

        public override async Task<Result<SubscriptionCreateResponse>> CreateAsync(DataBuildUserSubscriptionInfo data)
        {
            var model = Mapper.Map<SubscriptionCreate>(data);
            return await Service.CreateAsync(model);
        //if (res.Succeeded)
        //{
        //    try
        //    {
        //        var map = Mapper.Map<UserSubscription>(res.Data);
        //        return Result<UserSubscription>.Success(map);
        //    }
        //    catch (Exception e)
        //    {
        //        return Result<UserSubscription>.Fail();
        //    }
        //}
        //else
        //{
        //    return Result<UserSubscription>.Fail(res.Messages);
        //}
        }

        public override async Task<Result<UserSubscription>> UpdateAsync(DataBuildUserSubscriptionInfo data)
        {
            var model = Mapper.Map<SubscriptionRequest>(data);
            var res = await Service.UpdateAsync(model);
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<UserSubscription>(res.Data);
                    return Result<UserSubscription>.Success(map);
                }
                catch (Exception e)
                {
                    return Result<UserSubscription>.Fail();
                }
            }
            else
            {
                return Result<UserSubscription>.Fail(res.Messages);
            }
        }
    }

    [AutoSafeInvoke]
    public class TemplateSubscription : TemplateSubscriptionShare<SubscriptionClientService, DataBuildUserSubscriptionInfo>
    {
        private readonly ISafeInvoker safeInvoker;
        private List<UserSubscription> _Subscriptions = new List<UserSubscription>();
        public TemplateSubscription(IMapper mapper, AuthService AuthService, SubscriptionClientService client, IBuilderSubscriptionComponent<DataBuildUserSubscriptionInfo> builderComponents, NavigationManager navigation, IDialogService dialogService, ISnackbar snackbar, ISafeInvoker safeInvoker) : base(mapper, AuthService, client, builderComponents, navigation, dialogService, snackbar)
        {
            this.BuilderComponents.SubmitCreate = OnSubmitCreateSubscription;
            this.BuilderComponents.SubmitGetAll = OnSubmitGetAllSubscriptions;
            this.BuilderComponents.SubmitGetSubscription = OnGetSubscriptionAsync;
            this.BuilderComponents.SubmitPause = OnSubmitPauseSubscription;
            this.BuilderComponents.SubmitResume = OnSubmitUResumeSubscription;
            this.BuilderComponents.SubmitDelete = OnSubmitDeleteSubscription;
            this.builderApi = new BuilderSubscriptionApiClient(mapper, client);
            this.safeInvoker = safeInvoker;
        }

        public List<UserSubscription> Subscriptions { get => _Subscriptions; }
        public List<string> Errors { get => _errors; }

        [IgnoreSafeInvoke]
        private void redirectTo(string url)
        {
            navigation.NavigateTo(url, false);
        }

        public async Task<bool> HasActiveSubscriptionAsync()
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                var res = await builderApi.HasActiveSubscriptionAsync();
                if (res.Succeeded)
                {
                    return res.Data;
                }

                return false;
            });
        }

        public async Task<Result<SubscriptionResponse>> GetUserActiveSubscriptionAsync()
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await builderApi.GetUserActiveSubscriptionAsync();
            });
        }

        private async Task<Result<DeleteResponse>> OnSubmitDeleteSubscription(DataBuildUserSubscriptionInfo DataBuildUserSubscriptionInfo)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                if (DataBuildUserSubscriptionInfo != null)
                {
                    var response = await builderApi.DeleteAsync(DataBuildUserSubscriptionInfo);
                    if (response.Succeeded)
                    {
                        return response;
                    }
                    else
                    {
                        _errors = response.Messages;
                        return Result<DeleteResponse>.Fail(response.Messages);
                    }
                }

                return Result<DeleteResponse>.Fail();
            });
        }

        private async Task OnSubmitPauseSubscription(DataBuildUserSubscriptionInfo DataBuildUserSubscriptionInfo)
        {
            await safeInvoker.InvokeAsync(async () =>
            {
                if (DataBuildUserSubscriptionInfo != null)
                {
                    var response = await builderApi.PauseAsync(DataBuildUserSubscriptionInfo);
                    if (response.Succeeded)
                    {
                        redirectTo(RouterPage.DASHBOARD_SUBSCRIPTION);
                    }
                    else
                    {
                        _errors = response.Messages;
                    }
                }
            });
        }

        private async Task<Result<SubscriptionCreateResponse>> OnSubmitCreateSubscription(DataBuildUserSubscriptionInfo DataBuildUserSubscriptionInfo)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await builderApi.CreateAsync(DataBuildUserSubscriptionInfo);
            });
        }

        private async Task<Result<DataBuildUserSubscriptionInfo>> OnGetSubscriptionAsync(FilterResponseData filter)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                var response = await builderApi.GetSubscriptionAsync(filter);
                if (response.Succeeded)
                {
                    var mapData = mapper.Map<DataBuildUserSubscriptionInfo>(response.Data);
                    return Result<DataBuildUserSubscriptionInfo>.Success(mapData);
                }
                else
                {
                    return Result<DataBuildUserSubscriptionInfo>.Fail(response?.Messages ?? ["Error"]);
                }
            });
        }

        private async Task OnSubmitUResumeSubscription(DataBuildUserSubscriptionInfo DataBuildUserSubscriptionInfo)
        {
            await safeInvoker.InvokeAsync(async () =>
            {
                if (DataBuildUserSubscriptionInfo != null)
                {
                    var response = await builderApi.ResumeAsync(DataBuildUserSubscriptionInfo);
                    if (response.Succeeded)
                    {
                        redirectTo(RouterPage.DASHBOARD_SUBSCRIPTION);
                    }
                    else
                    {
                        _errors = response.Messages;
                    }
                }
            });
        }

        private async Task OnSubmitGetAllSubscriptions()
        {
            await safeInvoker.InvokeAsync(async () =>
            {
                var response = await builderApi.GetAllAsync();
                if (response.Succeeded)
                {
                    _Subscriptions = response.Data;
                }
                else
                {
                    _errors = response.Messages;
                }
            });
        }

        public async Task<Result<List<UserSubscription>>> GetAllSubscriptions()
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await builderApi.GetAllAsync();
            });
        }
    }
}