

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class CancelSubscriptionUseCase : ITBaseUseCase {

    private readonly ISubscriptionRepository _repository;
    public CancelSubscriptionUseCase(ISubscriptionRepository repository){
        _repository=repository;
    }

                
    public async  Task ExecuteAsync(CancellationToken cancellationToken)
    {
    
          await _repository.CancelAsync(cancellationToken);
        
    }


}
