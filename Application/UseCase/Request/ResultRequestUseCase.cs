using Domain.Entities.Event.Request;
using Domain.Entities.Service.Response;
using Domain.Repository.Request;
 using Shared.Wrapper;

namespace Application.UseCase.Request
{
    public class ResultRequestUseCase
    {
        private readonly IRequestRepository repository;

        public ResultRequestUseCase(IRequestRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<ServiceResponse>> ExecuteAsync(ResultRequest request)
        {

            return await repository.ResultRequestAsync(request);
        }
    }



}
