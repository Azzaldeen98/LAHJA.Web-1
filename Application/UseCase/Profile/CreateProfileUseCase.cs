using Domain.Entities.Profile;
using Domain.Repository.Profile;
 using Shared.Wrapper;

namespace Application.UseCase.Plans
{
    public class CreateProfileUseCase
    {
        private readonly IProfileRepository repository;

        public CreateProfileUseCase(IProfileRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<ProfileResponse>> ExecuteAsync(ProfileRequest profileRequest)
        {
        
            return await repository.CreateProfileAsync(profileRequest);
        }
    }



}
