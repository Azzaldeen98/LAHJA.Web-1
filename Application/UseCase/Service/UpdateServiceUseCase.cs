using Domain.Entities.Service.Request;
using Domain.Entities.Service.Response;
using Domain.Repository.Service;
 using Shared.Wrapper;

namespace Application.UseCase.Service
{
    public class UpdateServiceUseCase
    {
        private readonly IServiceRepository repository;

        public UpdateServiceUseCase(IServiceRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<ServiceResponse>> ExecuteAsync(ServiceRequest request)
        {
            return await repository.UpdateAsync(request);
        }
    }


}
