
using Shared.Interfaces;
using Shared.Wrapper;
using AutoGenerator.Config.Attributes;
using Domain.Entity;
namespace Domain.IRepositories;



public interface IPlanRepository: ITBaseRepository,ITScope
{
    [AutomateMapper]
	public Task<PaginatedResult<Plan>> GetAllPlansAsync(string lg, CancellationToken cancellationToken);

    [AutomateMapper]
    public  Task<List<Plan>> GetPlansAsync(String lg, CancellationToken cancellationToken);

    public Task<int> CountAllPlansAsync(CancellationToken cancellationToken);
	[AutomateMapper]
	public Task<Plan> GetByIdAsync(string lg, string id,CancellationToken cancellationToken);


}
    

