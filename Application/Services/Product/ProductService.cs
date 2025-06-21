using Application.UseCase.Plans.Get;
using Domain.Entities.Product.Request;
using Domain.Entities.Product.Response;
using Domain.ShareData.Base;
 using Shared.Wrapper;


namespace Application.Service.Prroduct
{

    public class ProductService
    {

        private readonly CreateProductUseCase createProductUseCase;
        private readonly UpdateProductUseCase updateProductUseCase; 
        private readonly DeleteProductUseCase deleteProductUseCase; 
        private readonly SearchProductUseCase searchProductUseCase; 
        private readonly GetAllProductsUseCase  getAllProductsUseCase;



        public ProductService(CreateProductUseCase createProductUseCase,
                            UpdateProductUseCase updateProductUseCase,
                            DeleteProductUseCase deleteProductUseCase,
                            SearchProductUseCase searchProductUseCase,
                            GetAllProductsUseCase getAllProductsUseCase)
        {
            this.createProductUseCase = createProductUseCase;
            this.updateProductUseCase = updateProductUseCase;
            this.deleteProductUseCase = deleteProductUseCase;
            this.searchProductUseCase = searchProductUseCase;
            this.getAllProductsUseCase = getAllProductsUseCase;
        }
        public async Task<Result<List<ProductResponse>>> SearchAsync(ProductSearchRequest request) {
            return await searchProductUseCase.ExecuteAsync(request);
        }
        public async Task<Result<List<ProductResponse>>> GetAllAsync(FilterResponseData filter)
        {
            return await getAllProductsUseCase.ExecuteAsync(filter);
        }
        public async Task<Result<ProductResponse>> CreateAsync(ProductCreate request)
        {
            return await createProductUseCase.ExecuteAsync(request);
        }
        public async Task<Result<DeleteResponse>> DeleteAsync(string id)
        {
            return await deleteProductUseCase.ExecuteAsync(id);
        }
        public async Task<Result<ProductResponse>> UpdateAsync(ProductUpdate request)
        {
            return await updateProductUseCase.ExecuteAsync(request);
        }
       

    } 
}
