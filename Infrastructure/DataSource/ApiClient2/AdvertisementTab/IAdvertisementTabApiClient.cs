
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


public interface IAdvertisementTabApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<AdvertisementTabOutputVM>> GetAdvertisementTabsAsync(string lg, CancellationToken cancellationToken);

    public Task<AdvertisementTabOutputVM> CreateAdvertisementTabAsync(AdvertisementTabCreateVM body, CancellationToken cancellationToken);

    public Task<AdvertisementTabOutputVM> GetAdvertisementTabAsync(string id, string lg, CancellationToken cancellationToken);

    public Task<AdvertisementTabOutputVM> UpdateAdvertisementTabAsync(string id, AdvertisementTabUpdateVM body, CancellationToken cancellationToken);

    public Task DeleteAdvertisementTabAsync(string id, CancellationToken cancellationToken);

    public Task<AdvertisementTabOutputVM> GetByAdvertisementIdAsync(string advertisementId, string lg, CancellationToken cancellationToken);

    public Task<ICollection<AdvertisementTabOutputVM>> GetAdvertisementTabsByLgAsync(string lg, CancellationToken cancellationToken);

    public Task<ICollection<AdvertisementTabOutputVM>> CreateRange2Async(IEnumerable<AdvertisementTabCreateVM> body, CancellationToken cancellationToken);

    public Task<int> CountAdvertisementTabAsync(CancellationToken cancellationToken);

}

