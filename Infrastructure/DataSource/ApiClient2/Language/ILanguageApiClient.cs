
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


public interface ILanguageApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<LanguageOutputVM>> GetLanguagesAsync(string lg, CancellationToken cancellationToken);

    public Task<LanguageOutputVM> CreateLanguageAsync(LanguageCreateVM body, CancellationToken cancellationToken);

    public Task<LanguageOutputVM> GetLanguageAsync(string id, CancellationToken cancellationToken);

    public Task<LanguageOutputVM> UpdateLanguageAsync(string id, LanguageUpdateVM body, CancellationToken cancellationToken);

    public Task DeleteLanguageAsync(string id, CancellationToken cancellationToken);

    public Task<LanguageOutputVM> GetLanguageByLgAsync(string id, string lg, CancellationToken cancellationToken);

    public Task<LanguageOutputVM> GetLanguageByCodeAsync(string code, string lg, CancellationToken cancellationToken);

    public Task<ICollection<LanguageOutputVM>> GetLanguagesByLgAsync(string lg, CancellationToken cancellationToken);

    public Task<ICollection<LanguageOutputVM>> CreateRange8Async(IEnumerable<LanguageCreateVM> body, CancellationToken cancellationToken);

    public Task<int> CountLanguageAsync(CancellationToken cancellationToken);

}

