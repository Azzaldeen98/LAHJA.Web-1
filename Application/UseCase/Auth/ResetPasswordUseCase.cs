using Domain.Repository.Auth;
 using Shared.Wrapper;
using Domain.Entities.Auth.Request;

public class ResetPasswordUseCase
{
    private readonly IAuthRepository repository;
    public ResetPasswordUseCase(IAuthRepository repository)
    {

        this.repository = repository;
    }


    public async Task<Result<ResetPasswordResponse>> ExecuteAsync(ResetPasswordRequest request)
    {

        return await repository.resetPasswordAsync(request);
      

  


    }
}

