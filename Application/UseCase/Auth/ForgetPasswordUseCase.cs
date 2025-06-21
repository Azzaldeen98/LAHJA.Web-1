using Domain.Repository.Auth;
 using Shared.Wrapper;
using Domain.Entities.Auth.Request;

namespace Application.UseCase.Auth
{
    public class ForgetPasswordUseCase
    {
        private readonly IAuthRepository repository;
        public ForgetPasswordUseCase(IAuthRepository repository)
        {

            this.repository = repository;
        }



        public async Task<Result<ForgetPasswordResponse>> ExecuteAsync(ForgetPasswordRequest model)
        {

            var data = await repository.forgetPasswordAsync(model);
            return  data;

        }
    }
}
