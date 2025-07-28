

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class GetSpacesSubscriptionProfileUseCase : ITBaseUseCase {

    private readonly IProfileRepository _repository;
    public GetSpacesSubscriptionProfileUseCase(IProfileRepository repository){
        _repository=repository;
    }

                
    public  async Task<ICollection<Space>> ExecuteAsync(string subscriptionId, CancellationToken cancellationToken)
    {
    
         return    await _repository.GetSpacesSubscriptionAsync(subscriptionId, cancellationToken);
        
    }


}
