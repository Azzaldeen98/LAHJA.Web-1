using Application.Service.Service;
using AutoMapper;
using Domain.Entities.Event.Request;
using Domain.Entities.Event.Response;
using Domain.Entities.Service.Request;
using Domain.Entities.Service.Response;
using Domain.ShareData.Base;
 using Shared.Wrapper;
using LAHJA.ApiClient.Models;
using LAHJA.ApiClient.Services;
using LAHJA.ApiClient.Services.Query;
using LAHJA.ApiClient.Services.VoiceBot;
using LAHJA.Data.UI.Models;
using LAHJA.Helpers.Services;
using Shared.Helpers;

namespace LAHJA.ApplicationLayer.Service
{
    public class LAHJAClientService
    {
        private readonly LAHJAService _lahjaService;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IVoiceBotService voiceBotService;
        private readonly IT2TService t2TService;
        private readonly IQueryTextToSpeechService queryTextToSpeechService;

        public LAHJAClientService(LAHJAService lahjaService, IMapper mapper, ITokenService tokenService, IVoiceBotService voiceBotService, IT2TService t2TService, IQueryTextToSpeechService queryTextToSpeechService)
        {
            _lahjaService = lahjaService;
            _mapper = mapper;
            _tokenService = tokenService;
            this.voiceBotService = voiceBotService;
            this.t2TService = t2TService;
            this.queryTextToSpeechService = queryTextToSpeechService;
        }

        public async Task<Result<List<ServiceResponse>>> GetAllAsync()
        {
            // يمكنك إضافة منطق إضافي هنا إذا لزم الأمر
            return await _lahjaService.GetAllAsync();
        }

        public async Task<Result<ServiceResponse>> GetOneAsync(string id)
        {
            // يمكنك استخدام _tokenService للتحقق أو إدارة الرموز
            return await _lahjaService.GetOneAsync(id);
        }

        public async Task<Result<ServiceResponse>> CreateAsync(ServiceRequest request)
        {
            // مثال على استخدام _mapper لتحويل البيانات إذا لزم الأمر
            //var mappedRequest = _mapper.Map<ServiceRequest>(request);
            return await _lahjaService.CreateAsync(request);
        }
   
        public async Task<Result<ServiceResponse>> UpdateAsync(ServiceRequest request)
        {
            //var mappedRequest = _mapper.Map<ServiceRequest>(request);
            return await _lahjaService.UpdateAsync(request);
        }

        public async Task<Result<DeleteResponse>> DeleteAsync(string id)
        {
            return await _lahjaService.DeleteAsync(id);
        }


        public async Task<Result<ServiceAIResponse>> Text2TextAsync(Data.UI.Models.QueryRequestTextToText request)
        {

            return  await t2TService.T2TClientJSAsync(request);
        }

        public async Task<Result<ServiceAIResponse>> Text2SpeechAsync(Data.UI.Models.QueryRequestTextToSpeech request)
        {

            return await queryTextToSpeechService.TextToSpeechAsync(request);
        }

        public async Task<Result<ServiceAIResponse>> VoiceBotAsync(QueryRequest request)
        {

            return await voiceBotService.TextToSpeechAsync(request);
        }

      
    }

}
