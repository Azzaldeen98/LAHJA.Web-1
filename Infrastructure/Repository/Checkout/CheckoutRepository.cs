
using AutoMapper;
using Domain.Entities.Checkout;
using Domain.Entities.Checkout.Request;
using Domain.Entities.Checkout.Response;
using Domain.Repository.Checkout;
 using Shared.Wrapper;
using Infrastructure.DataSource;
using Infrastructure.DataSource.ApiClient.Payment;
using Infrastructure.DataSource.Seeds;
using Infrastructure.Models.Checkout.Request;
using Infrastructure.Models.Checkout.Response;
using Shared.Helpers;
using Shared.Settings;

namespace Infrastructure.Repository.Plans
{
    public class CheckoutRepository : ICheckoutRepository
    {
        private readonly SeedsPlans seedsPlans;
        private readonly CheckoutApiClient paymentApiClient;
        private readonly AuthControl authControl;
		private readonly ITokenService tokenService;
		private readonly IMapper _mapper;
        private readonly ApplicationModeService appModeService;
		public CheckoutRepository(
			IMapper mapper,
			SeedsPlans seedsPlans,
			ApplicationModeService appModeService,
			CheckoutApiClient paymentApiClient,
			AuthControl authControl,
			ITokenService tokenService)
		{

			//seedsPlans = new SeedsPlans();
			_mapper = mapper;
			this.seedsPlans = seedsPlans;
			this.appModeService = appModeService;

			this.paymentApiClient = paymentApiClient;
			this.authControl = authControl;
			this.tokenService = tokenService;
		}



		public async Task<Result<CheckoutResponse>> CheckoutAsync(CheckoutRequest request)
        {
            var model = _mapper.Map<CheckoutRequestModel>(request);
			var response = await ExecutorAppMode.ExecuteAsync<Result<CheckoutResponseModel>>(
				 async () => await paymentApiClient.CheckoutAsync(model),
				  async () => await paymentApiClient.CheckoutAsync(model));

			if (response.Succeeded)
			{
				var result =  _mapper.Map<CheckoutResponse>(response.Data) ;
				return Result<CheckoutResponse>.Success(result);
			}
			else
			{
				return Result<CheckoutResponse>.Fail(response.Messages);
			}

			

		}

        public async Task<Result<CheckoutResponse>> CheckoutManageAsync(SessionCreate request)
        {

            {
                var model = _mapper.Map<SessionCreateModel>(request);
                var response = await ExecutorAppMode.ExecuteAsync<Result<CheckoutResponseModel>>(
                     async () => await paymentApiClient.CheckoutManageAsync(model),
                      async () => Result<CheckoutResponseModel>.Success());

                if (response.Succeeded)
                {
                    var result = (response.Data != null) ? _mapper.Map<CheckoutResponse>(response.Data) : null;
                    return Result<CheckoutResponse>.Success(result);
                }
                else
                {
                    return Result<CheckoutResponse>.Fail(response.Messages);
                }
            }



        }
   



    } 
}
