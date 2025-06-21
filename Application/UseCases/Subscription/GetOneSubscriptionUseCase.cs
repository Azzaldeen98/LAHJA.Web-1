

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class GetOneSubscriptionUseCase : ITBaseUseCase {

    private readonly ISubscriptionRepository _repository;
    public GetOneSubscriptionUseCase(ISubscriptionRepository repository){
        _repository=repository;
    }

                
    public  async Task<Subscription> ExecuteAsync(string id, CancellationToken cancellationToken)
    {
    
         return    await _repository.GetOneAsync(id, cancellationToken);
        
    }


}
