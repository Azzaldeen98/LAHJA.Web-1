using Domain.Entities.Product.Request;
using Domain.Entities.Product.Response;
using Domain.Repository.Product;
using Domain.ShareData.Base;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{

    
    public class CreateProductUseCase
    {
        private readonly IProductRepository repository;
        public CreateProductUseCase(IProductRepository repository)
        {

            this.repository = repository;
        }

        public async Task<Result<ProductResponse>> ExecuteAsync(ProductCreate request)
        {

            return await repository.CreateAsync(request);

        }
    }




   

}
