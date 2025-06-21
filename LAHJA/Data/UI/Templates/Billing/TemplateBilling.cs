using Application.Service.Plans;
using AutoMapper;
using Domain.Entities.Billing.Request;
using Domain.Entities.Billing.Response;
using Domain.ShareData;
using Shared.Wrapper;
using Infrastructure.Nswag;
using LAHJA.Data.UI.Components.Payment.DataBuildBillingBase;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using MudBlazor;
using Client.Shared.Execution;
using Domain.ShareData.Base;
using AutoGenerator.Config.Attributes;

namespace LAHJA.Data.UI.Templates.Billing
{
    //public class DataBuildBillingBase {
    //    public string BillingId  { get; set; }
    //    public string Email  { get; set; }
    //    public  DataBuildBillingBase buildContext { get; set; }
    //    public string SuccessUrl { get; set; } = "https://asg.tryasp.net/swagger/index.html";
    //    public string CancelUrl { get; set; } = "https://asg.tryasp.net/api/Details";
    //}
    public interface IBuilderBillingComponent<T> : IBuilderComponents<T>
    {
        public Func<T, Task> SubmitCreateBillingDetails { get; set; }
        public Func<T, Task> SubmitUpdateBillingDetails { get; set; }
        public Func<T, Task> SubmitDeleteBillingDetails { get; set; }
    }

    public interface IBuilderBillingApi<T> : IBuilderApi<T>
    {
        //Task<Result<List<InputCategory>>> OnInitialize();
        Task<Result<BillingDetailsResponse>> GetBillingDetails(T data);
        Task<Result<BillingDetailsResponse>> CreateBillingDetails(T data);
        Task<Result<BillingDetailsResponse>> UpdateBillingDetails(T data);
        Task<Result<DeleteResponse>> DeleteBillingDetails(T data);
    }

    public abstract class BuilderBillingApi<T, E> : BuilderApi<T, E>, IBuilderBillingApi<E>
    {
        public BuilderBillingApi(IMapper mapper, T service) : base(mapper, service)
        {
        }

        //public abstract Task<Result<List<InputCategory>>> OnInitialize();
        public abstract Task<Result<BillingDetailsResponse>> GetBillingDetails(E data);
        public abstract Task<Result<BillingDetailsResponse>> CreateBillingDetails(E data);
        public abstract Task<Result<BillingDetailsResponse>> UpdateBillingDetails(E data);
        public abstract Task<Result<DeleteResponse>> DeleteBillingDetails(E data);
    }

    public class BuilderBillingComponent<T> : IBuilderBillingComponent<T>
    {
        public Func<T, Task> SubmitCreateBillingDetails { get; set; }
        public Func<T, Task> SubmitUpdateBillingDetails { get; set; }
        public Func<T, Task> SubmitDeleteBillingDetails { get; set; }
    }

    public class TemplateBillingShare<T, E> : TemplateBase<T, E>
    {
        protected readonly NavigationManager navigation;
        protected readonly IDialogService dialogService;
        protected readonly ISnackbar Snackbar;
        protected IBuilderBillingApi<E> builderApi;
        private readonly IBuilderBillingComponent<E> builderComponents;
        public IBuilderBillingComponent<E> BuilderComponents { get => builderComponents; }

        public TemplateBillingShare(IMapper mapper, AuthService AuthService, T client, IBuilderBillingComponent<E> builderComponents, NavigationManager navigation, IDialogService dialogService, ISnackbar snackbar) : base(mapper, AuthService, client)
        {
            builderComponents = new BuilderBillingComponent<E>();
            this.navigation = navigation;
            this.dialogService = dialogService;
            this.Snackbar = snackbar;
            //this.builderApi = builderApi;
            this.builderComponents = builderComponents;
        }
    }

    public class BuilderBillingApiClient : BuilderBillingApi<BillingClientService, DataBuildBillingBase>, IBuilderBillingApi<DataBuildBillingBase>
    {
        public BuilderBillingApiClient(IMapper mapper, BillingClientService service) : base(mapper, service)
        {
        }

        public async override Task<Result<BillingDetailsResponse>> CreateBillingDetails(DataBuildBillingBase data)
        {
            var model = Mapper.Map<BillingDetailsRequest>(data);
            var res = await Service.UpdateAsync(model);
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<BillingDetailsResponse>(res.Data);
                    return Result<BillingDetailsResponse>.Success(map);
                }
                catch (Exception e)
                {
                    return Result<BillingDetailsResponse>.Fail();
                }
            }
            else
            {
                return Result<BillingDetailsResponse>.Fail(res.Messages);
            }
        }

        public async override Task<Result<DeleteResponse>> DeleteBillingDetails(DataBuildBillingBase data)
        {
            //var model = Mapper.Map<BillingDetailsRequest>(data);
            if (data != null && string.IsNullOrEmpty(data?.Email))
                return Result<DeleteResponse>.Fail("Error No data !!");
            var res = await Service.DeleteAsync(data?.Email);
            if (res.Succeeded)
            {
                try
                {
                    return Result<DeleteResponse>.Success();
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

        public override async Task<Result<BillingDetailsResponse>> GetBillingDetails(DataBuildBillingBase data)
        {
            var res = await Service.GetBillingDetailsAsync();
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<BillingDetailsResponse>(res.Data);
                    return Result<BillingDetailsResponse>.Success(map);
                }
                catch (Exception e)
                {
                    return Result<BillingDetailsResponse>.Fail();
                }
            }
            else
            {
                return Result<BillingDetailsResponse>.Fail(res.Messages);
            }
        }

        public async override Task<Result<BillingDetailsResponse>> UpdateBillingDetails(DataBuildBillingBase data)
        {
            var model = Mapper.Map<BillingDetailsRequest>(data);
            var res = await Service.UpdateAsync(model);
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<BillingDetailsResponse>(res.Data);
                    return Result<BillingDetailsResponse>.Success(map);
                }
                catch (Exception e)
                {
                    return Result<BillingDetailsResponse>.Fail();
                }
            }
            else
            {
                return Result<BillingDetailsResponse>.Fail(res.Messages);
            }
        }
    }

    [AutoSafeInvoke]
    public class TemplateBilling : TemplateBillingShare<BillingClientService, DataBuildBillingBase>
    {
        private readonly ISafeInvoker safeInvoker;
        private readonly ISessionUserManager sessionUserManager;
        public TemplateBilling(IMapper mapper, AuthService AuthService, BillingClientService client, IBuilderBillingComponent<DataBuildBillingBase> builderComponents, NavigationManager navigation, IDialogService dialogService, ISnackbar snackbar, ISessionUserManager sessionUserManager, ISafeInvoker safeInvoker) : base(mapper, AuthService, client, builderComponents, navigation, dialogService, snackbar)
        {
            this.BuilderComponents.SubmitUpdateBillingDetails = oUpdateBillingDetails;
            this.BuilderComponents.SubmitCreateBillingDetails = onCreateBillingDetails;
            this.BuilderComponents.SubmitDeleteBillingDetails = onDeleteBillingDetails;
            this.builderApi = new BuilderBillingApiClient(mapper, client);
            this.sessionUserManager = sessionUserManager;
            this.safeInvoker = safeInvoker;
        //Task.FromResult(OnInitialize());
        }

        public List<string> Errors { get => _errors; }

        public async Task<Result<DataBuildBillingBase>> GetBillingDetails()
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                var res = await builderApi.GetBillingDetails(new DataBuildBillingBase { });
                if (res.Succeeded)
                {
                    try
                    {
                        var map = mapper.Map<DataBuildBillingBase>(res.Data);
                        return Result<DataBuildBillingBase>.Success(map);
                    }
                    catch (Exception e)
                    {
                        return Result<DataBuildBillingBase>.Fail();
                    }
                }
                else
                {
                    return Result<DataBuildBillingBase>.Fail(res.Messages);
                }
            });
        }

        public async Task onCreateBillingDetails(DataBuildBillingBase DataBuildBillingBase)
        {
            await safeInvoker.InvokeAsync(async () =>
            {
                await builderApi.CreateBillingDetails(DataBuildBillingBase);
            });
        }

        private async Task oUpdateBillingDetails(DataBuildBillingBase DataBuildBillingBase)
        {
            await safeInvoker.InvokeAsync(async () =>
            {
                await builderApi.UpdateBillingDetails(DataBuildBillingBase);
            });
        }

        public async Task onDeleteBillingDetails(DataBuildBillingBase DataBuildBillingBase)
        {
            await safeInvoker.InvokeAsync(async () =>
            {
                await builderApi.DeleteBillingDetails(DataBuildBillingBase);
            });
        }
    }
}