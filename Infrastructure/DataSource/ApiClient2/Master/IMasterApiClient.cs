
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


public interface IMasterApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<LanguageOutputVM>> GetLanguages2Async(string lg, CancellationToken cancellationToken);

    public Task<ICollection<LanguageOutputVM>> GetLanguageByCodeAllAsync(string code, string lg, CancellationToken cancellationToken);

    public Task GetCategoryModelByName2Async(string name, string lg, CancellationToken cancellationToken);

    public Task GetTypeByNameAsync(string name, string lg, CancellationToken cancellationToken);

    public Task ActiveAsync(string lg, CancellationToken cancellationToken);

    public Task<DialectOutputVM> DialectAsync(string languageId, string lg, CancellationToken cancellationToken);

    public Task<ICollection<DialectOutputVM>> DialectsAsync(string languageId, string lg, CancellationToken cancellationToken);

    public Task<AdvertisementOutputVM> AdvertisementsAsync(string id, string lg, CancellationToken cancellationToken);

    public Task<ICollection<AdvertisementOutputVM>> GetActiveAdvertisements2Async(string lg, CancellationToken cancellationToken);

    public Task<AdvertisementTabOutputVM> AdvertisementtabAsync(string id, string lg, CancellationToken cancellationToken);

    public Task<ICollection<AdvertisementTabOutputVM>> AdvertisementtabsAsync(string advertisementId, string lg, CancellationToken cancellationToken);

    public Task<ICollection<LanguageOutputVM>> GetLanguages3Async(string lg, CancellationToken cancellationToken);

    public Task<ICollection<LanguageOutputVM>> GetLanguageByCodeAll2Async(string code, string lg, CancellationToken cancellationToken);

    public Task CreateLanguage2Async(LanguageCreateVM body, CancellationToken cancellationToken);

    public Task GetCategoryModelByName3Async(string name, string lg, CancellationToken cancellationToken);

    public Task CreateCategoryModel2Async(CategoryModelCreateVM body, CancellationToken cancellationToken);

    public Task GetTypeByName2Async(string name, string lg, CancellationToken cancellationToken);

    public Task Active2Async(string lg, CancellationToken cancellationToken);

    public Task<ICollection<TypeModelOutputVM>> CreateTypesAsync(TypeModelCreateVM body, CancellationToken cancellationToken);

    public Task<DialectOutputVM> Dialect2Async(string languageId, string lg, CancellationToken cancellationToken);

    public Task<ICollection<DialectOutputVM>> Dialects2Async(string languageId, string lg, CancellationToken cancellationToken);

    public Task<AdvertisementOutputVM> Advertisements2Async(string id, string lg, CancellationToken cancellationToken);

    public Task<ICollection<AdvertisementOutputVM>> GetActiveAdvertisements3Async(string lg, CancellationToken cancellationToken);

    public Task<AdvertisementTabOutputVM> Advertisementtab2Async(string id, string lg, CancellationToken cancellationToken);

    public Task<ICollection<AdvertisementTabOutputVM>> Advertisementtabs2Async(string advertisementId, string lg, CancellationToken cancellationToken);

}

