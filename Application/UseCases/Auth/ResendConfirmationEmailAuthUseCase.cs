

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class ResendConfirmationEmailAuthUseCase : ITBaseUseCase {

    private readonly IAuthRepository _repository;
    public ResendConfirmationEmailAuthUseCase(IAuthRepository repository){
        _repository=repository;
    }

                
    public  async Task<string> ExecuteAsync(ResendConfirmationEmail body, CancellationToken cancellationToken)
    {
    
         return    await _repository.ResendConfirmationEmailAsync(body, cancellationToken);
        
    }


}
