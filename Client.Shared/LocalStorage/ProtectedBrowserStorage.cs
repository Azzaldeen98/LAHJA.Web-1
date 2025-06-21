using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.Extensions.Logging;
namespace Shared.LocalStorage
{
    public class ProtectedBrowserStorage : IProtectedBrowserStorage
    {
        private readonly ProtectedSessionStorage PSession;
        private readonly ILogger<BrowserStorageService> _logger;

        public ProtectedBrowserStorage(ProtectedSessionStorage pSession, ILogger<BrowserStorageService> logger)
        {
            PSession = pSession;
            _logger = logger;
        }

        public async Task SaveAsync(string key,string token)
        {

            try
            {
                if (!string.IsNullOrEmpty(token))
                {

                    await PSession.SetAsync(key, token);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                _logger.LogError(e, "Error saving token in session");
            }
        }

        public async Task DeleteAsync(string key)
        {
            try
            {
                await PSession.DeleteAsync(key);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task<string> GetAsync(string key)
        {
            return (await PSession.GetAsync<string>(key)).Value ?? "";
        }
    }

}