
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


public interface IModelAiApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<ModelAiOutputVM>> GetModelAisAsync(string lg, CancellationToken cancellationToken);

    public Task<ModelAiOutputVM> CreateModelAiAsync(ModelAiCreateVM body, CancellationToken cancellationToken);

    public Task<ModelAiOutputVM> GetModelAiAsync(string id, string lg, CancellationToken cancellationToken);

    public Task<ModelAiOutputVM> UpdateModelAiAsync(string id, ModelAiUpdateVM body, CancellationToken cancellationToken);

    public Task DeleteModelAiAsync(string id, CancellationToken cancellationToken);

    public Task<ICollection<ModelAiOutputVM>> GetModelsByTypeAsync(string type, CancellationToken cancellationToken);

    public Task<ICollection<string>> GetCategoriesByTypeAsync(string type, CancellationToken cancellationToken);

    public Task<ICollection<string>> GetLanguagesByAsync(string type, string category, CancellationToken cancellationToken);

    public Task<ICollection<ModelAiOutputVM>> GetModelsByCategoryAsync(string category, CancellationToken cancellationToken);

    public Task<ModelAiOutputVMPagedResponse> FilterMaodelAiAsync(ModelAiFilterVM body, CancellationToken cancellationToken);

    public Task<ICollection<ModelAiOutputVM>> GetModelAisByLanguageAsync(string lg, CancellationToken cancellationToken);

    public Task<ICollection<ModelAiOutputVM>> CreateRange9Async(IEnumerable<ModelAiCreateVM> body, CancellationToken cancellationToken);

    public Task<int> CountModelAisAsync(CancellationToken cancellationToken);

}

