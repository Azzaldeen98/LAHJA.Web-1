using Domain.Entities.Event.Request;
using Domain.Entities.Event.Response;
using Domain.Entities.Request.Request;
using Domain.Entities.Request.Response;
using Domain.Entities.Service.Response;
 using Shared.Wrapper;

namespace Domain.Repository.Request
{
    public interface IRequestRepository
    {
        Task<Result<RequestResponse>> CreateRequestAsync(RequestCreate request);
        Task<Result<RequestResponse>> RequestAllowedAsync(string serviceId);
        Task<Result<EventResponse>> CreateEventAsync(EventRequest request);
        Task<Result<ServiceResponse>> ResultRequestAsync(ResultRequest request);
       
    }
}