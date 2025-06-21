

using LAHJA.ApiClient.Repository;
using LAHJA.ApiClient.Services;
using LAHJA.ApiClient.Services.Query;
using LAHJA.ApiClient.Services.VoiceBot;

namespace LAHJA.ApiClient
{
    public static class ApiClientConfigServices
    {

        public static void InstallApiClientConfigServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IT2TService,T2TService>();
            serviceCollection.AddScoped<IT2TRepository, T2TRepository>();
            serviceCollection.AddScoped<IQueryTextToSpeechService,QueryTextToSpeechService>();
            serviceCollection.AddScoped<IVoiceBotService, VoiceBotService>();
        }
    }
}
