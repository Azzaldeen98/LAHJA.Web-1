

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class GetPlansUseCase : ITBaseUseCase {

    private readonly IPlanRepository _repository;
    public GetPlansUseCase(IPlanRepository repository){
        _repository=repository;
    }

                
    public  async Task<ICollection<Plan>> ExecuteAsync(String lg, CancellationToken cancellationToken)
    {
    
         return   await _repository.GetPlansAsync(lg, cancellationToken);
        
    }


}
