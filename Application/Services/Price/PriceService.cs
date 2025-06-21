using Application.UseCase.Plans.Get;
using Domain.Entities.Price.Request;
using Domain.Entities.Price.Response;
using Domain.ShareData.Base;
 using Shared.Wrapper;


namespace Application.Service.Plans
{
    public class PriceService
    {

        private readonly CreatePriceUseCase createPriceUseCase;
        private readonly UpdatePriceUseCase updatePriceUseCase; 
        private readonly DeletePriceUseCase deletePriceUseCase; 
        private readonly SearchPriceUseCase searchPriceUseCase; 



        public PriceService(CreatePriceUseCase createPriceUseCase, 
                            UpdatePriceUseCase updatePriceUseCase,
                            DeletePriceUseCase deletePriceUseCase, 
                            SearchPriceUseCase searchPriceUseCase)
        {
            this.createPriceUseCase = createPriceUseCase;
            this.updatePriceUseCase = updatePriceUseCase;
            this.deletePriceUseCase = deletePriceUseCase;
            this.searchPriceUseCase = searchPriceUseCase;
        }

        public async Task<Result<List<PriceResponse>>> SearchAsync(PriceSearchOptionsRequest request)
        {
            return await searchPriceUseCase.ExecuteAsync(request);

        } 
        
        public async Task<Result<PriceResponse>> createAsync(PriceCreate request)
        {
            return await createPriceUseCase.ExecuteAsync(request);

        }

        public async Task<Result<PriceResponse>> UpdateAsync(PriceUpdate request)
        {
            return await updatePriceUseCase.ExecuteAsync(request);

        }
         public async Task<Result<DeleteResponse>> DeleteAsync(string id)
        {
            return await deletePriceUseCase.ExecuteAsync(id);

        }




    } 
}
