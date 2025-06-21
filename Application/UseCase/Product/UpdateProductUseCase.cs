using Domain.Entities.Product.Request;
using Domain.Entities.Product.Response;
using Domain.Repository.Product;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class UpdateProductUseCase
    {
        private readonly IProductRepository repository;
        public UpdateProductUseCase(IProductRepository repository)
        {

            this.repository = repository;
        }

        public async Task<Result<ProductResponse>> ExecuteAsync(ProductUpdate request)
        {

            return await repository.UpdateAsync(request);

        }
    }




   

}
