
using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.Services;


public interface ISubscriptionService :  ITBaseShareService  
{

    public Task cancelSubscriptionAsync(string id, CancellationToken cancellationToken);


    public Task<Subscription> getOneSubscriptionAsync(string id, CancellationToken cancellationToken);


    public Task<ICollection<Subscription>> getSubscriptionsAsync(CancellationToken cancellationToken);


    public Task<Subscription> getSubscriptionAsync(CancellationToken cancellationToken);


    public Task pauseSubscriptionAsync(string id, Subscription model, CancellationToken cancellationToken);


    public Task renewSubscriptionAsync(string id, CancellationToken cancellationToken);


    public Task resumeSubscriptionAsync(string id, CancellationToken cancellationToken);




}

