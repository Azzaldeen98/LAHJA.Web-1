

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class GetServicesProfileUseCase : ITBaseUseCase {

    private readonly IProfileRepository _repository;
    public GetServicesProfileUseCase(IProfileRepository repository){
        _repository=repository;
    }

                
    public  async Task<ICollection<Service>> ExecuteAsync(CancellationToken cancellationToken)
    {
    
         return    await _repository.GetServicesAsync(cancellationToken);
        
    }


}
