using Domain.Entities.Product.Request;
using Domain.Entities.Product.Response;
using Domain.Repository.Product;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class SearchProductUseCase
    {
        private readonly IProductRepository repository;
        public SearchProductUseCase(IProductRepository repository)
        {

            this.repository = repository;
        }

        public async Task<Result<List<ProductResponse>>> ExecuteAsync(ProductSearchRequest request)
        {

            return await repository.SearchAsync(request);

        }
    }




   

}
