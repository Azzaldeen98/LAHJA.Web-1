

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class ConfirmationEmailAuthUseCase : ITBaseUseCase {

    private readonly IAuthRepository _repository;
    public ConfirmationEmailAuthUseCase(IAuthRepository repository){
        _repository=repository;
    }

                
    public async  Task ExecuteAsync(ConfirmEmail body, CancellationToken cancellationToken)
    {
    
          await _repository.ConfirmationEmailAsync(body, cancellationToken);
        
    }


}
