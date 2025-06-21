using Domain.Repository.Auth;
using Infrastructure.Models.Plans;
 using Shared.Wrapper;
using Domain.Entities.Auth.Response;
using Domain.Entities.Auth.Request;

namespace Application.UseCase.Auth
{
    public class LoginUseCase
    {
        private readonly IAuthRepository repository;
        public LoginUseCase(IAuthRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<LoginResponse>> ExecuteAsync(LoginRequest request)
        {

          return await repository.loginAsync(request);

        }
      
    }
    }

