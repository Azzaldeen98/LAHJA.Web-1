using Domain.Entities.Plans.Response;

namespace Domain.Repository.Plans
{
    public interface IPlansContainerRepository
    {
        public Task<IEnumerable<PlansContainerResponse>> getAllPlansContainerAsync();
    }
}
