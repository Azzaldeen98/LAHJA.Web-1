
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


public interface ISettingApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<SettingOutputVM>> GetSettingsAsync(CancellationToken cancellationToken);

    public Task<SettingOutputVM> CreateSettingAsync(SettingCreateVM body, CancellationToken cancellationToken);

    public Task<SettingInfoVM> GetSettingAsync(string id, CancellationToken cancellationToken);

    public Task DeleteSettingAsync(string id, CancellationToken cancellationToken);

    public Task<SettingOutputVM> GetSettingByLgAsync(SettingFilterVM body, CancellationToken cancellationToken);

    public Task<ICollection<SettingOutputVM>> GetSettingsByLgAsync(string lg, CancellationToken cancellationToken);

    public Task<ICollection<SettingOutputVM>> CreateRange15Async(IEnumerable<SettingCreateVM> body, CancellationToken cancellationToken);

    public Task<SettingOutputVM> UpdateSettingAsync(string name, SettingUpdateVM body, CancellationToken cancellationToken);

    public Task<int> CountSettingAsync(CancellationToken cancellationToken);

}

