using Domain.Entities.Auth.Request;
using Domain.Repository.Auth;
using Domain.ShareData.Base;
 using Shared.Wrapper;

namespace Application.UseCase;

public class RefreshTokinUseCase
{
    private readonly IAuthRepository repository;
    public RefreshTokinUseCase(IAuthRepository repository)
    {

        this.repository = repository;
    }


    public async Task<Result<AccessTokenResponse>> ExecuteAsync(RefreshRequest request)
    {

            return   await repository.RefreshTokenAsync(request);
   


    }
}



