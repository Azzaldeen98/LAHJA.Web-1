
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


public interface ISpaceApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<SpaceOutputVM>> GetSpacesAsync(CancellationToken cancellationToken);

    public Task<SpaceOutputVM> CreateSpaceAsync(SpaceCreateVM body, CancellationToken cancellationToken);

    public Task<SpaceOutputVM> GetSpaceAsync(string id, CancellationToken cancellationToken);

    public Task<SpaceOutputVM> UpdateSpaceAsync(string id, SpaceUpdateVM body, CancellationToken cancellationToken);

    public Task DeleteSpaceAsync(string id, CancellationToken cancellationToken);

    public Task<SpaceOutputVM> GetSpaceByLgAsync(SpaceFilterVM body, CancellationToken cancellationToken);

    public Task<ICollection<SpaceOutputVM>> GetSpacesByLgAsync(string lg, CancellationToken cancellationToken);

    public Task<ICollection<SpaceOutputVM>> CreateRange16Async(IEnumerable<SpaceCreateVM> body, CancellationToken cancellationToken);

    public Task<int> CountSpaceAsync(CancellationToken cancellationToken);

}

