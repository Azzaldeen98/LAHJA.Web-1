
using Shared.Interfaces;
using Shared.Wrapper;
using AutoGenerator.Config.Attributes;
using Domain.Entity;
using AutoGenerator.Config.Attributes;
namespace Domain.IRepositories;



public interface ISubscriptionRepository: ITBaseRepository,ITScope
{
    	[AutomateMapper]
	public Task<ICollection<Subscription>> GetSubscriptionsAsync(CancellationToken cancellationToken);
	[AutomateMapper]
	public Task<Subscription> GetSubscriptionAsync(CancellationToken cancellationToken);
	[AutomateMapper]
	public Task<Subscription> GetOneAsync(string id, CancellationToken cancellationToken);
[RouteTo("PauseCollectionAsync")]
	public Task PauseAsync(Subscription model, CancellationToken cancellationToken);
	public Task RenewAsync(CancellationToken cancellationToken);
[RouteTo("ResumeCollection2Async")]
	public Task ResumeAsync(CancellationToken cancellationToken);
[RouteTo("Cancel2Async")]
	public Task CancelAsync(CancellationToken cancellationToken);


}
    

