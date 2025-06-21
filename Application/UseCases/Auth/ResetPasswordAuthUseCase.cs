

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class ResetPasswordAuthUseCase : ITBaseUseCase {

    private readonly IAuthRepository _repository;
    public ResetPasswordAuthUseCase(IAuthRepository repository){
        _repository=repository;
    }

                
    public async  Task ExecuteAsync(ResetPassword body, CancellationToken cancellationToken)
    {
    
          await _repository.ResetPasswordAsync(body, cancellationToken);
        
    }


}
