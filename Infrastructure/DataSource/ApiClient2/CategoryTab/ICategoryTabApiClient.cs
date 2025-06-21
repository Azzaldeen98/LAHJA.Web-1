
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


public interface ICategoryTabApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<CategoryTabOutputVM>> GetCategoryTabsAsync(string lg, CancellationToken cancellationToken);

    public Task<CategoryTabOutputVM> CreateCategoryTabAsync(CategoryTabCreateVM body, CancellationToken cancellationToken);

    public Task<ICollection<CategoryTabOutputVM>> GetActiveCategoryTabsAsync(string lg, CancellationToken cancellationToken);

    public Task<CategoryTabOutputVM> GetCategoryTabAsync(string id, string lg, CancellationToken cancellationToken);

    public Task<CategoryTabOutputVM> UpdateCategoryTabAsync(string id, CategoryTabUpdateVM body, CancellationToken cancellationToken);

    public Task DeleteCategoryTabAsync(string id, CancellationToken cancellationToken);

    public Task<CategoryTabOutputVM> GetCategoryTabByLanguageAsync(string id, string lg, CancellationToken cancellationToken);

    public Task<ICollection<CategoryTabOutputVM>> GetCategoryTabsByLanguageAsync(string lg, CancellationToken cancellationToken);

    public Task<ICollection<CategoryTabOutputVM>> CreateRange4Async(IEnumerable<CategoryTabCreateVM> body, CancellationToken cancellationToken);

    public Task<int> CountCategoryTabsAsync(CancellationToken cancellationToken);

}

