using Domain.Repository.Auth;
 using Shared.Wrapper;
using Domain.Entities.Auth.Request;
namespace Application.UseCase;
public class ConfirmationEmailUseCase
{
    private readonly IAuthRepository repository;
    public ConfirmationEmailUseCase(IAuthRepository repository)
    {

        this.repository = repository;
    }


    public async Task<Result<string>> ExecuteAsync(ConfirmationEmail request)
    {

        var data = await repository.confirmationEmailAsync(request);
        return data;




    }
}

