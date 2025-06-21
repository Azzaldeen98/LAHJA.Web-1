

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class CountAllPlansUseCase : ITBaseUseCase {

    private readonly IPlanRepository _repository;
    public CountAllPlansUseCase(IPlanRepository repository){
        _repository=repository;
    }

                
    public  async Task<int> ExecuteAsync(CancellationToken cancellationToken)
    {
    
         return    await _repository.CountAllPlansAsync(cancellationToken);
        
    }


}
