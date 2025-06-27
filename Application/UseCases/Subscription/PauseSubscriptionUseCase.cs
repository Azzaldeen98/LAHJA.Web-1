

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class PauseSubscriptionUseCase : ITBaseUseCase {

    private readonly ISubscriptionRepository _repository;
    public PauseSubscriptionUseCase(ISubscriptionRepository repository){
        _repository=repository;
    }

                
    public async  Task ExecuteAsync(Subscription model, CancellationToken cancellationToken)
    {
    
          await _repository.PauseAsync(model, cancellationToken);
        
    }


}
