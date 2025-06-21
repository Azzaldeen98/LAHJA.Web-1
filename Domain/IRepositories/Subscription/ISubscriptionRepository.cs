
using Shared.Interfaces;
using Shared.Wrapper;
using AutoGenerator.Config.Attributes;
using Domain.Entity;
namespace Domain.IRepositories;



public interface ISubscriptionRepository: ITBaseRepository,ITScope
{
    	[AutomateMapper]
	public Task<ICollection<Subscription>> GetSubscriptionsAsync(CancellationToken cancellationToken);
	[AutomateMapper]
	public Task<Subscription> GetSubscriptionAsync(CancellationToken cancellationToken);
	[AutomateMapper]
	public Task<Subscription> GetOneAsync(string id, CancellationToken cancellationToken);
	public Task PauseAsync(string id,Subscription model, CancellationToken cancellationToken);
	public Task RenewAsync(string id, CancellationToken cancellationToken);
	public Task ResumeAsync(string id, CancellationToken cancellationToken);
	public Task CancelAsync(string id, CancellationToken cancellationToken);


}
    

