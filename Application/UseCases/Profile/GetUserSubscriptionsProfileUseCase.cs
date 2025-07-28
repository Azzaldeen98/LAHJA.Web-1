

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class GetUserSubscriptionsProfileUseCase : ITBaseUseCase {

    private readonly IProfileRepository _repository;
    public GetUserSubscriptionsProfileUseCase(IProfileRepository repository){
        _repository=repository;
    }

                
    public  async Task<PaginatedResult<Subscription>> ExecuteAsync(CancellationToken cancellationToken)
    {
    
         return    await _repository.GetUserSubscriptionsAsync(cancellationToken);
        
    }


}
