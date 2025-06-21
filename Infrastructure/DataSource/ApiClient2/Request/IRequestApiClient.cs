
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Infrastructure.Share.Invoker;
using AutoMapper;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Share.Invoker;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.DataSource.ApiClient2;


public interface IRequestApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<RequestOutputVM>> GetRequests2Async(CancellationToken cancellationToken);

    public Task<RequestOutputVM> CreateRequestAsync(RequestCreateVM body, CancellationToken cancellationToken);

    public Task<RequestOutputVM> GetRequestAsync(string id, CancellationToken cancellationToken);

    public Task<RequestOutputVM> UpdateRequestAsync(string id, RequestUpdateVM body, CancellationToken cancellationToken);

    public Task DeleteRequestAsync(string id, CancellationToken cancellationToken);

    public Task<ICollection<RequestOutputVM>> GetRequestsByLgAsync(string lg, CancellationToken cancellationToken);

    public Task<EventRequestOutputVM> CreateEventAsync(EventRequestCreateVM body, CancellationToken cancellationToken);

    public Task<int> CountRequestAsync(CancellationToken cancellationToken);

}

