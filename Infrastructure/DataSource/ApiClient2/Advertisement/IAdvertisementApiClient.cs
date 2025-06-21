
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


public interface IAdvertisementApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<AdvertisementOutputVM>> GetAdvertisementsAsync(string lg, CancellationToken cancellationToken);

    public Task<AdvertisementOutputVM> CreateAdvertisementAsync(AdvertisementCreateVM body, CancellationToken cancellationToken);

    public Task<ICollection<AdvertisementOutputVM>> GetActiveAdvertisementsAsync(string lg, CancellationToken cancellationToken);

    public Task<AdvertisementOutputVM> GetAdvertisementAsync(string id, string lg, CancellationToken cancellationToken);

    public Task<AdvertisementOutputVM> UpdateAdvertisementAsync(string id, AdvertisementUpdateVM body, CancellationToken cancellationToken);

    public Task DeleteAdvertisementAsync(string id, CancellationToken cancellationToken);

    public Task<ICollection<AdvertisementOutputVM>> GetAdvertisementsByLgAsync(string lg, CancellationToken cancellationToken);

    public Task<ICollection<AdvertisementOutputVM>> CreateRangeAsync(IEnumerable<AdvertisementCreateVM> body, CancellationToken cancellationToken);

    public Task<int> CountAdvertisementAsync(CancellationToken cancellationToken);

}

