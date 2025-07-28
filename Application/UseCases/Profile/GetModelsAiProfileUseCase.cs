

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class GetModelsAiProfileUseCase : ITBaseUseCase {

    private readonly IProfileRepository _repository;
    public GetModelsAiProfileUseCase(IProfileRepository repository){
        _repository=repository;
    }

                
    public  async Task<ICollection<ModelAi>> ExecuteAsync(CancellationToken cancellationToken)
    {
    
         return    await _repository.GetModelsAiAsync(cancellationToken);
        
    }


}
