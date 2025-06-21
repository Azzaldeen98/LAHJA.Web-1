
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


public interface IDialectApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<DialectOutputVM>> GetDialectsAsync(string lg, CancellationToken cancellationToken);

    public Task<DialectOutputVM> CreateDialectAsync(DialectCreateVM body, CancellationToken cancellationToken);

    public Task<DialectOutputVM> GetDialectAsync(string id, string lg, CancellationToken cancellationToken);

    public Task<DialectOutputVM> UpdateDialectAsync(string id, DialectUpdateVM body, CancellationToken cancellationToken);

    public Task DeleteDialectAsync(string id, CancellationToken cancellationToken);

    public Task<DialectOutputVM> GetDialectByLanguageAsync(string langId, string lg, CancellationToken cancellationToken);

    public Task<ICollection<DialectOutputVM>> GetDialectsByLanguageAsync(string langId, string lg, CancellationToken cancellationToken);

    public Task<ICollection<DialectOutputVM>> CreateRange5Async(IEnumerable<DialectCreateVM> body, CancellationToken cancellationToken);

    public Task<int> CountDialectAsync(CancellationToken cancellationToken);

}

