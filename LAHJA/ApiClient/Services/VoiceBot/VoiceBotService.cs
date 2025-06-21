 using Shared.Wrapper;
using LAHJA.ApiClient.Models;
using LAHJA.ApiClient.Services.Query;
using LAHJA.Data.UI.Models;
using Microsoft.JSInterop;

namespace LAHJA.ApiClient.Services.VoiceBot
{

    public interface IVoiceBotService
    {
        Task<Result<ServiceAIResponse>> TextToSpeechAsync(QueryRequest request);
 
    }
    public class VoiceBotService : IVoiceBotService
    {
        private readonly IT2TService _T2TService;
        private readonly IQueryTextToSpeechService _queryTextToSpeechService;
        public VoiceBotService(IT2TService t2TService, IQueryTextToSpeechService queryTextToSpeechService)
        {
            _T2TService = t2TService;
            _queryTextToSpeechService = queryTextToSpeechService;
        }

        public async Task<Result<ServiceAIResponse>> TextToSpeechAsync(QueryRequest request)
        {
            var resText = await _T2TService.T2TClientJSAsync(request.QueryRequestTextToText);
            if (resText.Succeeded)
            {   string text= resText.Data.Result;
                if (!string.IsNullOrEmpty(text))
                {
                    request.QueryRequestTextToSpeech.Data = text;
                    var resVoice = await _queryTextToSpeechService.TextToSpeechAsync(request.QueryRequestTextToSpeech);
                    return resVoice;
                } 

            }
            return Result<ServiceAIResponse>.Fail();
        }
    }
}
