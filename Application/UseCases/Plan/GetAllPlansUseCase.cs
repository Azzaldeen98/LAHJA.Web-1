

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class GetAllPlansUseCase : ITBaseUseCase {

    private readonly IPlanRepository _repository;
    public GetAllPlansUseCase(IPlanRepository repository){
        _repository=repository;
    }

                
    public  async Task<PaginatedResult<Plan>> ExecuteAsync(string lg, CancellationToken cancellationToken)
    {

        return null;//  await _repository.GetPlansAsync(lg, cancellationToken);
        
    }


}
