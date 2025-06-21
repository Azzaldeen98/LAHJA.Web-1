using Application.UseCase.Plans;
using Application.UseCase.Plans.Get;
using Domain.Entities.Billing.Request;
using Domain.Entities.Billing.Response;
using Domain.Entities.Checkout;
using Domain.Entities.Checkout.Request;
using Domain.Entities.Checkout.Response;
using Domain.Entities.Plans.Response;
using Domain.ShareData.Base;
 using Shared.Wrapper;
using Infrastructure.Models.Profile.Response;

namespace Application.Service.Plans
{
    public class BillingService
    {
        private readonly GetBillingDetailsUseCase _getBillingDetailsUseCase;
        private readonly CreateBillingDetailsUseCase _createBillingDetailsUseCase;
        private readonly UpdateBillingDetailsUseCase _updateBillingDetailsUseCase;
        private readonly DeleteBillingDetailsUseCase _deleteBillingDetailsUseCase;

        public BillingService(
            GetBillingDetailsUseCase getBillingDetailsUseCase,
            CreateBillingDetailsUseCase createBillingDetailsUseCase,
            UpdateBillingDetailsUseCase updateBillingDetailsUseCase,
            DeleteBillingDetailsUseCase deleteBillingDetailsUseCase)
        {
            _getBillingDetailsUseCase = getBillingDetailsUseCase;
            _createBillingDetailsUseCase = createBillingDetailsUseCase;
            _updateBillingDetailsUseCase = updateBillingDetailsUseCase;
            _deleteBillingDetailsUseCase = deleteBillingDetailsUseCase;
        }


        public async Task<Result<BillingDetailsResponse>> GetBillingDetailsAsync()
        {
            return await _getBillingDetailsUseCase.ExecuteAsync();
        }
        public async Task<Result<BillingDetailsResponse>> CreateAsync(BillingDetailsRequest request)
        {
            return await _createBillingDetailsUseCase.ExecuteAsync(request);
        }
        public async Task<Result<DeleteResponse>> DeleteAsync(string id)
        {
            return await _deleteBillingDetailsUseCase.ExecuteAsync(id);
        }
        public async Task<Result<BillingDetailsResponse>> UpdateAsync(BillingDetailsRequest request)
        {
            return await _updateBillingDetailsUseCase.ExecuteAsync(request);
        }






    } 
}
