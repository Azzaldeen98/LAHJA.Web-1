using AutoMapper;
using Domain.Entities.AuthorizationSession;
using Domain.ShareData.Base;
using Shared.Wrapper;
using LAHJA.ApplicationLayer.AuthorizationSession;
using LAHJA.Data.UI.Components;
using LAHJA.Data.UI.Models.SessionTokenAuth;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Client.Shared.Execution;
using AutoGenerator.Attributes;

namespace LAHJA.Data.UI.Templates.AuthSession
{
    //public class DataBuildSessionTokenAuth
    //{
    //    public string Id { get; set; }
    //    public string Email { get; set; }
    //}
    public interface IBuilderAuthSessionComponent<T> : IBuilderComponents<T>
    {
        public Func<T, Task<Result<AuthorizationSessionWebResponse>>> SubmitCreateSessionToken { get; set; }
        public Func<Task<Result<List<SessionTokenAuth>>>> GetSessionsAccessTokens { get; set; }
        public Func<DataBuildSessionTokenAuth, Task<Result<DeleteResponse>>> SubmitDeleteSessionAccessToken { get; set; }
        public Func<DataBuildSessionTokenAuth, Task<Result<DeleteResponse>>> SubmitResumeSessionToken { get; set; }
        public Func<DataBuildSessionTokenAuth, Task<Result<DeleteResponse>>> SubmitPauseSessionToken { get; set; }
        public Func<string, Task<Result<bool>>> SubmitValidateSessionToken { get; set; }
    }

    public interface IBuilderAuthSessionApi<T> : IBuilderApi<T>
    {
        Task<Result<AuthorizationSessionWebResponse>> CreateSessionTokenAsync(string serviceId);
        Task<Result<List<SessionTokenAuth>>> GetSessionsAccessTokensAsync();
        Task<Result<DeleteResponse>> DeleteSessionAccessTokenAsync(string id);
        Task<Result<DeleteResponse>> PauseSessionTokenAsync(string id);
        Task<Result<DeleteResponse>> ResumeSessionTokenAsync(string id);
        Task<Result<bool>> ValidateSessionTokenAsync(string token);
    }

    public abstract class BuilderAuthSessionApi<T, E> : BuilderApi<T, E>, IBuilderAuthSessionApi<E>
    {
        public BuilderAuthSessionApi(IMapper mapper, T service) : base(mapper, service)
        {
        }

        public abstract Task<Result<List<SessionTokenAuth>>> GetSessionsAccessTokensAsync();
        public abstract Task<Result<DeleteResponse>> DeleteSessionAccessTokenAsync(string id);
        public abstract Task<Result<DeleteResponse>> PauseSessionTokenAsync(string id);
        public abstract Task<Result<AuthorizationSessionWebResponse>> CreateSessionTokenAsync(string serviceId);
        public abstract Task<Result<DeleteResponse>> ResumeSessionTokenAsync(string id);
        public abstract Task<Result<bool>> ValidateSessionTokenAsync(string token);
    }

    public class BuilderAuthSessionComponent<T> : IBuilderAuthSessionComponent<T>
    {
        public Func<T, Task<Result<AuthorizationSessionWebResponse>>> SubmitCreateSessionToken { get; set; }
        public Func<Task<Result<List<SessionTokenAuth>>>> GetSessionsAccessTokens { get; set; }
        public Func<DataBuildSessionTokenAuth, Task<Result<DeleteResponse>>> SubmitDeleteSessionAccessToken { get; set; }
        public Func<DataBuildSessionTokenAuth, Task<Result<DeleteResponse>>> SubmitResumeSessionToken { get; set; }
        public Func<DataBuildSessionTokenAuth, Task<Result<DeleteResponse>>> SubmitPauseSessionToken { get; set; }
        public Func<string, Task<Result<bool>>> SubmitValidateSessionToken { get; set; }
    }

    public class TemplateAuthSessionShare<T, E> : TemplateBase<T, E>
    {
        protected readonly NavigationManager navigation;
        protected readonly IDialogService dialogService;
        protected readonly ISnackbar Snackbar;
        protected IBuilderAuthSessionApi<E> builderApi;
        private readonly IBuilderAuthSessionComponent<E> builderComponents;
        public IBuilderAuthSessionComponent<E> BuilderComponents { get => builderComponents; }

        public TemplateAuthSessionShare(IMapper mapper, AuthService AuthService, T client, IBuilderAuthSessionComponent<E> builderComponents, NavigationManager navigation, IDialogService dialogService, ISnackbar snackbar) : base(mapper, AuthService, client)
        {
            builderComponents = new BuilderAuthSessionComponent<E>();
            this.navigation = navigation;
            this.dialogService = dialogService;
            this.Snackbar = snackbar;
            //this.builderApi = builderApi;
            this.builderComponents = builderComponents;
        }
    }

    public class BuilderAuthSessionApiClient : BuilderAuthSessionApi<AuthorizationSessionClientService, DataBuildSessionTokenAuth>, IBuilderAuthSessionApi<DataBuildSessionTokenAuth>
    {
        public BuilderAuthSessionApiClient(IMapper mapper, AuthorizationSessionClientService service) : base(mapper, service)
        {
        }

        public override async Task<Result<List<SessionTokenAuth>>> GetSessionsAccessTokensAsync()
        {
            var response = await Service.GetSessionsAccessTokensAsync();
            if (response.Succeeded)
            {
                var data = Mapper.Map<List<SessionTokenAuth>>(response.Data);
                return Result<List<SessionTokenAuth>>.Success(data);
            }
            else
            {
                var msg = response.Messages?.Count() > 0 ? response.Messages[0] : "Error";
                return Result<List<SessionTokenAuth>>.Fail(msg);
            }
        }

        public override async Task<Result<DeleteResponse>> DeleteSessionAccessTokenAsync(string id)
        {
            return await Service.DeleteSessionAccessTokenAsync(id);
        }

        public override async Task<Result<DeleteResponse>> PauseSessionTokenAsync(string id)
        {
            return await Service.PauseSessionTokenAsync(id);
        }

        public override async Task<Result<DeleteResponse>> ResumeSessionTokenAsync(string id)
        {
            return await Service.ResumeSessionTokenAsync(id);
        }

        public override async Task<Result<bool>> ValidateSessionTokenAsync(string token)
        {
            return await Service.ValidateSessionTokenAsync(token);
        }

        public override async Task<Result<AuthorizationSessionWebResponse>> CreateSessionTokenAsync(string serviceId)
        {
            return await Service.CreateAnyAuthorizationSessionAsync(new AuthorizationWebRequest { ServiceId = serviceId });
        }
    }

    [AutoSafeInvoke]
    public class TemplateAuthSession : TemplateAuthSessionShare<AuthorizationSessionClientService, DataBuildSessionTokenAuth>
    {
        private readonly ISafeInvoker safeInvoker;
        public TemplateAuthSession(IMapper mapper, AuthService AuthService, AuthorizationSessionClientService client, IBuilderAuthSessionComponent<DataBuildSessionTokenAuth> builderComponents, NavigationManager navigation, IDialogService dialogService, ISnackbar snackbar, ISafeInvoker safeInvoker) : base(mapper, AuthService, client, builderComponents, navigation, dialogService, snackbar)
        {
            this.BuilderComponents.GetSessionsAccessTokens = OnGetSessionsAccessTokensAsync;
            this.BuilderComponents.SubmitValidateSessionToken = OnValidateSessionTokenAsync;
            this.BuilderComponents.SubmitDeleteSessionAccessToken = OnDeleteSessionAccessTokenAsync;
            this.BuilderComponents.SubmitPauseSessionToken = OnPauseSessionTokenAsync;
            this.BuilderComponents.SubmitResumeSessionToken = OnResumeSessionTokenAsync;
            this.BuilderComponents.SubmitCreateSessionToken = OnCreateSessionTokenAsync;
            this.builderApi = new BuilderAuthSessionApiClient(mapper, client);
            this.safeInvoker = safeInvoker;
        }

        public List<string> Errors { get => _errors; }

        private async Task<Result<List<SessionTokenAuth>>> OnGetSessionsAccessTokensAsync()
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await builderApi.GetSessionsAccessTokensAsync();
            });
        }

        private async Task<Result<DeleteResponse>> OnDeleteSessionAccessTokenAsync(DataBuildSessionTokenAuth dataBuild)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await builderApi.DeleteSessionAccessTokenAsync(dataBuild.Id);
            });
        }

        private async Task<Result<DeleteResponse>> OnPauseSessionTokenAsync(DataBuildSessionTokenAuth dataBuild)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await builderApi.PauseSessionTokenAsync(dataBuild.Id);
            });
        }

        private async Task<Result<DeleteResponse>> OnResumeSessionTokenAsync(DataBuildSessionTokenAuth dataBuild)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await builderApi.ResumeSessionTokenAsync(dataBuild.Id);
            });
        }

        private async Task<Result<AuthorizationSessionWebResponse>> OnCreateSessionTokenAsync(DataBuildSessionTokenAuth dataBuild)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await builderApi.CreateSessionTokenAsync(dataBuild.ServiceId);
            });
        }

        private async Task<Result<bool>> OnValidateSessionTokenAsync(string token)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await builderApi.ValidateSessionTokenAsync(token);
            });
        }
    }
}