using Application.Service.Plans;
using AutoMapper;
 using Shared.Wrapper;
using LAHJA.Helpers.Services;
using Domain.Entities.Checkout.Response;
using Domain.Entities.Checkout;
using Domain.Entities.Checkout.Request;
using Application.Service.Checkout;
using Shared.Helpers;

namespace LAHJA.ApplicationLayer.Checkout
{
    public class CheckoutClientService
    {
        private readonly CheckoutService paymentService;
        private readonly ITokenService tokenService;
        private readonly IMapper _mapper;



        public CheckoutClientService(CheckoutService paymentService, IMapper mapper, ITokenService tokenService)
        {

            this.paymentService = paymentService;
            _mapper = mapper;
            this.tokenService = tokenService;
        }




        public async Task<Result<CheckoutResponse>> CheckoutAsync(CheckoutRequest request)
        {

            var result=await paymentService.CheckoutAsync(request);
            return result;

       

        }     
        
        public async Task<Result<CheckoutResponse>> CheckoutManageAsync(SessionCreate request)
        {

            var result=await paymentService.CheckoutManageAsync(request);
            return result;

       
        }

    }
}
