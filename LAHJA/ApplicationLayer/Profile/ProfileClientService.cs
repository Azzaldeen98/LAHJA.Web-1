using Application.Service.AuthorizationSession;
using Application.Service.Profile;
using Application.UseCase.AuthorizationSession;
using Application.UseCase.Plans;
using AutoMapper;
using Domain.Entities.AuthorizationSession;
using Domain.Entities.Profile;
using Domain.Entities.Profile.Request;
using Domain.Entities.Profile.Response;
using Domain.Entities.Space.Request;
using Domain.ShareData.Base;
 using Shared.Wrapper;

using LAHJA.Helpers.Services;
using Shared.Helpers;

namespace LAHJA.ApplicationLayer.Profile
{
    public class ProfileClientService
    {
        private readonly ProfileService profileService;
        private readonly ITokenService tokenService;
        private readonly AuthorizationSessionService    authorizationSessionService;
        private readonly IMapper _mapper;

        public ProfileClientService(ProfileService profileService,
            IMapper mapper,
            ITokenService tokenService,
            AuthorizationSessionService authorizationSessionService)
        {

            this.profileService = profileService;
            _mapper = mapper;
            this.tokenService = tokenService;
            this.authorizationSessionService = authorizationSessionService;
        }

        public async Task<Result<ProfileUserResponse>> UpdateProfileUserAsync(ProfileUserRequest request)
        {
            return await profileService.UpdateProfileUserAsync(request);
        }
        public async Task<Result<AuthorizationSessionWebResponse>> CreateAuthorizationSessionAsync(AuthorizationWebRequest request)
        {
            return await authorizationSessionService.CreateAuthorizationSessionAsync(request);

        }

        public async Task<Result<AuthorizationSessionWebResponse>> CreateSpaceAsync(SpaceRequest request)
        {
            return await profileService.CreateSpaceAsync(request);
        }
        public async Task<Result<ProfileUserResponse>> GetProfileUserAsync()
        {

            return await profileService.GetProfileUserAsync();
        }



        public async Task<Result<List<SessionTokenAuthResponse>>> GetSessionsAccessTokensAsync()
        {
            return await authorizationSessionService.GetSessionsAccessTokensAsync();

        }
        public async Task<Result<DeleteResponse>> PauseSessionTokenAsync(string id)
        {
            return await authorizationSessionService.PauseSessionTokenAsync(id);

        }

        public async Task<Result<DeleteResponse>> ResumeSessionTokenAsync(string id)
        {
            return await authorizationSessionService.ResumeSessionTokenAsync(id);

        }
        public async Task<Result<DeleteResponse>> DeleteSessionAccessTokenAsync(string id)
        {
            return await authorizationSessionService.DeleteSessionAccessTokenAsync(id);

        }

        public async Task<Result<bool>> ValidateSessionTokenAsync(string token)
        {
            return await authorizationSessionService.ValidateSessionTokenAsync(token);

        }


        public async Task<ICollection<ProfileSubscriptionResponse>> SubscriptionsAsync()
        {

            return await profileService.SubscriptionsAsync();
        }



        public async Task<ICollection<ProfileSpaceResponse>> SpacesSubscriptionAsync(string subscriptionId)
        {
            return await profileService.SpacesSubscriptionAsync(subscriptionId);
        }

        public async Task<ICollection<ProfileServiceResponse>> ServicesModelAiAsync(string modelAiId)
        {

            return await profileService.ServicesModelAiAsync(modelAiId);

        }


        public async Task<ICollection<ProfileModelAiResponse>> ModelAisAsync()
        {


            return await profileService.ModelAisAsync();

        }


        public  async Task<ICollection<ProfileServiceResponse>> ServicesAsync()
        {

            return await profileService.ServicesAsync();

        }




            //public async Task<Result<ProfileResponse>> GetProfileAsync()
            //{

        //    return await profileService.getProfileAsync();

        //    //if ( result.Succeeded)
        //    //{
        //    //    var res = result.Data;
        //    //    var data = _mapper.Map<List<PlansFeture>>(res);
        //    //    int i = 0;
        //    //foreach (var item in data)
        //    //{
        //    //    item.Services = _mapper.Map<List<ProfileResponse>>(res[i].SubscriptionFeatures);
        //    //    item.numberOfServices = _mapper.Map<List<NumberOfService>>(res[i++].TechnicalFeatures);
        //    //}
        //    //    return Result<List<PlansFeture>>.Success(data);
        //    //}
        //    //else
        //    //{
        //    //    return Result<List<PlansFeture>>.Fail();
        //    //}

        //}

        //public async Task<Result<ProfileResponse>> CreateAsync(ProfileRequest request)
        //{
        //    return await profileService.CreateAsync(request);

        //}
        //public async Task<Result<ProfileResponse>> UpdateAsync(ProfileRequest request)
        //{
        //    return await profileService.UpdateAsync(request);

        //}

        //public async Task<Result<bool>> DeleteAsync(string profileId)
        //{
        //    return await profileService.DeleteAsync(profileId);

        //}

        }
}
