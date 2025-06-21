using Infrastructure.DataSource.ApiClientFactory;
using Shared.Interfaces;

namespace LAHJA.Config
{


    public interface IAppSettingsService:ITSingleton
    {
        BaseUrl BaseUrl { get; }
        string GetSetting(string key);
    }

    public class AppSettingsService : IAppSettingsService
    {
        private readonly IConfiguration _configuration;

        public AppSettingsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public BaseUrl BaseUrl => new BaseUrl
        {
            Api = _configuration["BaseUrls:Api"],
            Auth = _configuration["BaseUrls:Auth"],
            Web = _configuration["BaseUrls:Web"]
        };

        public string GetSetting(string key)
        {
            return _configuration[key];
        }
    }

}
