using Application.Service.Plans;
using AutoMapper;
 using Shared.Wrapper;
using LAHJA.Helpers.Services;
using Domain.Entities.Price.Response;
using Domain.Entities.Price;
using Domain.Entities.Price.Request;
using Domain.ShareData.Base;
using Shared.Helpers;

namespace LAHJA.ApplicationLayer.Price
{
    public class PriceClientService
    {
        private readonly PriceService _priceService;
        private readonly ITokenService tokenService;
        private readonly IMapper _mapper;



        public PriceClientService(PriceService PriceService, IMapper mapper, ITokenService tokenService)
        {

            this._priceService = PriceService;
            _mapper = mapper;
            this.tokenService = tokenService;
        }




        public async Task<Result<List<PriceResponse>>> SearchAsync(PriceSearchOptionsRequest request)
        {
            return await _priceService.SearchAsync(request);
        }
        public async Task<Result<PriceResponse>> CreateAsync(PriceCreate request)
        {
            return await _priceService.createAsync(request);
        }
        public async Task<Result<DeleteResponse>> DeleteAsync(string id)
        {
            return await _priceService.DeleteAsync(id);
        }
        public async Task<Result<PriceResponse>> UpdateAsync(PriceUpdate request)
        {
            return await _priceService.UpdateAsync(request);
        }

    }
}
