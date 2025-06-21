

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class GetByIdPlanUseCase : ITBaseUseCase {

    private readonly IPlanRepository _repository;
    public GetByIdPlanUseCase(IPlanRepository repository){
        _repository=repository;
    }

                
    public  async Task<Plan> ExecuteAsync(string lg, string id, CancellationToken cancellationToken)
    {
    
         return    await _repository.GetByIdAsync(lg, id, cancellationToken);
        
    }


}
