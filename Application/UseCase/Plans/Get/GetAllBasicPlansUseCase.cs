//using Domain.Entities.Plans;
//using Domain.Repository.Plans;
// using Shared.Wrapper;

//namespace Application.UseCase.Plans
//{
//    public class GetAllBasicPlansUseCase
//    {
//        private readonly IPlansRepository repository;
//        public GetAllBasicPlansUseCase(IPlansRepository repository)
//        {

//            this.repository = repository;
//        }


//        public async Task<Result<IEnumerable<PlansGroup>>> ExecuteAsync()
//        {

//            var data = await repository.getAllBasicPlansAsync();

//            if (data != null)
//            {
//                return Result<IEnumerable<PlansGroup>>.Success(data);
//            }
//            else
//            {
//                return Result<IEnumerable<PlansGroup>>.Fail();
//            }


//        }
//    }    

//}
