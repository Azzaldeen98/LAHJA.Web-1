using Domain.Entities.Request.Request;
using Domain.Entities.Request.Response;
using Domain.Repository.Request;
 using Shared.Wrapper;

namespace Application.UseCase.Request
{
    public class CreateRequestUseCase
    {
        private readonly IRequestRepository repository;

        public CreateRequestUseCase(IRequestRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<RequestResponse>> ExecuteAsync(RequestCreate request)
        {
            return await repository.CreateRequestAsync(request);
        }
    }

}
