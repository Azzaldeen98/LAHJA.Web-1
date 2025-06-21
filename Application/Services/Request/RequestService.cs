using Application.UseCase.Request;
using Domain.Entities.Event.Request;
using Domain.Entities.Event.Response;
using Domain.Entities.Request.Request;
using Domain.Entities.Request.Response;
using Domain.Entities.Service.Response;
 using Shared.Wrapper;


namespace Application.Service.Service
{
    public class RequestService
    {
        private readonly CreateRequestUseCase  createRequestUseCase;
        private readonly RequestAllowedUseCase requestAllowedUseCase;
        private readonly CreateEventUseCase createEventUseCase;
        private readonly ResultRequestUseCase  resultRequestUseCase;




        public RequestService(CreateRequestUseCase createRequestUseCase, RequestAllowedUseCase requestAllowedUseCase, CreateEventUseCase createEventUseCase, ResultRequestUseCase resultRequestUseCase)
        {
            this.createRequestUseCase = createRequestUseCase;
            this.requestAllowedUseCase = requestAllowedUseCase;
            this.createEventUseCase = createEventUseCase;
            this.resultRequestUseCase = resultRequestUseCase;
        }

        public async Task<Result<RequestResponse>> CreateRequestAsync(RequestCreate request)
        {
            return await createRequestUseCase.ExecuteAsync(request);
        }

        public async Task<Result<RequestResponse>> RequestAllowedAsync(string serviceId)
        {
            return await requestAllowedUseCase.ExecuteAsync(serviceId);
        }

        public async Task<Result<EventResponse>> CreateEventAsync(EventRequest request)
        {
            return await createEventUseCase.ExecuteAsync(request);
        }
        public async Task<Result<ServiceResponse>> ResultRequestAsync(ResultRequest request)
        {

            return await resultRequestUseCase.ExecuteAsync(request);
        }


    }
}
