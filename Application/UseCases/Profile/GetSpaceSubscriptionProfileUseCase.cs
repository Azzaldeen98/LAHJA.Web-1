

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class GetSpaceSubscriptionProfileUseCase : ITBaseUseCase {

    private readonly IProfileRepository _repository;
    public GetSpaceSubscriptionProfileUseCase(IProfileRepository repository){
        _repository=repository;
    }

                
    public  async Task<Space> ExecuteAsync(string subscriptionId, string spaceId, CancellationToken cancellationToken)
    {
    
         return    await _repository.GetSpaceSubscriptionAsync(subscriptionId, spaceId, cancellationToken);
        
    }


}
