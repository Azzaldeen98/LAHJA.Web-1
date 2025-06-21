

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class RegisterAuthUseCase : ITBaseUseCase {

    private readonly IAuthRepository _repository;
    public RegisterAuthUseCase(IAuthRepository repository){
        _repository=repository;
    }

                
    public async  Task ExecuteAsync(Register body, CancellationToken cancellationToken)
    {
    
          await _repository.RegisterAsync(body, cancellationToken);
        
    }


}
