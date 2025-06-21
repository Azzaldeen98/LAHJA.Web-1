
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


public interface ISubscriptionApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<SubscriptionOutputVM>> GetSubscriptionsAsync(CancellationToken cancellationToken);

    public Task<SubscriptionOutputVM> GetSubscriptionAsync(string id, CancellationToken cancellationToken);

    public Task<SubscriptionOutputVM> GetMySubscriptionAsync(CancellationToken cancellationToken);

    public Task PauseCollectionAsync(SubscriptionUpdateRequest body, CancellationToken cancellationToken);

    public Task ResumeCollectionAsync(CancellationToken cancellationToken);

    public Task CancelSubscriptionAsync(CancellationToken cancellationToken);

    public Task CancelAtEndAsync(CancellationToken cancellationToken);

    public Task RenewSubscriptionAsync(CancellationToken cancellationToken);

    public Task ResumeSubscriptionAsync(SubscriptionResumeRequest body, CancellationToken cancellationToken);

    public Task CheckSubscriptionAsync(CancellationToken cancellationToken);

    public Task<ICollection<SubscriptionOutputVM>> GetAllSubscriptionsAsync(CancellationToken cancellationToken);

    public Task<SubscriptionOutputVM> GetOneSubscriptionAsync(string id, CancellationToken cancellationToken);

    public Task PauseCollection2Async(string id, SubscriptionUpdateRequest body, CancellationToken cancellationToken);

    public Task ResumeCollection2Async(string id, CancellationToken cancellationToken);

    public Task Cancel2Async(string id, CancellationToken cancellationToken);

    public Task CancelAtEnd2Async(string id, CancellationToken cancellationToken);

    public Task RenewAsync(string id, CancellationToken cancellationToken);

    public Task ResumeAsync(string id, SubscriptionResumeRequest body, CancellationToken cancellationToken);

}

