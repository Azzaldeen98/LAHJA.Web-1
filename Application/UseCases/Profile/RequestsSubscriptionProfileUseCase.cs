

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class RequestsSubscriptionProfileUseCase : ITBaseUseCase {

    private readonly IProfileRepository _repository;
    public RequestsSubscriptionProfileUseCase(IProfileRepository repository){
        _repository=repository;
    }

                
    public  async Task<PaginatedResult<Request>> ExecuteAsync(string subscriptionId, CancellationToken cancellationToken)
    {
    
         return    await _repository.RequestsSubscriptionAsync(subscriptionId, cancellationToken);
        
    }


}
