using Domain.Entities.Request.Response;
using Domain.Repository.Request;
 using Shared.Wrapper;

namespace Application.UseCase.Request
{
    public class RequestAllowedUseCase
    {
        private readonly IRequestRepository repository;

        public RequestAllowedUseCase(IRequestRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<RequestResponse>> ExecuteAsync(string serviceId)
        {

            return await repository.RequestAllowedAsync(serviceId);
        }
    }



}
