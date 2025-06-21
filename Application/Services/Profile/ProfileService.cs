using Application.UseCase.AuthorizationSession;
using Application.UseCase.Plans;
using Application.UseCase.Space;
using Domain.Entities.AuthorizationSession;
using Domain.Entities.Profile;
using Domain.Entities.Profile.Request;
using Domain.Entities.Profile.Response;
using Domain.Entities.Space.Request;
using Domain.Repository.Profile;
using Domain.ShareData.Base;
 using Shared.Wrapper;

namespace Application.Service.Profile
{
    public class ProfileService
    {
        private readonly GetProfileUseCase getProfileUseCase;
        private readonly CreateProfileUseCase _createProfileUseCase;
        private readonly UpdateProfileUseCase _updateProfileUseCase;
        private readonly DeleteProfileUseCase _deleteProfileUseCase;
        private readonly GetProfileUserUseCase _getProfileUserUseCase;
        private readonly CreateSpaceAuthorizationUseCase createSpaceAuthorizationUseCase;
        private readonly UpdateProfileUserUseCase  updateProfileUserUseCase;

   
        private readonly IProfileRepository profileRepository;


        public ProfileService(GetProfileUseCase getProfileUseCase,
                            CreateProfileUseCase createProfileUseCase,
                            UpdateProfileUseCase updateProfileUseCase,
                            DeleteProfileUseCase deleteProfileUseCase,
                            GetProfileUserUseCase getProfileUserUseCase,
                            CreateSpaceAuthorizationUseCase createSpaceAuthorizationUseCase,
                            IProfileRepository profileRepository,
                            UpdateProfileUserUseCase updateProfileUserUseCase)
        {
            this.getProfileUseCase = getProfileUseCase;
            _createProfileUseCase = createProfileUseCase;
            _updateProfileUseCase = updateProfileUseCase;
            _deleteProfileUseCase = deleteProfileUseCase;
            _getProfileUserUseCase = getProfileUserUseCase;
            this.createSpaceAuthorizationUseCase = createSpaceAuthorizationUseCase;
            this.profileRepository = profileRepository;
            this.updateProfileUserUseCase = updateProfileUserUseCase;
        }

        public async Task<Result<AuthorizationSessionWebResponse>> CreateSpaceAsync(SpaceRequest request)
        {
            return await createSpaceAuthorizationUseCase.ExecuteAsync(request);
        }   
        
        public async Task<Result<ProfileUserResponse>> UpdateProfileUserAsync(ProfileUserRequest request)
        {
            return await updateProfileUserUseCase.ExecuteAsync(request);
        }

        public async Task<Result<ProfileResponse>> getProfileAsync()
        {
            return await getProfileUseCase.ExecuteAsync();

        }   
        
       
        public async Task<Result<ProfileUserResponse>> GetProfileUserAsync()
        {
            return await _getProfileUserUseCase.ExecuteAsync();

        }

        public async Task<Result<ProfileResponse>> CreateAsync(ProfileRequest request)
        {
            return await _createProfileUseCase.ExecuteAsync(request);

        }
        public async Task<Result<ProfileResponse>> UpdateAsync(ProfileRequest request)
        {
            return await _updateProfileUseCase.ExecuteAsync(request);

        }

        public async Task<Result<bool>> DeleteAsync(string profileId)
        {
            return await _deleteProfileUseCase.ExecuteAsync(profileId);

        }

        public async Task<ICollection<ProfileSubscriptionResponse>> SubscriptionsAsync()
        {

            return await profileRepository.SubscriptionsAsync();
        }



        public async Task<ICollection<ProfileSpaceResponse>> SpacesSubscriptionAsync(string subscriptionId)
        {
            return await profileRepository.SpacesSubscriptionAsync(subscriptionId);
        }

        public async Task<ICollection<ProfileServiceResponse>> ServicesModelAiAsync(string modelAiId)
        {

            return await profileRepository.ServicesModelAiAsync(modelAiId);

        }


        public async Task<ICollection<ProfileModelAiResponse>> ModelAisAsync()
        {


            return await profileRepository.ModelAisAsync();

        }


        public async Task<ICollection<ProfileServiceResponse>> ServicesAsync()
        {

            return await profileRepository.ServicesAsync();

        }

    } 
}
