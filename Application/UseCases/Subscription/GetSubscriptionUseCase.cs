

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class GetSubscriptionUseCase : ITBaseUseCase {

    private readonly ISubscriptionRepository _repository;
    public GetSubscriptionUseCase(ISubscriptionRepository repository){
        _repository=repository;
    }

                
    public  async Task<Subscription> ExecuteAsync(CancellationToken cancellationToken)
    {
    
         return    await _repository.GetSubscriptionAsync(cancellationToken);
        
    }


}
