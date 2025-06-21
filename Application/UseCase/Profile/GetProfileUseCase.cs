using Domain.Entities.Plans;
using Domain.Entities.Profile;
using Domain.Repository.Plans;
using Domain.Repository.Profile;
 using Shared.Wrapper;

namespace Application.UseCase.Plans
{
    public class GetProfileUseCase
    {
        private readonly IProfileRepository repository;
        public GetProfileUseCase(IProfileRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<ProfileResponse>> ExecuteAsync()
        {

           return await repository.getProfileAsync();

  

        }
    } 



}
