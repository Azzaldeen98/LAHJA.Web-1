using Domain.Entities.Event.Request;
using Domain.Entities.Event.Response;
using Domain.Repository.Request;
 using Shared.Wrapper;

namespace Application.UseCase.Request
{
    public class CreateEventUseCase
    {
        private readonly IRequestRepository repository;

        public CreateEventUseCase(IRequestRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<EventResponse>> ExecuteAsync(EventRequest request)
        {
            //return Result<EventResponse>.Success();
            return await repository.CreateEventAsync(request);
        }
    }



}
