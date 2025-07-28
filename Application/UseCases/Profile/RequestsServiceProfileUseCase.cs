

using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.IRepositories;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.UseCases;


public class RequestsServiceProfileUseCase : ITBaseUseCase {

    private readonly IProfileRepository _repository;
    public RequestsServiceProfileUseCase(IProfileRepository repository){
        _repository=repository;
    }

                
    public  async Task<PaginatedResult<Request>> ExecuteAsync(string serviceId, CancellationToken cancellationToken)
    {
    
         return    await _repository.RequestsServiceAsync(serviceId, cancellationToken);
        
    }


}
