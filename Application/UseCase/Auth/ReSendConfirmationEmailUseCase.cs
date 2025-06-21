using Domain.Repository.Auth;
 using Shared.Wrapper;
using Domain.Entities.Auth.Request;

namespace Application.UseCase;
public class ReSendConfirmationEmailUseCase
{
    private readonly IAuthRepository repository;
    public ReSendConfirmationEmailUseCase(IAuthRepository repository)
    {

        this.repository = repository;
    }


    public async Task<Result<string>> ExecuteAsync(ResendConfirmationEmail request)
    {

        return await repository.reSendConfirmationEmailAsync(request);
     



    }
}


