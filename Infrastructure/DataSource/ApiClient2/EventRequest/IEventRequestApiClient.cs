
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


public interface IEventRequestApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<EventRequestOutputVM>> GetEventRequestsAsync(CancellationToken cancellationToken);

    public Task<EventRequestOutputVM> GetEventRequestAsync(string id, CancellationToken cancellationToken);

    public Task DeleteEventRequestAsync(string id, CancellationToken cancellationToken);

    public Task<int> CountEventRequestAsync(CancellationToken cancellationToken);

}

