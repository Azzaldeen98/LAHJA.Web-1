using Domain.Entities.Plans.Response;
using Domain.Repository.Plans;
using Domain.ShareData.Base;
 using Shared.Wrapper;

namespace Application.UseCase.Plans
{
    public class GetAllContainersPlansUseCase
    {
        private readonly IPlansRepository repository;
        public GetAllContainersPlansUseCase(IPlansRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<IEnumerable<ContainerPlans>>> ExecuteAsync(FilterResponseData filter)
        {

            return await repository.GetContainersAsync(filter);


        }


    }
}
