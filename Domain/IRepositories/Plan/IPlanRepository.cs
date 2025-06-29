
using Shared.Interfaces;
using Shared.Wrapper;
using AutoGenerator.Attributes;
using Domain.Entity;
using AutoGenerator.Attributes;
namespace Domain.IRepositories;



public interface IPlanRepository: ITBaseRepository,ITScope
{
    	public Task<ICollection<Plan>> GetPlansAsync(string lg, CancellationToken cancellationToken);
	public Task<int> CountAllPlansAsync(CancellationToken cancellationToken);
	[AutoMapper]
	public Task<Plan> GetByIdAsync(string lg, string id,CancellationToken cancellationToken);


}
    

