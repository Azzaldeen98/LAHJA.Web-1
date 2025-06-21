//using AutoMapper;
//using Client.Shared.Execution;
//using Domain.Entities;
//using Domain.Entities.Auth.Request;
//using Domain.Entities.Auth.Response;
//using Domain.ShareData;
//using Shared.Wrapper;
//using LAHJA.Data.UI.Components.Base;
//using LAHJA.Data.UI.Templates.Base;
//using LAHJA.Helpers;
//using LAHJA.Helpers.Enum;
//using LAHJA.Providers;
//using LAHJA.UI.Components;

//using MudBlazor;
//using Shared.Constants;
//using Shared.Constants.Router;
//using LAHJA.ApplicationLayer.Auth;
//


//namespace LAHJA.Data.UI.Templates.Auth;



///// <summary>
///// Interface to define authentication component lifecycle delegates
///// </summary>
//public interface IBuilderAuthComponent<T> : IBuilderComponents<T>
//{
//    public Func<T, Task> SubmitExternalLogin { get; set; }
//    public Func<T, Task> Submit { get; set; }
//    public Func<T, Task> SubmitedForgetPassword { get; set; }
//    public Func<T, Task> SubmitConfirmEmail { get; set; }
//    public Func<T, Task> SubmitReSendConfirmEmail { get; set; }
//    public Func<T, Task> SubmitResetPassword { get; set; }
//    public Func<T, Task> SubmitLogout { get; set; }


//}

///// <summary>
///// Interface to define the Auth Api services
///// </summary>
//public interface IBuilderAuthApi<T> : IBuilderApi<T>
//{
//    Task<Result<LoginResponse>> Login(T data);
//    Task ExternalLoginAsync(T data);
//    Task<Result<AccessTokenResponse>> RefreshToken(T data);
//    Task<Result<string>> Logout();
//    Task<Result<RegisterResponse>> Register(T data);
//    Task<Result<ResetPasswordResponse>> ResetPassword(T data);
//    Task<Result> ReSendConfirmationEmail(T data);
//    Task<Result> SubmitConfirmEmail(T data);
//    Task<Result> ForgetPassword(T data);
//}

//public abstract class BuilderAuthApi<T, E> : BuilderApi<T, E>, IBuilderAuthApi<E>
//{

//    public BuilderAuthApi(IMapper mapper, T service) : base(mapper, service)
//    {

//    }

//    public abstract Task ExternalLoginAsync(E data);
//    public abstract Task<Result> ForgetPassword(E data);
//    public abstract Task<Result<LoginResponse>> Login(E data);
//    public abstract Task<Result<string>> Logout();
//    public abstract Task<Result<RegisterResponse>> Register(E data);
//    public abstract Task<Result<AccessTokenResponse>> RefreshToken(E data);

//    public abstract Task<Result> ReSendConfirmationEmail(E data);

//    public abstract Task<Result<ResetPasswordResponse>> ResetPassword(E data);

//    public abstract Task<Result> SubmitConfirmEmail(E data);

//}
//public class BuilderAuthComponent<T> : IBuilderAuthComponent<T>
//{

//    public Func<T, Task> SubmitExternalLogin { get; set; }
//    public Func<T, Task> Submit { get; set; }
//    public Func<T, Task> SubmitedForgetPassword { get; set; }
//    public Func<T, Task> SubmitConfirmEmail { get; set; }
//    public Func<T, Task> SubmitReSendConfirmEmail { get; set; }
//    public Func<T, Task> SubmitResetPassword { get; set; }
//    public Func<T, Task> SubmitLogout { get; set; }

//}


//public class TemplateAuthShare<T, E> : TemplateBase<T, E>
//{
//    public IBuilderAuthComponent<E> BuilderComponents { get => builderComponents; }
//    protected IBuilderAuthApi<E> builderApi;

//    protected readonly IShareTemplateProvider shareProvider;
//    protected readonly CustomAuthenticationStateProvider AuthStateProvider;

//    private readonly IBuilderAuthComponent<E> builderComponents;

//    public TemplateAuthShare(
//           CustomAuthenticationStateProvider authStateProvider,
//           Helpers.Services.AuthService authService,
//            T client,
//            IBuilderAuthComponent<E> builderComponents,
//            IShareTemplateProvider shareProvider) : base(shareProvider.Mapper, authService, client)
//    {



//        //builderComponents = new BuilderAuthComponent<E>();
//        this.builderComponents = builderComponents;
//        AuthStateProvider = authStateProvider;
//        this.shareProvider = shareProvider;
//    }

//}


//public class BuilderAuthApiClient : BuilderAuthApi<ApplicationLayer.Auth.ClientAuthService, DataBuildAuthBase>, IBuilderAuthApi<DataBuildAuthBase>
//{


//    public BuilderAuthApiClient(IMapper mapper, ApplicationLayer.Auth.ClientAuthService service) : base(mapper, service)
//    {
//    }

//    public override async Task ExternalLoginAsync(DataBuildAuthBase data)
//    {
//        var map_data = Mapper.Map<ExternalLoginRequest>(data);
//        await Service.ExternalLoginAsync(map_data);

//    }
//    public override async Task<Result> ForgetPassword(DataBuildAuthBase data)
//    {
//        var model = Mapper.Map<ForgetPasswordRequest>(data);

//        model.ReturnUrl = Helper.GetInstance().GetFullPath(ConstantsApp.RESET_PASSWORDL_PAGE_URL);//   shareProvider.Navigation.anager.BaseUri+ConstantsApp.RESET_PASSWORDL_PAGE_URL;
//        return await Service.forgetPasswordAsync(model);
//    }

//    public override async Task<Result<LoginResponse>> Login(DataBuildAuthBase data)
//    {
//        var model = Mapper.Map<LoginRequest>(data);

//        return await Service.loginAsync(model);

//    }

//    public override async Task<Result<string>> Logout()
//    {

//        return await Service.logoutAsync();

//    }

//    public async override Task<Result<AccessTokenResponse>> RefreshToken(DataBuildAuthBase data)
//    {
//        var map_data = Mapper.Map<RefreshRequest>(data);
//        return await Service.RefreshToken(map_data);
//    }

//    public override async Task<Result<RegisterResponse>> Register(DataBuildAuthBase data)
//    {
//        var model = Mapper.Map<RegisterRequest>(data);
//        return await Service.registerAsync(model);
//    }

//    public override async Task<Result> ReSendConfirmationEmail(DataBuildAuthBase data)
//    {
//        var model = Mapper.Map<ResendConfirmationEmail>(data);
//        return await Service.reConfirmationEmailAsync(model);
//    }

//    public override async Task<Result<ResetPasswordResponse>> ResetPassword(DataBuildAuthBase data)
//    {
//        var model = Mapper.Map<ResetPasswordRequest>(data);

//        return await Service.resetPasswordAsync(model);
//    }

//    public override async Task<Result> SubmitConfirmEmail(DataBuildAuthBase data)
//    {
//        var model = Mapper.Map<ConfirmationEmail>(data);
//        return await Service.confirmationEmailAsync(model);
//    }
//}


//[AutoSafeInvoke]
//public class TemplateAuth : TemplateAuthShare<ClientAuthService, DataBuildAuthBase>
//{


//    private readonly ISessionUserManager sessionUserManager;
//    private readonly ISafeInvoker safeInvoker;

//    public TemplateAuth(Helpers.Services.AuthService authService,
//          ApplicationLayer.Auth.ClientAuthService client,
//        CustomAuthenticationStateProvider authStateProvider,
//        IBuilderAuthComponent<DataBuildAuthBase> builderComponents,
//        IShareTemplateProvider shareProvider,
//        ISafeInvoker safeInvoker,
//        ISessionUserManager sessionUserManager) : base(authStateProvider, authService, client, builderComponents, shareProvider)
//    {
//        this.BuilderComponents.SubmitExternalLogin = OnSubmitExternalLogin;
//        this.BuilderComponents.Submit = OnSubmit;
//        this.BuilderComponents.SubmitLogout = OnSubmitLogout;
//        this.BuilderComponents.SubmitConfirmEmail = OnSubmitConfirmEmail;
//        this.BuilderComponents.SubmitReSendConfirmEmail = OnReSendConfirmationEmail;
//        this.BuilderComponents.SubmitResetPassword = OnResetPassword;
//        this.BuilderComponents.SubmitedForgetPassword = OnSubmitForgetPasswordAsync;

//        //this.BuilderComponents.SubmitExternalLogin = async data =>await safeInvoker.InvokeAsync(() => OnSubmitExternalLogin(data));
//        //this.BuilderComponents.Submit = async data =>await safeInvoker.InvokeAsync(() => OnSubmit(data));
//        //this.BuilderComponents.SubmitLogout = async data =>await safeInvoker.InvokeAsync(() => OnSubmitLogout(data));
//        //this.BuilderComponents.SubmitConfirmEmail = async data =>await safeInvoker.InvokeAsync(() => OnSubmitConfirmEmail(data));
//        //this.BuilderComponents.SubmitReSendConfirmEmail = async data =>await safeInvoker.InvokeAsync(() => OnReSendConfirmationEmail(data));
//        //this.BuilderComponents.SubmitResetPassword = async data =>await safeInvoker.InvokeAsync(() => OnResetPassword(data));
//        //this.BuilderComponents.SubmitedForgetPassword = async data =>await safeInvoker.InvokeAsync(() => OnSubmitForgetPasswordAsync(data));

//        this.builderApi = new BuilderAuthApiClient(mapper, client);
//        this.sessionUserManager = sessionUserManager;
//        this.safeInvoker = safeInvoker;
//    }



//    public List<string> Errors { get => _errors; }


//    public async Task LogoutAsync()
//    {
//        await OnSubmitLogout();
//    }

//    /// <summary>
//    ///   Edit in 24/3/2025 
//    /// </summary>
//    /// <param name="request"></param>
//    /// <returns></returns>
//    public async Task<Result<AccessTokenResponse>> RefreshToken(DataBuildAuthBase data)
//    {
//        var response = await builderApi.RefreshToken(data);
//        if (response.Succeeded)
//        {

//            await authService.DeleteLoginAsync();
//            var model = mapper.Map<LoginResponse>(response.Data);
//            initAuth(model, LoginType.Email);
//            await AuthStateProvider.InitializeAsync();
//        }
//        else
//        {
//            await OnSubmitLogout();
//        }



//        return response;
//    }

//    [IgnoreSafeInvoke]
//    private async Task<bool> ConfirmAsync(string title, string message)
//    {

//        var dialog = await shareProvider.DialogNotification.ShowDialogAsync<DialogBox>(title: title, message: message, maxWidth: MaxWidth.Small);
//        var result = await dialog.Result;
//        return !result.Canceled;


//    }
//    public async Task ReForgetPassword(DataBuildAuthBase data)
//    {
//        var response = await builderApi.ForgetPassword(data);
//        if (response.Succeeded)
//        {
//            var msg = MapperMessages.Map(SuccessMessages.LINK_SENT_SUCCESSFULLY_EN, SuccessMessages.LINK_SENT_SUCCESSFULLY_AR);
//            shareProvider.DialogNotification.ShowSnackbar(msg, Severity.Success);
//        }
//        else
//        {
//            var msg = MapperMessages.Map(ErrorMessages.PROCESS_IS_FAILED_EN, ErrorMessages.PROCESS_IS_FAILED_AR);
//            shareProvider.DialogNotification.ShowSnackbar(msg, Severity.Success);

//        }
//    }

//    public async Task ReSendConfirmationEmail(DataBuildAuthBase data)
//    {
//        var response = await builderApi.ReSendConfirmationEmail(data);
//        if (response.Succeeded)
//        {
//            var msg = MapperMessages.Map(SuccessMessages.LINK_SENT_SUCCESSFULLY_EN, SuccessMessages.LINK_SENT_SUCCESSFULLY_AR);
//            shareProvider.DialogNotification.ShowSnackbar(msg, Severity.Success);
//        }
//        else
//        {
//            //if (response.Messages != null && response.Messages.Count() > 0)
//            {
//                var msg = MapperMessages.Map(ErrorMessages.PROCESS_IS_FAILED_EN, ErrorMessages.PROCESS_IS_FAILED_AR);
//                shareProvider.DialogNotification.ShowSnackbar(msg, Severity.Success);

//            }
//        }
//    }
//    public async Task OnReSendConfirmationEmail(DataBuildAuthBase data)
//    {

//        data.ReturnUrl = Helper.GetInstance().GetFullPath(ConstantsApp.CONFIRM_EMAIL_PAGE_URL);
//        var response = await builderApi.ReSendConfirmationEmail(data);
//        if (response.Succeeded)
//        {

//            var parameters = new Dictionary<string, object>
//            {
//                ["Email"] = data.Email,
//                ["Url"] = data.ReturnUrl,
//                ["Method"] = AuthMethods.ConfirmEmail.ToString()
//            };

//            shareProvider.NavigationService.GoTo(RouterPage.EMAIL_CONFIRM_PAGE, parameters, forceReload: true);


//        }
//        else
//        {
//            var res = await ConfirmAsync("Error", ErrorMessages.PROCESS_IS_FAILED_EN);

//        }
//    }

//    protected async Task OnResetPassword(DataBuildAuthBase dataBuildAuthBase)
//    {
//        var response = await builderApi.ResetPassword(dataBuildAuthBase);
//        if (response.Succeeded)
//        {
//            shareProvider.NavigationService.GoTo(RouterPage.LOGIN, new(), true);
//        }
//        else
//        {
//            if (response.Messages != null && response.Messages.Count() > 0)
//            {
//                var msg = MapperMessages.Map(ErrorMessages.INVALID_EMAIL_EN, ErrorMessages.IINVALID_EMAIL_AR);
//                _errors?.Clear();
//                _errors.Add(msg);
//                shareProvider.DialogNotification.ShowSnackbar(msg, Severity.Error);
//            }
//        }
//        ;
//    }

//    protected async Task OnSubmitConfirmEmail(DataBuildAuthBase dataBuildAuthBase)
//    {
//        dataBuildAuthBase.ReturnUrl = Helper.GetInstance().GetFullPath(ConstantsApp.CONFIRM_EMAIL_PAGE_URL); //  shareProvider.Navigation.anager.BaseUri + ConstantsApp.CONFIRM_EMAIL_PAGE_URL;

//        var response = await builderApi.SubmitConfirmEmail(dataBuildAuthBase);
//        if (response.Succeeded)
//        {

//            var res = await ConfirmAsync("Confirm Email", SuccessMessages.CONFIRM_EMAIL_MESSAGE_EN);
//            if (res == true)
//            {
//                shareProvider.NavigationService.GoTo(RouterPage.LOGIN, new(), true);
//            }



//        }
//        else
//        {

//            var res = await ConfirmAsync("Error", ErrorMessages.PROCESS_IS_FAILED_EN);

//        }
//    }
//    [IgnoreSafeInvoke]
//    private async Task OnSubmitExternalLogin(DataBuildAuthBase request)
//    {

//        try
//        {
//            request.ReturnUrl = Helper.GetInstance().GetFullPath(ConstantsApp.RETEURN_EXTERNAL_LOGIN_PAGE);
//            var parameters = new Dictionary<string, object>
//            {
//                ["provider"] = request.Provider,
//                ["returnUrl"] = request.ReturnUrl
//            };

//            shareProvider.NavigationService.GoTo("https://asg-api.runasp.net/api/ExternalLogin", parameters, forceReload: true);


//        }
//        catch (Exception e)
//        {

//            shareProvider.DialogNotification.ShowSnackbar(e.Message, Severity.Error);
//        }




//    }

//    [IgnoreSafeInvoke]
//    private async Task OnSubmit(DataBuildAuthBase dataBuildAuthBase)
//    {

//        if (dataBuildAuthBase != null)
//        {
//            if (dataBuildAuthBase.IsLogin)
//            {


//                await handleApiLoginAsync(dataBuildAuthBase);

//            }
//            else
//            {

//                await handleApiRegisterAsync(dataBuildAuthBase);
//            }
//        }

//    }


//    private async Task OnSubmitForgetPasswordAsync(DataBuildAuthBase data)
//    {
//        var response = await builderApi.ForgetPassword(data);
//        if (response.Succeeded)
//        {
//            var fullPath = Helper.GetInstance().GetFullPath(ConstantsApp.RESET_PASSWORDL_PAGE_URL);

//            var parameters = new Dictionary<string, object>
//            {
//                ["Email"] = data.Email,
//                ["Url"] = fullPath,
//                ["Method"] = AuthMethods.ForgetPassword.ToString()
//            };

//            shareProvider.NavigationService.GoTo(RouterPage.EMAIL_CONFIRM_PAGE, parameters, forceReload: true);



//        }
//        else
//        {
//            if (response.Messages != null && response.Messages.Count() > 0)
//            {

//                _errors?.Clear();
//                var msg = MapperMessages.Map(ErrorMessages.INVALID_EMAIL_EN, ErrorMessages.IINVALID_EMAIL_AR);
//                shareProvider.DialogNotification.ShowSnackbar(msg, Severity.Error);
//                _errors.Add(msg);

//            }
//        }
//    }

//    [IgnoreSafeInvoke]
//    private void initAuth(LoginResponse response, LoginType loginType)
//    {
//        var parameters = new Dictionary<string, object>
//        {
//            [ConstantsApp.ACCESS_TOKEN] = response.accessToken,
//            [ConstantsApp.REFRESH_TOKEN] = response.refreshToken,
//            [ConstantsApp.LOGIN_TYPE] = loginType.ToString()
//        };

//        shareProvider.NavigationService.GoTo($"/{RouterPage.SIGIN_PAGE}", parameters, forceReload: true);

//    }
//    /// <summary>
//    ///   Edit in 24/3/2025 
//    /// </summary>
//    /// <param name="request"></param>
//    /// <returns></returns>
//    private async Task saveLoginAsync(LoginResponse response, LoginType loginType)
//    {
//        await authService.SaveLoginAsync(response);
//        await authService.SaveLoginTypeAsync(loginType);
//    }
//    /// <summary>
//    ///   Edit in 24/3/2025 
//    /// </summary>
//    /// <param name="request"></param>
//    /// <returns></returns>
//    private async Task handleApiLoginAsync(DataBuildAuthBase date)
//    {
//        var response = await builderApi.Login(date);


//        if (response.Succeeded)
//        {


//            initAuth(response.Data, LoginType.Email);



//        }
//        else
//        {
//            if (response.Messages != null && response.Messages.Count() > 0)
//            {
//                // errorMessages.AddRange(response.Messages);

//            }

//            //  shareProvider.Navigation.NavigateTo(RouterPage.LOGIN, forceLoad: true);
//        }
//    }
//    private async Task handleApiRegisterAsync(DataBuildAuthBase data)
//    {
//        data.ReturnUrl = Helper.GetInstance().GetFullPath(ConstantsApp.CONFIRM_EMAIL_PAGE_URL);

//        var response = await builderApi.Register(data);
//        if (response.Succeeded)
//        {

//            shareProvider.NavigationService.GoTo(RouterPage.EMAIL_CONFIRM_PAGE,
//                new Dictionary<string, object>
//                {
//                    ["Email"] = data.Email,
//                    ["Url"] = data.ReturnUrl,
//                    ["Method"] = AuthMethods.ConfirmEmail.ToString(),
//                }, true);

//        }
//        else
//        {
//            if (response.Messages != null && response.Messages.Count() > 0)
//            {

//                shareProvider.DialogNotification.ShowSnackbar(response.Messages[0], Severity.Error);

//            }
//        }
//    }

//    /// <summary>
//    ///   Edit in 24/3/2025 
//    /// </summary>
//    /// <param name="request"></param>
//    /// <returns></returns>
//    private async Task OnSubmitLogout(DataBuildAuthBase? dataBuildAuthBase = null)
//    {

//        var response = await builderApi.Logout();
//        if (response.Succeeded)
//        {

//        }



//        await authService.DeleteLoginAsync();
//        await authService.RemoveCookiesAsync();

//        AuthStateProvider.MarkUserAsLoggedOut();
//        //await AuthStateProvider.InitializeAsync();
//        shareProvider.NavigationService.GoTo(RouterPage.SIGINOUT_PAGE, null, true);


//    }

//}








