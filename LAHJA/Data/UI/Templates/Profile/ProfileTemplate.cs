using AutoMapper;
using Domain.Entities.AuthorizationSession;
using Domain.Entities.Profile;
using Domain.Entities.Profile.Request;
using Domain.Entities.Profile.Response;
using Domain.Entities.Space.Request;
using Domain.ShareData.Base;
using Shared.Wrapper;
using LAHJA.ApplicationLayer.Profile;
using LAHJA.Data.UI.Components.ProFileModel;
using LAHJA.Data.UI.Models;
using LAHJA.Data.UI.Models.Profile;
using LAHJA.Data.UI.Models.SessionTokenAuth;
using LAHJA.Data.UI.Models.Space;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Client.Shared.Execution;
using AutoGenerator.Attributes;

namespace LAHJA.Data.UI.Templates.Profile
{
    public interface IBuilderProfileComponent<T> : IBuilderComponents<T>
    {
        //public Func<T, Task> SubmitSearch { get; set; }
        public Func<T, Task> SubmitCreate { get; set; }
        public Func<T, Task> SubmitDelete { get; set; }
        public Func<T, Task> SubmitUpdate { get; set; }
        public Func<DataBuildSpace, Task<Result<AuthorizationSessionWebResponse>>> SubmitCreateSpace { get; set; }
        public Func<DataBuildUserProfile, Task<Result<DataBuildUserProfile>>> SubmitUpdateProfileUser { get; set; }
        public Func<DataBuildServiceInfo, Task<Result<AuthorizationSessionWebResponse>>> SubmitCreateSessionToken { get; set; }
        public Func<Task<Result<List<SessionTokenAuth>>>> GetSessionsAccessTokens { get; set; }
        public Func<DataBuildSessionTokenAuth, Task<Result<DeleteResponse>>> SubmitDeleteSessionAccessToken { get; set; }
        public Func<DataBuildSessionTokenAuth, Task<Result<DeleteResponse>>> SubmitResumeSessionToken { get; set; }
        public Func<DataBuildSessionTokenAuth, Task<Result<DeleteResponse>>> SubmitPauseSessionToken { get; set; }
        public Func<string, Task<Result<bool>>> SubmitValidateSessionToken { get; set; }
    }

    public interface IBuilderProfileApi<T> : IBuilderApi<T>
    {
        Task<Result<ProfileUserResponse>> UpdateProfileUserAsync(DataBuildUserProfile data);
        Task<Result<ProfileResponse>> GetProfileAsync();
        Task<Result<ProfileUserResponse>> GetProfileUserAsync();
        Task<Result<ProfileResponse>> CreateAsync(T data);
        Task<Result<DeleteResponse>> DeleteAsync(T data);
        Task<Result<ProfileResponse>> UpdateAsync(T data);
        Task<Result<AuthorizationSessionWebResponse>> CreateSpaceAsync(SpaceRequest request);
        Task<ICollection<ProfileSubscriptionResponse>> SubscriptionsAsync();
        Task<ICollection<ProfileModelAiResponse>> ModelAisAsync();
        Task<ICollection<ProfileServiceResponse>> ServicesAsync();
        Task<ICollection<ProfileServiceResponse>> ServicesModelAiAsync(string modelAiId);
        Task<ICollection<ProfileSpaceResponse>> SpacesSubscriptionAsync(string subscriptionId);
        Task<ProfileSpaceResponse> SpaceSubscriptionAsync(string subscriptionId, string spaceId);
        Task<Result<AuthorizationSessionWebResponse>> CreateSessionTokenAsync(string serviceId);
        Task<Result<List<SessionTokenAuth>>> GetSessionsAccessTokensAsync();
        Task<Result<DeleteResponse>> DeleteSessionAccessTokenAsync(string id);
        Task<Result<DeleteResponse>> PauseSessionTokenAsync(string id);
        Task<Result<DeleteResponse>> ResumeSessionTokenAsync(string id);
        Task<Result<bool>> ValidateSessionTokenAsync(string token);
    }

    public abstract class BuilderProfileApi<T, E> : BuilderApi<T, E>, IBuilderProfileApi<E>
    {
        public BuilderProfileApi(IMapper mapper, T service) : base(mapper, service)
        {
        }

        public abstract Task<Result<ProfileResponse>> CreateAsync(E data);
        public abstract Task<Result<AuthorizationSessionWebResponse>> CreateSpaceAsync(SpaceRequest data);
        public abstract Task<Result<ProfileUserResponse>> UpdateProfileUserAsync(DataBuildUserProfile data);
        public abstract Task<Result<List<SessionTokenAuth>>> GetSessionsAccessTokensAsync();
        public abstract Task<Result<DeleteResponse>> DeleteSessionAccessTokenAsync(string id);
        public abstract Task<Result<DeleteResponse>> PauseSessionTokenAsync(string id);
        public abstract Task<Result<AuthorizationSessionWebResponse>> CreateSessionTokenAsync(string serviceId);
        public abstract Task<Result<DeleteResponse>> ResumeSessionTokenAsync(string id);
        public abstract Task<Result<bool>> ValidateSessionTokenAsync(string token);
        public abstract Task<Result<DeleteResponse>> DeleteAsync(E dataId);
        public abstract Task<Result<ProfileUserResponse>> GetProfileUserAsync();
        public abstract Task<Result<ProfileResponse>> GetProfileAsync();
        public abstract Task<ICollection<ProfileModelAiResponse>> ModelAisAsync();
        public abstract Task<ICollection<ProfileServiceResponse>> ServicesAsync();
        public abstract Task<ICollection<ProfileServiceResponse>> ServicesModelAiAsync(string modelAiId);
        public abstract Task<ICollection<ProfileSpaceResponse>> SpacesSubscriptionAsync(string subscriptionId);
        public Task<ProfileSpaceResponse> SpaceSubscriptionAsync(string subscriptionId, string spaceId)
        {
            throw new NotImplementedException();
        }

        //public abstract Task<ProfileSpaceResponse> SpaceSubscriptionAsync(string subscriptionId, string spaceId);
        public abstract Task<ICollection<ProfileSubscriptionResponse>> SubscriptionsAsync();
        public abstract Task<Result<ProfileResponse>> UpdateAsync(E data);
    }

    public class BuilderProfileComponent<T> : IBuilderProfileComponent<T>
    {
        public Func<T, Task> SubmitSearch { get; set; }
        public Func<T, Task> SubmitCreate { get; set; }
        public Func<DataBuildSpace, Task<Result<AuthorizationSessionWebResponse>>> SubmitCreateSpace { get; set; }
        public Func<T, Task> SubmitDelete { get; set; }
        public Func<DataBuildUserProfile, Task<Result<DataBuildUserProfile>>> SubmitUpdateProfileUser { get; set; }
        public Func<DataBuildServiceInfo, Task<Result<AuthorizationSessionWebResponse>>> SubmitCreateSessionToken { get; set; }
        public Func<Task<Result<List<SessionTokenAuth>>>> GetSessionsAccessTokens { get; set; }
        public Func<DataBuildSessionTokenAuth, Task<Result<DeleteResponse>>> SubmitDeleteSessionAccessToken { get; set; }
        public Func<DataBuildSessionTokenAuth, Task<Result<DeleteResponse>>> SubmitResumeSessionToken { get; set; }
        public Func<DataBuildSessionTokenAuth, Task<Result<DeleteResponse>>> SubmitPauseSessionToken { get; set; }
        //public Func<DataBuildSessionTokenAuth, Task<Result<DeleteResponse>>> SubscriptionsUserAsync { get; set; }
        public Func<string, Task<Result<bool>>> SubmitValidateSessionToken { get; set; }
        public Func<T, Task> SubmitUpdate { get; set; }
    }

    public class TemplateProfileShare<T, E> : TemplateBase<T, E>
    {
        protected readonly NavigationManager navigation;
        protected readonly IDialogService dialogService;
        protected readonly ISnackbar Snackbar;
        protected IBuilderProfileApi<E> builderApi;
        private readonly IBuilderProfileComponent<E> builderComponents;
        public IBuilderProfileComponent<E> BuilderComponents { get => builderComponents; }

        public TemplateProfileShare(IMapper mapper, AuthService AuthService, T client, IBuilderProfileComponent<E> builderComponents, NavigationManager navigation, IDialogService dialogService, ISnackbar snackbar) : base(mapper, AuthService, client)
        {
            builderComponents = new BuilderProfileComponent<E>();
            this.navigation = navigation;
            this.dialogService = dialogService;
            this.Snackbar = snackbar;
            //this.builderApi = builderApi;
            this.builderComponents = builderComponents;
        }
    }

    public class BuilderProfileApiClient : BuilderProfileApi<ProfileClientService, DataBuildUserProfile>, IBuilderProfileApi<DataBuildUserProfile>
    {
        public BuilderProfileApiClient(IMapper mapper, ProfileClientService service) : base(mapper, service)
        {
        }

        public override async Task<Result<AuthorizationSessionWebResponse>> CreateSpaceAsync(SpaceRequest data)
        {
            return await Service.CreateSpaceAsync(data);
        }

        public override async Task<Result<ProfileUserResponse>> UpdateProfileUserAsync(DataBuildUserProfile data)
        {
            var model = Mapper.Map<ProfileUserRequest>(data);
            return await Service.UpdateProfileUserAsync(model);
        }

        public override async Task<ICollection<ProfileSpaceResponse>> SpacesSubscriptionAsync(string subscriptionId)
        {
            return await Service.SpacesSubscriptionAsync(subscriptionId);
        }

        public override async Task<ICollection<ProfileServiceResponse>> ServicesModelAiAsync(string modelAiId)
        {
            return await Service.ServicesModelAiAsync(modelAiId);
        }

        public override async Task<ICollection<ProfileModelAiResponse>> ModelAisAsync()
        {
            return await Service.ModelAisAsync();
        }

        public async override Task<Result<ProfileUserResponse>> GetProfileUserAsync()
        {
            return await Service.GetProfileUserAsync();
        }

        public override async Task<ICollection<ProfileServiceResponse>> ServicesAsync()
        {
            return await Service.ServicesAsync();
        }

        public override async Task<ICollection<ProfileSubscriptionResponse>> SubscriptionsAsync()
        {
            var lg = Language.Code;
            return await Service.SubscriptionsAsync();
        }

        public override Task<Result<ProfileResponse>> UpdateAsync(DataBuildUserProfile data)
        {
            throw new NotImplementedException();
        }

        public override Task<Result<ProfileResponse>> GetProfileAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<Result<DeleteResponse>> DeleteAsync(DataBuildUserProfile dataId)
        {
            throw new NotImplementedException();
        }

        public override Task<Result<ProfileResponse>> CreateAsync(DataBuildUserProfile data)
        {
            throw new NotImplementedException();
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
            return await Service.CreateAuthorizationSessionAsync(new AuthorizationWebRequest { ServiceId = serviceId });
        }
    }

    [AutoSafeInvoke]
    public class TemplateProfile : TemplateProfileShare<ProfileClientService, DataBuildUserProfile>
    {
        private readonly ISafeInvoker safeInvoker;
        private List<ProfileResponse> _Profiles = new List<ProfileResponse>();
        public TemplateProfile(IMapper mapper, AuthService AuthService, ProfileClientService client, IBuilderProfileComponent<DataBuildUserProfile> builderComponents, NavigationManager navigation, IDialogService dialogService, ISnackbar snackbar, ISafeInvoker safeInvoker) : base(mapper, AuthService, client, builderComponents, navigation, dialogService, snackbar)
        {
            this.BuilderComponents.SubmitCreate = OnSubmitCreateProfile;
            this.BuilderComponents.SubmitUpdate = OnSubmitUpdateProfile;
            this.BuilderComponents.SubmitDelete = OnSubmitDeleteProfile;
            this.BuilderComponents.SubmitCreateSpace = OnSubmitCreateSpaceAsync;
            this.BuilderComponents.GetSessionsAccessTokens = OnGetSessionsAccessTokensAsync;
            this.BuilderComponents.SubmitValidateSessionToken = OnValidateSessionTokenAsync;
            this.BuilderComponents.SubmitDeleteSessionAccessToken = OnDeleteSessionAccessTokenAsync;
            this.BuilderComponents.SubmitPauseSessionToken = OnPauseSessionTokenAsync;
            this.BuilderComponents.SubmitResumeSessionToken = OnResumeSessionTokenAsync;
            this.BuilderComponents.SubmitCreateSessionToken = OnCreateSessionTokenAsync;
            this.BuilderComponents.SubmitUpdateProfileUser = OnUpdateProfileUserAsync;
            this.builderApi = new BuilderProfileApiClient(mapper, client);
            this.safeInvoker = safeInvoker;
        }

        public List<ProfileResponse> Profiles { get => _Profiles; }
        public List<string> Errors { get => _errors; }

        public async Task<Result<DataBuildUserProfile>> OnUpdateProfileUserAsync(DataBuildUserProfile data)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                var response = await builderApi.UpdateProfileUserAsync(data);
                if (response.Succeeded)
                {
                    var rev = mapper.Map<DataBuildUserProfile>(data);
                    return Result<DataBuildUserProfile>.Success(rev);
                }
                else
                {
                    return Result<DataBuildUserProfile>.Fail(response.Messages);
                }
            });
        }

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

        private async Task<Result<AuthorizationSessionWebResponse>> OnCreateSessionTokenAsync(DataBuildServiceInfo dataBuild)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await builderApi.CreateSessionTokenAsync(dataBuild.Id);
            });
        }

        private async Task<Result<bool>> OnValidateSessionTokenAsync(string token)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await builderApi.ValidateSessionTokenAsync(token);
            });
        }

        public async Task<Result<List<DataBuildSpace>>> GetDataBuildSpaces(string subscriptionId)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                var data = await builderApi.SpacesSubscriptionAsync(subscriptionId);
                var rev = mapper.Map<List<DataBuildSpace>>(data);
                return Result<List<DataBuildSpace>>.Success(rev);
            });
        }

        public async Task<Result<List<DataBuildUserSubscriptionInfo>>> GetDataBuildSubscriptions(FilterResponseData filter)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                var data = await builderApi.SubscriptionsAsync();
                var rev = mapper.Map<List<DataBuildUserSubscriptionInfo>>(data);
                return Result<List<DataBuildUserSubscriptionInfo>>.Success(rev);
            });
        }

        public async Task<List<DataBuildUserModelAi>> GetDataBuildModelAis()
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                var data = await builderApi.ModelAisAsync();
                var rev = mapper.Map<List<DataBuildUserModelAi>>(data);
                return rev;
            });
        }

        private async Task<Result<DeleteResponse>> OnSubmitDeleteProfile(DataBuildUserProfile DataBuildUserProfile)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                var response = await builderApi.DeleteAsync(DataBuildUserProfile);
                return response;
            });
        }

        private async Task<Result<DataBuildUserProfile>> OnSubmitCreateProfile(DataBuildUserProfile DataBuildUserProfile)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                var response = await builderApi.CreateAsync(DataBuildUserProfile);
                if (response.Succeeded)
                {
                    var tm = mapper.Map<DataBuildUserProfile>(response.Data);
                    return Result<DataBuildUserProfile>.Success(tm);
                }
                else
                {
                    return Result<DataBuildUserProfile>.Fail(response.Messages);
                }
            });
        }

        private async Task<Result<AuthorizationSessionWebResponse>> OnSubmitCreateSpaceAsync(DataBuildSpace data)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                var response = await builderApi.CreateSpaceAsync(new SpaceRequest { ServiceId = data.ServiceId });
                if (response.Succeeded)
                {
                    return Result<AuthorizationSessionWebResponse>.Success(response.Data);
                }
                else
                {
                    return Result<AuthorizationSessionWebResponse>.Fail(response.Messages);
                }
            });
        }

        private async Task<Result<DataBuildUserProfile>> OnSubmitUpdateProfile(DataBuildUserProfile DataBuildUserProfile)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                var response = await builderApi.UpdateAsync(DataBuildUserProfile);
                if (response.Succeeded)
                {
                    var tm = mapper.Map<DataBuildUserProfile>(response.Data);
                    return Result<DataBuildUserProfile>.Success(tm);
                }
                else
                {
                    return Result<DataBuildUserProfile>.Fail(response.Messages);
                }
            });
        }

        public async Task<Result<DataBuildUserProfile>> GetProfileAsync()
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                var response = await builderApi.GetProfileUserAsync();
                if (response.Succeeded)
                {
                    var data = mapper.Map<DataBuildUserProfile>(response.Data);
                    return Result<DataBuildUserProfile>.Success(data);
                }
                else
                {
                    return Result<DataBuildUserProfile>.Fail(response.Messages);
                }
            });
        }

        public async Task<Result<DataBuildUserProfile>> GetProfileUserAsync()
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                var response = await builderApi.GetProfileUserAsync();
                if (response.Succeeded)
                {
                    var data = mapper.Map<DataBuildUserProfile>(response.Data);
                    return Result<DataBuildUserProfile>.Success(data);
                }
                else
                {
                    return Result<DataBuildUserProfile>.Fail(response.Messages);
                }
            });
        }
    }
}