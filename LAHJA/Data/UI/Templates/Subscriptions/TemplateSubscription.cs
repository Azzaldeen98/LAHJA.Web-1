using AutoMapper;
using Domain.Entity;

using Shared.Wrapper;

using LAHJA.Data.UI.Models.Profile;
using LAHJA.Data.UI.Templates.Base;
using Microsoft.AspNetCore.Components;
using Client.Shared.Execution;
using AutoGenerator.Attributes;
using Application.Services;
using LAHJA.Data.UI.Models.Subscription;
using MudBlazor;
using Shared.Interfaces;

namespace LAHJA.Data.UI.Templates.Subscriptions
{

    public interface IBuilderSubscriptionComponent<T> : IBuilderComponents<T>
    {
        public Func<T, Task<Result<ICollection<DataBuildUserSubscriptionInfo>>>> SubmitSearch { get; set; }
        public Func<Task<Result<ICollection<DataBuildUserSubscriptionInfo>>>> GetAllSubscriptions { get; set; }
        public Func<string,Task<Result<DataBuildUserSubscriptionInfo>>> GetSubscription { get; set; }
        public Func<Task<Result<DataBuildUserSubscriptionInfo>>> GetActiveSubscription { get; set; }
        public Func<Task<Result<bool>>> HasActiveSubscription { get; set; }
        public Func<T, Task<Result>> SubmitPause { get; set; }
        public Func<T, Task<Result>> SubmitResume { get; set; }
        public Func<T, Task<Result>> SubmitRenew { get; set; }
        public Func<T, Task<Result>> SubmitDelete { get; set; }
        public Func<T, Task<Result>> SubmitCancel { get; set; }
        public Func<T, Task<Result>> SubmitCreate { get; set; }
        public Func<T, Task<Result>> SubmitUpdate { get; set; }
    }

    public interface IBuilderSubscriptionApi<T> : IBuilderApi<T>
    {
        public  Task<ICollection<DataBuildUserSubscriptionInfo>> GetAllAsync(CancellationToken cancellation);
        public  Task<bool> HasActiveSubscriptionAsync();
        public  Task<DataBuildUserSubscriptionInfo> GetUserActiveSubscriptionAsync(CancellationToken cancellation);
  
        public  Task<DataBuildUserSubscriptionInfo> GetSubscriptionAsync(string id, CancellationToken cancellation);
        public  Task CreateAsync(T data, CancellationToken cancellation);
        public  Task PauseAsync(T data, CancellationToken cancellation);
        public  Task ResumeAsync(T data, CancellationToken cancellation);
        public  Task DeleteAsync(T data, CancellationToken cancellation);
        public  Task CancelAsync(CancellationToken cancellation);
        public  Task RenewAsync(CancellationToken cancellation);
        public  Task UpdateAsync(T data, CancellationToken cancellation);
    }

    public abstract class BuilderSubscriptionApi<T, E> : BuilderApi<T, E>, IBuilderSubscriptionApi<E>
    {
        public BuilderSubscriptionApi(IMapper mapper, T service) : base(mapper, service)
        {
        }

        //public abstract Task<Result<SubscriptionResponse>> CreateAsync(E data);
        public abstract Task<ICollection<DataBuildUserSubscriptionInfo>> GetAllAsync(CancellationToken cancellation);
        public abstract Task<bool> HasActiveSubscriptionAsync();
        public abstract Task<DataBuildUserSubscriptionInfo> GetUserActiveSubscriptionAsync(CancellationToken cancellation);
        //public abstract Task<ICollection<ProfileSubscriptionResponse>> GetUserSubscriptionsAsync();
        public abstract Task<DataBuildUserSubscriptionInfo> GetSubscriptionAsync(string id, CancellationToken cancellation);
        public abstract Task CreateAsync(E data, CancellationToken cancellation);
        public abstract Task PauseAsync(E data, CancellationToken cancellation);
        public abstract Task ResumeAsync(E data, CancellationToken cancellation);
        public abstract Task DeleteAsync(E data, CancellationToken cancellation);
        public abstract Task CancelAsync(CancellationToken cancellation);
        public abstract Task RenewAsync(CancellationToken cancellation);
        public abstract Task UpdateAsync(E data, CancellationToken cancellation);
    }

    public class BuilderSubscriptionComponent<T> : IBuilderSubscriptionComponent<T>
    {
        public Func<T, Task<Result<ICollection<DataBuildUserSubscriptionInfo>>>> SubmitSearch { get; set; }
        public Func<Task<Result<ICollection<DataBuildUserSubscriptionInfo>>>> GetAllSubscriptions { get; set; }
        public Func<string, Task<Result<DataBuildUserSubscriptionInfo>>> GetSubscription { get; set; }
        public Func<Task<Result<DataBuildUserSubscriptionInfo>>> GetActiveSubscription { get; set; }
        public Func<Task<Result<bool>>> HasActiveSubscription { get; set; }
        public Func<T, Task<Result>> SubmitPause { get; set; }
        public Func<T, Task<Result>> SubmitResume { get; set; }
        public Func<T, Task<Result>> SubmitRenew { get; set; }
        public Func<T, Task<Result>> SubmitDelete { get; set; }
        public Func<T, Task<Result>> SubmitCancel { get; set; }
        public Func<T, Task<Result>> SubmitCreate { get; set; }
        public Func<T, Task<Result>> SubmitUpdate { get; set; }
    }

    public class TemplateSubscriptionShare<T, E> : TemplateBase<T, E>
    {
        protected readonly NavigationManager navigation;
        protected readonly IDialogService dialogService;
        protected readonly ISnackbar Snackbar;
        protected IBuilderSubscriptionApi<E> builderApi;
        private readonly IBuilderSubscriptionComponent<E> builderComponents;
        public IBuilderSubscriptionComponent<E> BuilderComponents { get => builderComponents; }

        public TemplateSubscriptionShare(IMapper mapper,
            Helpers.Services.AuthService AuthService, 
            T client, 
            IBuilderSubscriptionComponent<E> builderComponents, 
            NavigationManager navigation, IDialogService dialogService, ISnackbar snackbar)
            : base(mapper, AuthService, client)
        {
            builderComponents = new BuilderSubscriptionComponent<E>();
            this.navigation = navigation;
            this.dialogService = dialogService;
            this.Snackbar = snackbar;
            //this.builderApi = builderApi;
            this.builderComponents = builderComponents;
        }
    }

    public class BuilderSubscriptionApiClient : BuilderSubscriptionApi<ISubscriptionService, DataBuildUserSubscriptionInfo>, IBuilderSubscriptionApi<DataBuildUserSubscriptionInfo>
    {
        public BuilderSubscriptionApiClient(IMapper mapper, ISubscriptionService service) : base(mapper, service)
        {
        }

        public override async Task<DataBuildUserSubscriptionInfo> GetSubscriptionAsync(string id,CancellationToken cancellation)
        {
            var subscription=await Service.getSubscriptionAsync(cancellation);
            return Mapper.Map<DataBuildUserSubscriptionInfo>(subscription);
        }

        public override async Task<DataBuildUserSubscriptionInfo> GetUserActiveSubscriptionAsync(CancellationToken cancellation)
        {
            var subscription = await Service.getSubscriptionAsync(cancellation);
            return Mapper.Map<DataBuildUserSubscriptionInfo>(subscription);
        }

        public override async Task<bool> HasActiveSubscriptionAsync()
        {
            //var subscription = await Service.getSubscriptionAsync();
            return await Task.FromResult(false);
        }

        public override async Task PauseAsync(DataBuildUserSubscriptionInfo data, CancellationToken cancellation)
        {
            var model = Mapper.Map<Subscription>(data);
            await Service.pauseSubscriptionAsync(model, cancellation);
          
        }
        public override async Task CancelAsync(CancellationToken cancellations)
        {

            await Service.cancelSubscriptionAsync(cancellations);
        }

        public override async Task DeleteAsync(DataBuildUserSubscriptionInfo data, CancellationToken cancellations)
        {

       
             await  Task.CompletedTask;
            
        }

        public override async Task<ICollection<DataBuildUserSubscriptionInfo>> GetAllAsync(CancellationToken cancellations)
        {
       
            var subscriptions = await Service.getSubscriptionsAsync(cancellations);
            return Mapper.Map<ICollection<DataBuildUserSubscriptionInfo>>(subscriptions); 
        }

        public override async Task ResumeAsync(DataBuildUserSubscriptionInfo data, CancellationToken cancellation)
        {
            await Service.resumeSubscriptionAsync(cancellation);
        }

        public override async Task CreateAsync(DataBuildUserSubscriptionInfo data, CancellationToken cancellation)
        {
  
             await Service.renewSubscriptionAsync(cancellation);

        }

        public override async Task RenewAsync(CancellationToken cancellation)
        {

            await Service.renewSubscriptionAsync(cancellation);

        }

        public override async Task UpdateAsync(DataBuildUserSubscriptionInfo data, CancellationToken cancellation)
        {

            await Task.CompletedTask;

  
        }
    }

    [AutoSafeInvoke]
    public class TemplateSubscription : TemplateSubscriptionShare<ISubscriptionService, DataBuildUserSubscriptionInfo>
    {
        private readonly ISafeInvoker safeInvoker;
        private readonly ICancelableTaskExecutor taskExecutor;
        private List<DataBuildUserSubscriptionInfo> _Subscriptions = new List<DataBuildUserSubscriptionInfo>();
        public TemplateSubscription(IMapper mapper, 
            Helpers.Services.AuthService AuthService,
            ISubscriptionService client, 
            IBuilderSubscriptionComponent<DataBuildUserSubscriptionInfo> builderComponents, 
            NavigationManager navigation, 
            IDialogService dialogService, 
            ISnackbar snackbar, 
            ISafeInvoker safeInvoker,
            ICancelableTaskExecutor taskExecutor) 
            : base(mapper, AuthService, client, builderComponents, navigation, dialogService, snackbar)
        {
            //this.BuilderComponents.SubmitCreate = OnSubmitCreateSubscription;
            this.BuilderComponents.GetAllSubscriptions = OnGetAllSubscriptions;
            this.BuilderComponents.GetSubscription = OnGetSubscriptionAsync;
            this.BuilderComponents.GetActiveSubscription = OnGetUserActiveSubscriptionAsync;
            this.BuilderComponents.HasActiveSubscription = OnHasActiveSubscriptionAsync;
            this.BuilderComponents.SubmitPause = OnSubmitPauseSubscription;
            this.BuilderComponents.SubmitResume = OnSubmitUResumeSubscription;
            this.BuilderComponents.SubmitRenew = OnSubmitRenewSubscription;
            this.BuilderComponents.SubmitCancel = OnSubmitCancelSubscription;
            this.builderApi = new BuilderSubscriptionApiClient(mapper, client);
            this.safeInvoker = safeInvoker;
            this.taskExecutor = taskExecutor;
        }

        public List<DataBuildUserSubscriptionInfo> Subscriptions { get => _Subscriptions; }
        public List<string> Errors { get => _errors; }

        [IgnoreSafeInvoke]
        private void redirectTo(string url)
        {
            navigation.NavigateTo(url, false);
        }

        private async Task<Result<bool>> OnHasActiveSubscriptionAsync()
        {
            return await safeInvoker.InvokeAsync(async () =>
            {


                    var res = await builderApi.HasActiveSubscriptionAsync();
                    if (res)
                    {
                        return Result<bool>.Success(res);
                    }

                    return Result<bool>.Fail("Error");
               
           
            });
        }

        private async Task<Result<DataBuildUserSubscriptionInfo>> OnGetUserActiveSubscriptionAsync()
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await taskExecutor.RunAsync(async (token) =>
                {
                   return await builderApi.GetUserActiveSubscriptionAsync(token);
    
                });
           
            });
        }

        private async Task<Result> OnSubmitCancelSubscription(DataBuildUserSubscriptionInfo DataBuildUserSubscriptionInfo)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await taskExecutor.RunAsync(async (token) =>
                {

                      await builderApi.CancelAsync(token);

                });

            });
        }
        private async Task<Result> OnSubmitRenewSubscription(DataBuildUserSubscriptionInfo data=null)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await taskExecutor.RunAsync(async (token) =>
                {

                    await builderApi.RenewAsync(token);

                });

            });
        }
        private async Task<Result> OnSubmitPauseSubscription(DataBuildUserSubscriptionInfo data)
        {
           return await safeInvoker.InvokeAsync(async () =>
            {
                return await taskExecutor.RunAsync(async (token) =>
                {

                    await builderApi.PauseAsync(data,token);

                });
                
            });
        }

        //private async Task<Result<SubscriptionCreateResponse>> OnSubmitCreateSubscription(DataBuildUserSubscriptionInfo DataBuildUserSubscriptionInfo)
        //{
        //    return await safeInvoker.InvokeAsync(async () =>
        //    {
        //        return await builderApi.CreateAsync(DataBuildUserSubscriptionInfo);
        //    });
        //}

        private async Task<Result<DataBuildUserSubscriptionInfo>> OnGetSubscriptionAsync(string id)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
              
                return await taskExecutor.RunAsync(async (token) =>
                {

                   return await builderApi.GetSubscriptionAsync(id,token);

                });
            });
        }

        private async Task<Result> OnSubmitUResumeSubscription(DataBuildUserSubscriptionInfo data)
        {
           return await safeInvoker.InvokeAsync(async () =>
            {

                return await taskExecutor.RunAsync(async (token) =>
                {
                    if (data != null)
                    {
                        await builderApi.ResumeAsync(data, token);
                    }

                });
                
            });
        }

        private async Task<Result<ICollection<DataBuildUserSubscriptionInfo>>> OnGetAllSubscriptions()
        {
           return await safeInvoker.InvokeAsync(async () =>
            {
                return await taskExecutor.RunAsync(async (token) =>
                {
                    return await builderApi.GetAllAsync(token);

                });
        
            });
        }

        //private async Task<Result<ICollection<DataBuildUserSubscriptionInfo>>> GetAllSubscriptions()
        //{
        //    return await safeInvoker.InvokeAsync(async () =>
        //    {
        //        return await taskExecutor.RunAsync(async (token) =>
        //        {
        //            return await builderApi.GetAllAsync(token);
        //        });
        //    });
        //}
    }
}