

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class GetUserProfileUseCase : ITBaseUseCase {

    private readonly IProfileRepository _repository;
    public GetUserProfileUseCase(IProfileRepository repository){
        _repository=repository;
    }

                
    public  async Task<User> ExecuteAsync(CancellationToken cancellationToken)
    {
    
         return    await _repository.GetUserAsync(cancellationToken);
        
    }


}
