
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


public interface IAuthorizationSessionApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<AuthorizationSessionOutputVM>> GetAuthorizationSessionsAsync(CancellationToken cancellationToken);

    public Task<AuthorizationSessionOutputVM> CreateAuthorizationSessionAsync(AuthorizationSessionCreateVM body, CancellationToken cancellationToken);

    public Task<AuthorizationSessionOutputVM> GetAuthorizationSessionAsync(string id, string lg, CancellationToken cancellationToken);

    public Task DeleteAuthorizationSessionAsync(string id, CancellationToken cancellationToken);

    public Task<ICollection<AuthorizationSessionOutputVM>> GetAuthorizationSessionsByLgAsync(string lg, CancellationToken cancellationToken);

    public Task<AuthorizationSessionCoreResponse> AuthorizationSessionAsync(ValidateTokenRequest body, CancellationToken cancellationToken);

    public Task<AuthorizationSessionOutputVM> CreateForDashboardAsync(CreateAuthorizationForDashboard body, CancellationToken cancellationToken);

    public Task<AuthorizationSessionOutputVM> CreateForListServicesAsync(CreateAuthorizationForListServices body, CancellationToken cancellationToken);

    public Task<AuthorizationSessionOutputVM> CreateForAllServicesAsync(CreateAuthorizationForServices body, CancellationToken cancellationToken);

    public Task<int> CountAuthorizationSessionAsync(CancellationToken cancellationToken);

    public Task<string> SimulationPlatFormAsync(EncryptTokenRequest body, CancellationToken cancellationToken);

    public Task<string> SimulationCoreAsync(string encrptedToken, string coreToken, CancellationToken cancellationToken);

    public Task ValidateWebTokenAsync(string token, CancellationToken cancellationToken);

    public Task ValidateCreateTokenAsync(string token, string coreToken, CancellationToken cancellationToken);

    public Task ValidateCoreTokenAsync(string token, string coreToken, CancellationToken cancellationToken);

    public Task PauseAuthorizationSessionAsync(string id, CancellationToken cancellationToken);

    public Task ResumeAuthorizationSessionAsync(string id, CancellationToken cancellationToken);

}

