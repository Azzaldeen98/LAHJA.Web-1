using Domain.Entities.Profile.Response;
using Domain.Repository.Profile;
 using Shared.Wrapper;

namespace Application.UseCase.Plans
{
    public class GetProfileUserUseCase
    {
        private readonly IProfileRepository repository;
        public GetProfileUserUseCase(IProfileRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<ProfileUserResponse>> ExecuteAsync()
        {

           return await repository.GetProfileUserAsync();

  

        }
    }



}
