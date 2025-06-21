using Domain.Entities.Plans.Response;
using Domain.Repository.Plans;
 using Shared.Wrapper;

namespace Application.UseCase.Plans
{
    public class GetAllPlansContainersUseCase
    {
        private readonly IPlansRepository repository;
        public GetAllPlansContainersUseCase(IPlansRepository repository) {

            this.repository = repository;
        }


        public async Task<Result<IEnumerable<PlansContainerResponse>>> ExecuteAsync(){

         throw new NotImplementedException();

           
        }


    }
}
