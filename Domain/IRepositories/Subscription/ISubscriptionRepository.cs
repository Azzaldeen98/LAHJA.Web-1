
using Shared.Interfaces;
using Shared.Wrapper;
using AutoGenerator.Attributes;
using Domain.Entity;
using AutoGenerator.Attributes;
namespace Domain.IRepositories;



public interface ISubscriptionRepository: ITBaseRepository,ITScope
{
    [AutoMapper]
	public Task<ICollection<Subscription>> GetSubscriptionsAsync(CancellationToken cancellationToken);
	[AutoMapper]
	[RouteTo("GetMySubscriptionAsync")]
	public Task<Subscription> GetSubscriptionAsync(CancellationToken cancellationToken);
	[AutoMapper]
	public Task<Subscription> GetOneAsync(string id, CancellationToken cancellationToken);
	[RouteTo("PauseCollectionAsync")]
	public Task PauseAsync(Subscription model, CancellationToken cancellationToken);
	[RouteTo("RenewSubscriptionAsync")]
	public Task RenewAsync(CancellationToken cancellationToken);
	[RouteTo("ResumeCollectionAsync")]
	public Task ResumeAsync(CancellationToken cancellationToken);
	[RouteTo("CancelAtEndAsync")]
	public Task CancelAsync(CancellationToken cancellationToken);


}
    

