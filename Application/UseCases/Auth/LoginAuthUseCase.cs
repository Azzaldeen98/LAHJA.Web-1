

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class LoginAuthUseCase : ITBaseUseCase {

    private readonly IAuthRepository _repository;
    public LoginAuthUseCase(IAuthRepository repository){
        _repository=repository;
    }

                
    public  async Task<AccessToken> ExecuteAsync(Login body, CancellationToken cancellationToken)
    {
    
         return    await _repository.LoginAsync(body, cancellationToken);
        
    }


}
