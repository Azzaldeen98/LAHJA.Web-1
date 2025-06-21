

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class LogoutAuthUseCase : ITBaseUseCase {

    private readonly IAuthRepository _repository;
    public LogoutAuthUseCase(IAuthRepository repository){
        _repository=repository;
    }

                
    public async  Task ExecuteAsync(object body, CancellationToken cancellationToken)
    {
    
          await _repository.LogoutAsync(body, cancellationToken);
        
    }


}
