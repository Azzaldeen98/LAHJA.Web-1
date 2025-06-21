using Domain.Entities.Profile.Request;
using Domain.Entities.Profile.Response;
using Domain.Repository.Profile;
 using Shared.Wrapper;

namespace Application.UseCase.Plans
{
    public class UpdateProfileUserUseCase
    {
        private readonly IProfileRepository repository;
        public UpdateProfileUserUseCase(IProfileRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<ProfileUserResponse>> ExecuteAsync(ProfileUserRequest request)
        {

           return await repository.UpdateProfileUserAsync(request);

  

        }
    } 



}
