using AutoMapper;
using Domain.Entities.Checkout;
using Domain.Entities.Checkout.Request;
using Domain.Entities.Checkout.Response;
using Shared.Wrapper;
using LAHJA.ApplicationLayer.Checkout;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Helpers;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Newtonsoft.Json;
using Shared.Constants;
using Shared.Constants.Router;
using Client.Shared.Execution;
using AutoGenerator.Config.Attributes;

namespace LAHJA.Data.UI.Templates.Payment
{
    public class DataBuildPaymentBase
    {
        public string PlanId { get; set; }
        public string SuccessUrl { get; set; }
        public string CancelUrl { get; set; }
        public string ReturnUrl { get; set; }
    }

    public interface IBuilderPaymentComponent<T> : IBuilderComponents<T>
    {
        public Func<T, Task> SubmitCheckout { get; set; }
        public Func<T, Task> SubmitCheckoutManage { get; set; }
    }

    public interface IBuilderCheckoutApi<T> : IBuilderApi<T>
    {
        //Task<Result<List<InputCategory>>> OnInitialize();
        Task<Result<CheckoutResponse>> CheckoutAsync(T data);
        Task<Result<CheckoutResponse>> CheckoutManageAsync(T data);
    }

    public abstract class BuilderCheckoutApi<T, E> : BuilderApi<T, E>, IBuilderCheckoutApi<E>
    {
        public BuilderCheckoutApi(IMapper mapper, T service) : base(mapper, service)
        {
        }

        //public abstract Task<Result<List<InputCategory>>> OnInitialize();
        public abstract Task<Result<CheckoutResponse>> CheckoutAsync(E data);
        public abstract Task<Result<CheckoutResponse>> CheckoutManageAsync(E data);
    }

    public class BuilderPaymentComponent<T> : IBuilderPaymentComponent<T>
    {
        public Func<T, Task> SubmitCheckout { get; set; }
        public Func<T, Task> SubmitCheckoutManage { get; set; }
    }

    public class TemplatePaymentShare<T, E> : TemplateBase<T, E>
    {
        protected readonly NavigationManager navigation;
        protected readonly IDialogService dialogService;
        protected readonly ISnackbar Snackbar;
        protected IBuilderCheckoutApi<E> builderApi;
        private readonly IBuilderPaymentComponent<E> builderComponents;
        public IBuilderPaymentComponent<E> BuilderComponents { get => builderComponents; }

        public TemplatePaymentShare(IMapper mapper, AuthService AuthService, T client, IBuilderPaymentComponent<E> builderComponents, NavigationManager navigation, IDialogService dialogService, ISnackbar snackbar) : base(mapper, AuthService, client)
        {
            builderComponents = new BuilderPaymentComponent<E>();
            this.navigation = navigation;
            this.dialogService = dialogService;
            this.Snackbar = snackbar;
            //this.builderApi = builderApi;
            this.builderComponents = builderComponents;
        }
    }

    public class BuilderCheckoutApiClient : BuilderCheckoutApi<CheckoutClientService, DataBuildPaymentBase>, IBuilderCheckoutApi<DataBuildPaymentBase>
    {
        public BuilderCheckoutApiClient(IMapper mapper, CheckoutClientService service) : base(mapper, service)
        {
        }

        public override async Task<Result<CheckoutResponse>> CheckoutAsync(DataBuildPaymentBase data)
        {
            var model = Mapper.Map<CheckoutRequest>(data);
            var res = await Service.CheckoutAsync(model);
            if (res.Succeeded)
            {
                return Result<CheckoutResponse>.Success(res.Data);
            }
            else
            {
                return Result<CheckoutResponse>.Fail(res.Messages);
            }
        }

        public override async Task<Result<CheckoutResponse>> CheckoutManageAsync(DataBuildPaymentBase data)
        {
            var res = await Service.CheckoutManageAsync(new SessionCreate { ReturnUrl = data.ReturnUrl });
            if (res.Succeeded)
            {
                return Result<CheckoutResponse>.Success(res.Data);
            }
            else
            {
                return Result<CheckoutResponse>.Fail(res.Messages);
            }
        }
    }

    [AutoSafeInvoke]
    public class TemplatePayment : TemplatePaymentShare<CheckoutClientService, DataBuildPaymentBase>
    {
        private readonly ISafeInvoker safeInvoker;
        public TemplatePayment(IMapper mapper, AuthService AuthService, CheckoutClientService client, IBuilderPaymentComponent<DataBuildPaymentBase> builderComponents, NavigationManager navigation, IDialogService dialogService, ISnackbar snackbar, ISafeInvoker safeInvoker) : base(mapper, AuthService, client, builderComponents, navigation, dialogService, snackbar)
        {
            this.BuilderComponents.SubmitCheckout = onSubmitCheckout;
            this.BuilderComponents.SubmitCheckoutManage = onSubmitCheckoutManage;
            this.builderApi = new BuilderCheckoutApiClient(mapper, client);
            Helper.Init(navigation);
            this.safeInvoker = safeInvoker;
        }

        public List<string> Errors { get => _errors; }

        private async Task onSubmitCheckout(DataBuildPaymentBase data)
        {
            await safeInvoker.InvokeAsync(async () =>
            {
                data.SuccessUrl = Helper.GetInstance().GetFullPath(RouterPage.DASHBOARD_SUBSCRIPTION);
                data.CancelUrl = Helper.GetInstance().GetFullPath($"payment/{data.PlanId}");
                var res = await builderApi.CheckoutAsync(data);
                if (res.Succeeded)
                {
                    if (res.Data != null && !string.IsNullOrEmpty(res.Data.Url))
                    {
                        navigation.NavigateTo(res.Data.Url, true);
                    }
                    else
                    {
                        navigation.NavigateTo(RouterPage.DASHBOARD_SUBSCRIPTION, true);
                    }
                }
                else
                {
                    if (res.Messages?.Count() > 0)
                    {
                        dynamic? response = JsonConvert.DeserializeObject<dynamic>(res.Messages[0]);
                        if (response?.status == 409)
                        {
                            string msg = (string)response.detail;
                            Snackbar.Add(msg ?? "Error", Severity.Warning);
                        }
                        else if (response?.status == 401)
                        {
                            navigation.NavigateTo($"{RouterPage.LOGOUT}/?InBackend={true}");
                        }
                        else
                        {
                            Snackbar.Add("Field Option ! Please try anther once or again login ", Severity.Error);
                        }
                    }
                    else
                    {
                        Snackbar.Add("Field Option ! Please try anther once or again login ", Severity.Error);
                    }
                }
            });
        }

        private async Task onSubmitCheckoutManage(DataBuildPaymentBase data)
        {
            await safeInvoker.InvokeAsync(async () =>
            {
                data.ReturnUrl = Helper.GetInstance().GetFullPath(RouterPage.DASHBOARD_SUBSCRIPTION);
                data.CancelUrl = Helper.GetInstance().GetFullPath(RouterPage.DASHBOARD_SUBSCRIPTION);
                data.SuccessUrl = Helper.GetInstance().GetFullPath(RouterPage.DASHBOARD_SUBSCRIPTION);
                var res = await builderApi.CheckoutManageAsync(data);
                if (res.Succeeded && !string.IsNullOrEmpty(res.Data.Url))
                {
                    navigation.NavigateTo(res.Data.Url, true);
                }
                else
                {
                    if (res.Messages?.Count() > 0)
                    {
                        dynamic? response = JsonConvert.DeserializeObject<dynamic>(res.Messages[0]);
                        if (response?.status == 409)
                        {
                            string msg = (string)response.detail;
                            Snackbar.Add(msg ?? "Error", Severity.Warning);
                        }
                        else if (response?.status == 401)
                        {
                            navigation.NavigateTo($"{RouterPage.LOGOUT}/?InBackend={true}");
                        }
                        else
                        {
                            Snackbar.Add("Field Option ! Please try anther once or again login ", Severity.Error);
                        }
                    }
                    else
                    {
                        Snackbar.Add("Field Option ! Please try anther once or again login ", Severity.Error);
                    }
                }
            });
        }

        public async Task<Result<CheckoutResponse>> CheckoutAsync(DataBuildPaymentBase DataBuildPaymentBase)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await builderApi.CheckoutAsync(DataBuildPaymentBase);
            });
        }
    }
}