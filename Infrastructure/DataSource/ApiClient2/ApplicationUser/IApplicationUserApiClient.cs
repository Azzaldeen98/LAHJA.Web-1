
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


public interface IApplicationUserApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<ApplicationUserOutputVM>> GetApplicationUsersAsync(CancellationToken cancellationToken);

    public Task<ApplicationUserOutputVM> GetApplicationUserAsync(string id, string lg, CancellationToken cancellationToken);

    public Task DeleteApplicationUserAsync(string id, CancellationToken cancellationToken);

    public Task<ICollection<ApplicationUserOutputVM>> GetApplicationUsersByLgAsync(string lg, CancellationToken cancellationToken);

    public Task<string> AssignServiceAsync(AssignServiceRequestVM body, CancellationToken cancellationToken);

    public Task<string> AssignModelAiAsync(AssignModelRequestVM body, CancellationToken cancellationToken);

    public Task<int> CountApplicationUserAsync(CancellationToken cancellationToken);

}

