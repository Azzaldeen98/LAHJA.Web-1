
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


public interface IFAQItemApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<FAQItemOutputVM>> GetFAQItemsAsync(string lg, CancellationToken cancellationToken);

    public Task<FAQItemOutputVM> CreateFAQItemAsync(FAQItemCreateVM body, CancellationToken cancellationToken);

    public Task<FAQItemOutputVM> GetFAQItemAsync(string id, string lg, CancellationToken cancellationToken);

    public Task<FAQItemOutputVM> UpdateFAQItemAsync(string id, FAQItemUpdateVM body, CancellationToken cancellationToken);

    public Task DeleteFAQItemAsync(string id, CancellationToken cancellationToken);

    public Task<FAQItemOutputVM> GetFAQItemByLgAsync(string id, string lg, CancellationToken cancellationToken);

    public Task<ICollection<FAQItemOutputVM>> GetFAQItemsByLgAsync(string lg, CancellationToken cancellationToken);

    public Task<ICollection<FAQItemOutputVM>> CreateRange6Async(IEnumerable<FAQItemCreateVM> body, CancellationToken cancellationToken);

    public Task<int> CountFAQItemsAsync(CancellationToken cancellationToken);

}

