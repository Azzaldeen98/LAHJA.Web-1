

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class GetSubscriptionsUseCase : ITBaseUseCase {

    private readonly ISubscriptionRepository _repository;
    public GetSubscriptionsUseCase(ISubscriptionRepository repository){
        _repository=repository;
    }

                
    public  async Task<ICollection<Subscription>> ExecuteAsync(CancellationToken cancellationToken)
    {
    
         return    await _repository.GetSubscriptionsAsync(cancellationToken);
        
    }


}
