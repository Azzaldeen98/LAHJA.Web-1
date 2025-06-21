using Domain.Entities.Product.Request;
using Domain.Entities.Product.Response;
using Domain.ShareData.Base;
 using Shared.Wrapper;


namespace Domain.Repository.Product
{
    public interface IProductRepository
    {

        Task<Result<List<ProductResponse>>> SearchAsync(ProductSearchRequest request);
        Task<Result<List<ProductResponse>>> GetAllAsync(FilterResponseData filter);
        Task<Result<ProductResponse>> CreateAsync(ProductCreate request);
        Task<Result<DeleteResponse>> DeleteAsync(string id);
        Task<Result<ProductResponse>> UpdateAsync(ProductUpdate request);
    }
}