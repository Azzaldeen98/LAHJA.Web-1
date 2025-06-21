using Domain.Entities.Product.Response;
using Domain.Repository.Product;
using Domain.ShareData.Base;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class GetAllProductsUseCase
    {
        private readonly IProductRepository repository;
        public GetAllProductsUseCase(IProductRepository repository)
        {

            this.repository = repository;
        }

        public async Task<Result<List<ProductResponse>>> ExecuteAsync(FilterResponseData filter)
        {

            return await repository.GetAllAsync(filter);

        }
    }




   

}
