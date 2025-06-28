
using Shared.Interfaces;
using Shared.Wrapper;
using AutoGenerator.Config.Attributes;
using Domain.Entity;
using AutoGenerator.Config.Attributes;
namespace Domain.IRepositories;



public interface IPlanRepository: ITBaseRepository,ITScope
{
    	public Task<ICollection<Plan>> GetPlansAsync(string lg, CancellationToken cancellationToken);
	public Task<int> CountAllPlansAsync(CancellationToken cancellationToken);
	[AutomateMapper]
	public Task<Plan> GetByIdAsync(string lg, string id,CancellationToken cancellationToken);


}
    

