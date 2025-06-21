
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


public interface IProfileApiClient : ITBaseShareApiClient 
{
    public Task<ApplicationUserOutputVM> GetUserAsync(CancellationToken cancellationToken);

    public Task UpdateAsync(ApplicationUserUpdateVM body, CancellationToken cancellationToken);

    public Task<SubscriptionOutputVMIEnumerablePagedResponse> GetUserSubscriptionsAsync(CancellationToken cancellationToken);

    public Task<ICollection<ModelAiOutputVM>> ModelAisAsync(CancellationToken cancellationToken);

    public Task<ICollection<ServiceOutputVM>> ServicesAsync(CancellationToken cancellationToken);

    public Task<ICollection<SpaceOutputVM>> SpacesSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken);

    public Task<SpaceOutputVM> SpaceSubscriptionAsync(string subscriptionId, string spaceId, CancellationToken cancellationToken);

    public Task<RequestOutputVMPagedResponse> RequestsSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken);

    public Task<RequestOutputVMPagedResponse> RequestsServiceAsync(string serviceId, CancellationToken cancellationToken);

}

