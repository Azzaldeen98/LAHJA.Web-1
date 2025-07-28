
using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
using Shared.Wrapper;
using Domain.Entity;
using AutoGenerator.Attributes;
using Application.Validators;
using Domain.Validators.Enums;
namespace Application.Services;


public interface IProfileService :  ITBaseShareService  
{

    public Task<ICollection<ModelAi>> getModelsAiProfileAsync(CancellationToken cancellationToken);


    public Task<ICollection<Domain.Entity.Service>> getServicesProfileAsync(CancellationToken cancellationToken);


    public Task<ICollection<Space>> getSpacesSubscriptionProfileAsync(string subscriptionId, CancellationToken cancellationToken);


    public Task<Space> getSpaceSubscriptionProfileAsync(string subscriptionId, string spaceId, CancellationToken cancellationToken);


    public Task<User> getUserProfileAsync(CancellationToken cancellationToken);


    public Task<PaginatedResult<Subscription>> getUserSubscriptionsProfileAsync(CancellationToken cancellationToken);


    public Task<PaginatedResult<Request>> requestsServiceProfileAsync(string serviceId, CancellationToken cancellationToken);


    public Task<PaginatedResult<Request>> requestsSubscriptionProfileAsync(string subscriptionId, CancellationToken cancellationToken);


    public Task updateProfileAsync(User body, CancellationToken cancellationToken);




}

