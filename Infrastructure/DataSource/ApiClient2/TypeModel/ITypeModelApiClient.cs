
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


public interface ITypeModelApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<TypeModelOutputVM>> GetTypeModelsAsync(string lg, CancellationToken cancellationToken);

    public Task<TypeModelOutputVM> CreateTypeModelAsync(TypeModelCreateVM body, CancellationToken cancellationToken);

    public Task<TypeModelOutputVM> GetTypeModelAsync(string id, string lg, CancellationToken cancellationToken);

    public Task<TypeModelOutputVM> UpdateTypeModelAsync(string id, TypeModelUpdateVM body, CancellationToken cancellationToken);

    public Task DeleteTypeModelAsync(string id, CancellationToken cancellationToken);

    public Task<TypeModelOutputVM> GetTypeModelByNameAsync(string name, string lg, CancellationToken cancellationToken);

    public Task<ICollection<TypeModelOutputVM>> GetActiveTypeModelsAsync(string lg, CancellationToken cancellationToken);

    public Task<TypeModelOutputVM> GetTypeModelByLanguageAsync(string id, string lg, CancellationToken cancellationToken);

    public Task<ICollection<TypeModelOutputVM>> GetTypeModelsByLanguageAsync(string lg, CancellationToken cancellationToken);

    public Task<ICollection<TypeModelOutputVM>> CreateRange17Async(IEnumerable<TypeModelCreateVM> body, CancellationToken cancellationToken);

    public Task<int> CountTypeModelsAsync(CancellationToken cancellationToken);

}

