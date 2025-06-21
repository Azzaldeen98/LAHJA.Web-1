using Domain.Entities.Profile;
using Domain.Entities.Profile.Request;
using Domain.Entities.Profile.Response;
using Domain.Entities.Request.Response;
 using Shared.Wrapper;

namespace Domain.Repository.Profile;

public interface IProfileRepository
{
    //Task<Result<bool>> HasActiveSubscriptionAsync();
    public  Task<Result<ProfileUserResponse>> UpdateProfileUserAsync(ProfileUserRequest request);
    public Task<Result<ProfileUserResponse>> GetProfileUserAsync();
    public Task<Result<ProfileResponse>> getProfileAsync();
    public Task<Result<ProfileResponse>> UpdateProfileAsync(ProfileRequest profileRequest);
    public Task<Result<bool>> DeleteProfileAsync(string profileId);
    public Task<Result<ProfileResponse>> CreateProfileAsync(ProfileRequest profileRequest);
    public  Task<ICollection<ProfileSubscriptionResponse>> SubscriptionsAsync();
    public  Task<ICollection<ProfileModelAiResponse>> ModelAisAsync();
    public  Task<ICollection<ProfileServiceResponse>> ServicesAsync();
    public  Task<ICollection<ProfileServiceResponse>> ServicesModelAiAsync(string modelAiId);
    public Task<ICollection<ProfileSpaceResponse>> SpacesSubscriptionAsync(string subscriptionId);
    public  Task<ProfileSpaceResponse> SpaceSubscriptionAsync(string subscriptionId, string spaceId);
    public  Task<List<RequestResponse>> RequestsServiceAsync(string serviceId);
}
