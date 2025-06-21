using Domain.Repository.Auth;
using Domain.Entities;

namespace Application.UseCase.Auth
{
    public class ExternalLoginUseCase
    {
        private readonly IAuthRepository repository;
        public ExternalLoginUseCase(IAuthRepository repository)
        {

            this.repository = repository;
        }


        public async Task ExecuteAsync(ExternalLoginRequest request)
        {

             await repository.ExternalLoginAsync(request);
            



        }
    }
    }

