using AutoMapper;
using Client.Shared.Execution;
using Domain.Entities;
using Domain.ShareData;
using Shared.Wrapper;
using LAHJA.Data.UI.Components.Base;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Helpers;
using LAHJA.Helpers.Enum;
using LAHJA.Providers;
using LAHJA.UI.Components;
using MudBlazor;
using Shared.Constants;
using Shared.Constants.Router;
using Shared.Enums;
using AutoGenerator.Attributes;
using Domain.Entity;
using Application.Services;
using AccessTokenResponse = LAHJA.Data.UI.Models.Auth.AccessTokenResponse;
using Shared.Failures.Auth;



namespace LAHJA.Data.UI.Templates.Auth;
/// <summary>
/// Interface to define authentication component lifecycle delegates
/// </summary>
public interface IBuilderAuthComponent<T> : IBuilderComponents<T>
{
    public Func<T, Task> SubmitExternalLogin { get; set; }
    public Func<T, Task> Submit { get; set; }

    public Func<Result, Task> SubmitResult { get; set; }

    public Func<T, Task> SubmitedForgetPassword { get; set; }
    public Func<T, Task> SubmitConfirmEmail { get; set; }
    public Func<T, Task> SubmitReSendConfirmEmail { get; set; }
    public Func<T, Task> SubmitResetPassword { get; set; }
    public Func<T, Task> SubmitLogout { get; set; }
}

/// <summary>
/// Interface to define the Auth Api services
/// </summary>
public interface IBuilderAuthApi<T> : IBuilderApi<T>
{
    Task<AccessTokenResponse> Login(T data, CancellationToken cancellationToken);
    Task ExternalLoginAsync(T data, CancellationToken cancellationToken);
    Task<AccessTokenResponse> RefreshToken(T data, CancellationToken cancellationToken);
    Task Logout(object data, CancellationToken cancellationToken);
    Task Register(T data, CancellationToken cancellationToken);
    Task ResetPassword(T data, CancellationToken cancellationToken);
    Task<string> ReSendConfirmationEmail(T data, CancellationToken cancellationToken);
    Task SubmitConfirmEmail(T data, CancellationToken cancellationToken);

   
}

public abstract class BuilderAuthApi<T, E> : BuilderApi<T, E>, IBuilderAuthApi<E>
{
    public BuilderAuthApi(IMapper mapper, T service) : base(mapper, service)
    {
    }

    public abstract Task ExternalLoginAsync(E data, CancellationToken cancellationToken);
    public abstract Task ForgetPassword(E data, CancellationToken cancellationToken);
    public abstract Task<AccessTokenResponse> Login(E data, CancellationToken cancellationToken);
    public abstract Task Logout(object data, CancellationToken cancellationToken);
    public abstract Task Register(E data, CancellationToken cancellationToken);
    public abstract Task<AccessTokenResponse> RefreshToken(E data, CancellationToken cancellationToken);
    public abstract Task<string> ReSendConfirmationEmail(E data, CancellationToken cancellationToken);
    public abstract Task ResetPassword(E data, CancellationToken cancellationToken);
    public abstract Task SubmitConfirmEmail(E data, CancellationToken cancellationToken);
}

public class BuilderAuthComponent<T> : IBuilderAuthComponent<T>
{
    public Func<Result, Task> SubmitResult { get; set; }
    public Func<T, Task> SubmitExternalLogin { get; set; }
    public Func<T, Task> Submit { get; set; }
    public Func<T, Task> SubmitedForgetPassword { get; set; }
    public Func<T, Task> SubmitConfirmEmail { get; set; }
    public Func<T, Task> SubmitReSendConfirmEmail { get; set; }
    public Func<T, Task> SubmitResetPassword { get; set; }
    public Func<T, Task> SubmitLogout { get; set; }
}
public class BuilderAuthApiClient : BuilderAuthApi<IAuthService, DataBuildAuthBase>, IBuilderAuthApi<DataBuildAuthBase>
{
    public BuilderAuthApiClient(IMapper mapper, IAuthService service) : base(mapper, service)
    {
    }

    public override async Task ExternalLoginAsync(DataBuildAuthBase data, CancellationToken cancellationToken)
    {
        var map_data = Mapper.Map<ExternalLoginRequest>(data);
        await Task.CompletedTask;
        //await Service.ExternalLoginAsync(map_data);
    }

    public override async Task ForgetPassword(DataBuildAuthBase data, CancellationToken cancellationToken)
    {
        var model = Mapper.Map<ForgetPassword>(data);
        model.ReturnUrl = Helper.GetInstance().GetFullPath(ConstantsApp.RESET_PASSWORDL_PAGE_URL); //   shareProvider.Navigation.anager.BaseUri+ConstantsApp.RESET_PASSWORDL_PAGE_URL;
        await Service.forgotPasswordAuthAsync(model, cancellationToken);
    }

    public override async Task<AccessTokenResponse> Login(DataBuildAuthBase data, CancellationToken cancellationToken)
    {
        var model = Mapper.Map<Login>(data);
        var res = await Service.loginAuthAsync(model, cancellationToken);
        return Mapper.Map<AccessTokenResponse>(res);
    }



    public override async Task Logout(object data, CancellationToken cancellationToken)
    {
        await Service.logoutAuthAsync(data, cancellationToken);
    }


    public async override Task<AccessTokenResponse> RefreshToken(DataBuildAuthBase data, CancellationToken cancellationToken)
    {
        var map_data = Mapper.Map<RefreshToken>(data);
        //return await Service.RefreshToken(map_data);
        return new();
    }

    public override async Task Register(DataBuildAuthBase data, CancellationToken cancellationToken)
    {
        var model = Mapper.Map<Register>(data);
        await Service.registerAuthAsync(model, cancellationToken);
    }

    public override async Task<string> ReSendConfirmationEmail(DataBuildAuthBase data, CancellationToken cancellationToken)
    {
        data.ReturnUrl = Helper.GetInstance().GetFullPath(ConstantsApp.CONFIRM_EMAIL_PAGE_URL);
        var model = Mapper.Map<ResendConfirmationEmail>(data);
        return await Service.resendConfirmationEmailAuthAsync(model, cancellationToken);

    }

    public override async Task ResetPassword(DataBuildAuthBase data, CancellationToken cancellationToken)
    {
        var model = Mapper.Map<ResetPassword>(data);
        await Service.resetPasswordAuthAsync(model, cancellationToken);
    }

    public override async Task SubmitConfirmEmail(DataBuildAuthBase data, CancellationToken cancellationToken)
    {
        var model = Mapper.Map<ConfirmEmail>(data);
        await Service.confirmationEmailAuthAsync(model, cancellationToken);
    }
}
public class TemplateAuthShare<T, E> : TemplateBase<T, E>
{
    public IBuilderAuthComponent<E> BuilderComponents { get => builderComponents; }

    protected IBuilderAuthApi<E> builderApi;
    protected readonly IShareTemplateProvider shareProvider;
    protected readonly CustomAuthenticationStateProvider AuthStateProvider;
    private readonly IBuilderAuthComponent<E> builderComponents;
    public TemplateAuthShare(CustomAuthenticationStateProvider authStateProvider, Helpers.Services.AuthService authService, T client, IBuilderAuthComponent<E> builderComponents, IShareTemplateProvider shareProvider) : base(shareProvider.Mapper, authService, client)
    {
        //builderComponents = new BuilderAuthComponent<E>();
        this.builderComponents = builderComponents;
        AuthStateProvider = authStateProvider;
        this.shareProvider = shareProvider;
    }
}



[AutoSafeInvoke]
public class TemplateAuth : TemplateAuthShare<IAuthService, DataBuildAuthBase>
{

    private readonly ICancelableTaskExecutor taskExecutor;
    private readonly ISessionUserManager sessionUserManager;
    private readonly ISafeInvoker safeInvoker;

   

    public TemplateAuth(Helpers.Services.AuthService authService, 
        IAuthService client, 
        CustomAuthenticationStateProvider authStateProvider, 
        IBuilderAuthComponent<DataBuildAuthBase> builderComponents, 
        IShareTemplateProvider shareProvider, 
        ISafeInvoker safeInvoker, 
        ISessionUserManager sessionUserManager, 
        ICancelableTaskExecutor taskExecutor) : base(authStateProvider, authService, client, builderComponents, shareProvider)
    {
        this.BuilderComponents.SubmitExternalLogin = OnSubmitExternalLogin;
        this.BuilderComponents.Submit = OnSubmit;
        this.BuilderComponents.SubmitLogout = OnSubmitLogout;
        this.BuilderComponents.SubmitConfirmEmail = OnSubmitConfirmEmail;
        this.BuilderComponents.SubmitReSendConfirmEmail = OnReSendConfirmationEmail;
        this.BuilderComponents.SubmitResetPassword = OnResetPassword;
        this.BuilderComponents.SubmitedForgetPassword = OnSubmitForgetPasswordAsync;
        this.builderApi = new BuilderAuthApiClient(mapper, client);
        this.sessionUserManager = sessionUserManager;
        this.safeInvoker = safeInvoker;
        this.taskExecutor = taskExecutor;
    }

    public List<string> Errors { get => _errors; }

    public async Task LogoutAsync()
    {
      
        await OnSubmitLogout();
        
    }

    /// <summary>
    ///   Edit in 24/3/2025 
    /// </summary>
    /// <param name = "request"></param>
    /// <returns></returns>
    public async Task<Result<AccessTokenResponse>> RefreshToken(DataBuildAuthBase data)
    {

      return  Result<AccessTokenResponse>.Success();

        //return await safeInvoker.InvokeAsync(async () =>
        //{
        //    var response = await builderApi.RefreshToken(data);
        //    if (response.Succeeded)
        //    {
        //        await authService.DeleteLoginAsync();
        //        var (model,cancellationToken) = mapper.Map<LoginResponse>(response.Data);
        //        initAuth((model,cancellationToken), LoginType.Email);
        //        await AuthStateProvider.InitializeAsync();
        //    }
        //    else
        //    {
        //        await OnSubmitLogout();
        //    }

        //    return response;
        //});
    }

    [IgnoreSafeInvoke]
    private async Task<bool> ConfirmAsync(string title, string message)
    {
        var dialog = await shareProvider.DialogNotification.ShowDialogAsync<DialogBox>(title: title, message: message, maxWidth: MaxWidth.Small);
        var result = await dialog.Result;
        return !result.Canceled;
    }

    public async Task<Result> ReForgetPassword(DataBuildAuthBase data)
    {
      return  await safeInvoker.InvokeAsync(async () =>
        {
            return await taskExecutor.RunAsync(async (token) =>
            {
               await builderApi.ResetPassword(data,token);
                
         
                //if (response.Succeeded)
                //{
                //    var msg = MapperMessages.Map(SuccessMessages.LINK_SENT_SUCCESSFULLY_EN, SuccessMessages.LINK_SENT_SUCCESSFULLY_AR);
                //    shareProvider.DialogNotification.ShowSnackbar(msg, Severity.Success);
                //}
                //else
                //{
                //    var msg = MapperMessages.Map(ErrorMessages.PROCESS_IS_FAILED_EN, ErrorMessages.PROCESS_IS_FAILED_AR);
                //    shareProvider.DialogNotification.ShowSnackbar(msg, Severity.Success);
                //}
            });
        });
    }

    public async Task<Result> ReSendConfirmationEmail(DataBuildAuthBase data)
    {
       return await safeInvoker.InvokeAsync(async () =>
        {
            return await taskExecutor.RunAsync(async (token) =>
            {
               var response= await builderApi.ReSendConfirmationEmail(data,token);
                if (response != null)
                {
                    var parameters = new Dictionary<string, object>
                    {
                        ["Email"] = data.Email,
                        ["Url"] = data.ReturnUrl,
                        ["Method"] = AuthMethods.ConfirmEmail.ToString()
                    };
                    shareProvider.NavigationService.GoTo(RouterPage.EMAIL_CONFIRM_PAGE, parameters, forceReload: true);
                }
                else
                {
                    var res = await ConfirmAsync("Error", ErrorMessages.PROCESS_IS_FAILED_EN);
                }
                //if (response.Succeeded)
                //{
                //    var msg = MapperMessages.Map(SuccessMessages.LINK_SENT_SUCCESSFULLY_EN, SuccessMessages.LINK_SENT_SUCCESSFULLY_AR);
                //    shareProvider.DialogNotification.ShowSnackbar(msg, Severity.Success);
                //}
                //else
                //{
                //    //if (response.Messages != null && response.Messages.Count() > 0)
                //    {
                //        var msg = MapperMessages.Map(ErrorMessages.PROCESS_IS_FAILED_EN, ErrorMessages.PROCESS_IS_FAILED_AR);
                //        shareProvider.DialogNotification.ShowSnackbar(msg, Severity.Success);
                //    }
                //}
            });
        });
    }

    private async Task OnReSendConfirmationEmail(DataBuildAuthBase data)
    {
        await safeInvoker.InvokeAsync(async () =>
        {
            return await taskExecutor.RunAsync<string>(async (token) =>
            {
               
                var response= await builderApi.ReSendConfirmationEmail(data,token);

                if (response!=null)
                {
                    var parameters = new Dictionary<string, object>
                    {
                        ["Email"] = data.Email,
                        ["Url"] = data.ReturnUrl,
                        ["Method"] = AuthMethods.ConfirmEmail.ToString()
                    };
                    shareProvider.NavigationService.GoTo(RouterPage.EMAIL_CONFIRM_PAGE, parameters, forceReload: true);
                }
                else
                {
                    var res = await ConfirmAsync("Error", ErrorMessages.PROCESS_IS_FAILED_EN);
                }

                return response;
            });
        });
    }

    protected async Task OnResetPassword(DataBuildAuthBase data)
    {

        
        //await safeInvoker.InvokeAsync(async () =>
        //{
        //    var response = await builderApi.ResetPassword(dataBuildAuthBase);
        //    if (response.Succeeded)
        //    {
        //        shareProvider.NavigationService.GoTo(RouterPage.LOGIN, new(), true);
        //    }
        //    else
        //    {
        //        if (response.Messages != null && response.Messages.Count() > 0)
        //        {
        //            var msg = MapperMessages.Map(ErrorMessages.INVALID_EMAIL_EN, ErrorMessages.IINVALID_EMAIL_AR);
        //            _errors?.Clear();
        //            _errors.Add(msg);
        //            shareProvider.DialogNotification.ShowSnackbar(msg, Severity.Error);
        //        }
        //    };
        //});
    }

    protected async Task OnSubmitConfirmEmail(DataBuildAuthBase data)
    { 
        var result = await safeInvoker.InvokeAsync(async () =>
        {
            // ≈⁄œ«œ —«»ÿ «·⁄Êœ…
            data.ReturnUrl = Helper.GetInstance().GetFullPath(ConstantsApp.CONFIRM_EMAIL_PAGE_URL);

            return await taskExecutor.RunAsync(async (token) =>
            {
                // «” œ⁄«¡ API
                await builderApi.SubmitConfirmEmail(data, token);

                //  √ﬂÌœ «·⁄„·Ì… ··„” Œœ„
                var confirmed = await ConfirmAsync("Confirm Email", SuccessMessages.CONFIRM_EMAIL_MESSAGE_EN);
                if (confirmed == true)
                {
                    // «‰ ﬁ«· ≈·Ï ’›Õ…  ”ÃÌ· «·œŒÊ· »⁄œ «· √ﬂÌœ
                    shareProvider.NavigationService.GoTo(RouterPage.LOGIN, new(), true);
                }

                return true; //  „ «· ‰›Ì– »‰Ã«Õ
            });
        });

        // ≈⁄·«„ «·‹ UI »«·‰ ÌÃ…
        BuilderComponents?.SubmitResult?.Invoke(result);
    }



    [IgnoreSafeInvoke]
    private async Task OnSubmitExternalLogin(DataBuildAuthBase request)
    {
        try
        {
            request.ReturnUrl = Helper.GetInstance().GetFullPath(ConstantsApp.RETEURN_EXTERNAL_LOGIN_PAGE);
            var parameters = new Dictionary<string, object>
            {
                ["provider"] = request.Provider,
                ["returnUrl"] = request.ReturnUrl
            };
            shareProvider.NavigationService.GoTo("https://asg-api.runasp.net/api/ExternalLogin", parameters, forceReload: true);
        }
        catch (Exception e)
        {
            shareProvider.DialogNotification.ShowSnackbar(e.Message, Severity.Error);
        }
    }

    [IgnoreSafeInvoke]
    private async Task OnSubmit(DataBuildAuthBase dataBuildAuthBase)
    {
        if (dataBuildAuthBase != null)
        {
            if (dataBuildAuthBase.IsLogin)
            {
                var result = await handleApiLoginAsync(dataBuildAuthBase);
                if(BuilderComponents?.SubmitResult!=null)
                    BuilderComponents?.SubmitResult.Invoke(result);
            }
            else
            {
               var result= await handleApiRegisterAsync(dataBuildAuthBase);
                if (BuilderComponents?.SubmitResult != null)
                    BuilderComponents?.SubmitResult?.Invoke(result);

            }
        }
    }

    private async Task OnSubmitForgetPasswordAsync(DataBuildAuthBase data)
    {
        await safeInvoker.InvokeAsync(async () =>
        {
            //var response = await builderApi.ForgetPassword(data);
            //if (response.Succeeded)
            //{
            //    var fullPath = Helper.GetInstance().GetFullPath(ConstantsApp.RESET_PASSWORDL_PAGE_URL);
            //    var parameters = new Dictionary<string, object>
            //    {
            //        ["Email"] = data.Email,
            //        ["Url"] = fullPath,
            //        ["Method"] = AuthMethods.ForgetPassword.ToString()
            //    };
            //    shareProvider.NavigationService.GoTo(RouterPage.EMAIL_CONFIRM_PAGE, parameters, forceReload: true);
            //}
            //else
            //{
            //    if (response.Messages != null && response.Messages.Count() > 0)
            //    {
            //        _errors?.Clear();
            //        var msg = MapperMessages.Map(ErrorMessages.INVALID_EMAIL_EN, ErrorMessages.IINVALID_EMAIL_AR);
            //        shareProvider.DialogNotification.ShowSnackbar(msg, Severity.Error);
            //        _errors.Add(msg);
            //    }
            //}
        });
    }

    [IgnoreSafeInvoke]
    private void initAuth(AccessTokenResponse response, LoginType loginType)
    {
        var parameters = new Dictionary<string, object>
        {
            [ConstantsApp.ACCESS_TOKEN] = response.AccessToken,
            [ConstantsApp.REFRESH_TOKEN] = response.RefreshToken,
            [ConstantsApp.LOGIN_TYPE] = loginType.ToString()
        };
        shareProvider.NavigationService.GoTo($"/{RouterPage.SIGIN_PAGE}", parameters, forceReload: true);
    }

    /// <summary>
    ///   Edit in 24/3/2025 
    /// </summary>
    /// <param name = "request"></param>
    /// <returns></returns>
    private async Task saveLoginAsync(AccessTokenResponse response, LoginType loginType)
    {
        await safeInvoker.InvokeAsync(async () =>
        {
            await authService.SaveLoginAsync(response);
            await authService.SaveLoginTypeAsync(loginType);
        });
    }

    /// <summary>
    ///   
    /// </summary>
    /// <param name = "date"></param>
    /// <returns></returns>

    private async Task<Result> handleApiLoginAsync(DataBuildAuthBase date)
    {
       var result= await safeInvoker.InvokeAsync<Result<AccessTokenResponse>>(async () =>
        {
            return await taskExecutor.RunAsync(async (token) =>
            {
                var response = await builderApi.Login(date, token);
                if (response != null)
                {
                    initAuth(response, LoginType.Email);
                    return response;
                }

                throw new Exception("Login failed: response is null.");
            });
        });

        if (result != null)
        {
            if (result.Failure is InvalidCredentialsFailure
            || result.Failure is InvalidEmailFailure
                || result.Failure is IncorrectPasswordFailure)
            {
                _errors = new List<string> { result.Failure.Message };
            }
        }
        return result;
    }

    private async Task<Result> handleApiRegisterAsync(DataBuildAuthBase data)
    {
       var result =  await safeInvoker.InvokeAsync(async () =>
        {
            return await taskExecutor.RunAsync(async (token) =>
            {
                data.ReturnUrl = Helper.GetInstance().GetFullPath(ConstantsApp.CONFIRM_EMAIL_PAGE_URL);
                await builderApi.Register(data,token);
            });
        });

        if (result != null)
        {
            if (!result.Succeeded)
            {
                if (result.Failure is InvalidCredentialsFailure
                || result.Failure is InvalidEmailFailure
                || result.Failure is InvalidPhoneNumberFailure)
                {
                    _errors = new List<string> { result.Failure.Message };
                }
            }
            else
            {
                shareProvider.NavigationService.GoTo(RouterPage.EMAIL_CONFIRM_PAGE,
                    new Dictionary<string, object>
                    {
                        ["Email"] = data.Email,
                        ["Url"] = data.ReturnUrl,
                        ["Method"] = AuthMethods.ConfirmEmail.ToString(),
                    }, true);
            }
 
        }
 

        return result;
    }

    /// <summary>
    ///   Edit in 24/3/2025 
    /// </summary>
    /// <param name = "request"></param>
    /// <returns></returns>
    private async Task<Result> OnSubmitLogout(DataBuildAuthBase? dataBuildAuthBase = null)
    {
        return await safeInvoker.InvokeAsync(async () =>
        {
            return await taskExecutor.RunAsync(async (token) =>
            {
                await builderApi.Logout(await authService.GetAccessTokenAsync()??"", token);
             
                await authService.DeleteLoginAsync();
                await authService.RemoveCookiesAsync();
                AuthStateProvider.MarkUserAsLoggedOut();
                shareProvider.NavigationService.GoTo(RouterPage.SIGINOUT_PAGE, null, true);
            });
        });
    }
}