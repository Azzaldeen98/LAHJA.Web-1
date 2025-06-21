using Domain.Repository.Auth;
 using Shared.Wrapper;

namespace Application.UseCase;

public class LogoutUseCase
{
    private readonly IAuthRepository repository;
    public LogoutUseCase(IAuthRepository repository)
    {

        this.repository = repository;
    }


    public async Task<Result<string>> ExecuteAsync()
    {

        return await repository.logoutAsync();
     

    }
}


