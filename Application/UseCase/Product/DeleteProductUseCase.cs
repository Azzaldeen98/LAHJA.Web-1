using Domain.Repository.Product;
using Domain.ShareData.Base;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class DeleteProductUseCase
    {
        private readonly IProductRepository repository;
        public DeleteProductUseCase(IProductRepository repository)
        {

            this.repository = repository;
        }

        public async Task<Result<DeleteResponse>> ExecuteAsync(string id)
        {

            return await repository.DeleteAsync(id);

        }
    }




   

}
