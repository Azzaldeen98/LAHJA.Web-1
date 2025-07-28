

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class UpdateProfileUseCase : ITBaseUseCase {

    private readonly IProfileRepository _repository;
    public UpdateProfileUseCase(IProfileRepository repository){
        _repository=repository;
    }

                
    public async  Task ExecuteAsync(User body, CancellationToken cancellationToken)
    {
    
          await _repository.UpdateAsync(body, cancellationToken);
        
    }


}
