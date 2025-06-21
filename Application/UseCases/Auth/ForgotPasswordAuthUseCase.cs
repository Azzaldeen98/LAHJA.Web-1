

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class ForgotPasswordAuthUseCase : ITBaseUseCase {

    private readonly IAuthRepository _repository;
    public ForgotPasswordAuthUseCase(IAuthRepository repository){
        _repository=repository;
    }

                
    public async  Task ExecuteAsync(ForgetPassword body, CancellationToken cancellationToken)
    {
    
          await _repository.ForgotPasswordAsync(body, cancellationToken);
        
    }


}
