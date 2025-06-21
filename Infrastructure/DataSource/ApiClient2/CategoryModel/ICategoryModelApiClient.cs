
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


public interface ICategoryModelApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<CategoryModelOutputVM>> GetCategoryModelsAsync(string lg, CancellationToken cancellationToken);

    public Task<CategoryModelOutputVM> CreateCategoryModelAsync(CategoryModelCreateVM body, CancellationToken cancellationToken);

    public Task<CategoryModelOutputVM> GetCategoryModelAsync(string id, string lg, CancellationToken cancellationToken);

    public Task<CategoryModelOutputVM> UpdateCategoryModelAsync(string id, CategoryModelUpdateVM body, CancellationToken cancellationToken);

    public Task DeleteCategoryModelAsync(string id, CancellationToken cancellationToken);

    public Task<CategoryModelOutputVM> GetCategoryModelByNameAsync(string name, string lg, CancellationToken cancellationToken);

    public Task<ICollection<CategoryModelOutputVM>> GetCategoryModelsByLgAsync(string lg, CancellationToken cancellationToken);

    public Task<ICollection<CategoryModelOutputVM>> CreateRange3Async(IEnumerable<CategoryModelCreateVM> body, CancellationToken cancellationToken);

    public Task<int> CountCategoryModelAsync(CancellationToken cancellationToken);

}

