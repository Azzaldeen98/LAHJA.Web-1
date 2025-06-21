using Domain.Repository.Profile;
 using Shared.Wrapper;

namespace Application.UseCase.Plans
{
    public class DeleteProfileUseCase
    {
        private readonly IProfileRepository repository;

        public DeleteProfileUseCase(IProfileRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<bool>> ExecuteAsync(string profileId)
        {

            return await repository.DeleteProfileAsync(profileId);
        }
    }



}
