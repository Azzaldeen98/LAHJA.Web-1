using Shared.Constants;
using Shared.Helpers;

namespace Shared.LocalStorage
{


    public class TokenService2 //: ITokenService
    {
        private readonly IProtectedStorage _storage;

        private  string AccessTokenKey = ConstantsApp.ACCESS_TOKEN;
        private const string RefreshTokenKey = ConstantsApp.REFRESH_TOKEN;
        private const string TokenTypeKey = ConstantsApp.TOKEN_TYPE;
        private const string ExpiresInTokenKey = ConstantsApp.EXPIRES_IN_TOKEN;
     

        public TokenService2(IProtectedStorage storage)
        {
            _storage = storage;
        }

        public async Task SaveTokenAsync(string token) =>
          await  _storage.SaveAsync(AccessTokenKey, token);

        public async Task<string?> GetTokenAsync() =>
          await  _storage.GetAsync(AccessTokenKey);

        public async Task<string?> GetTokenFromSessionAsync() =>
           await _storage.GetAsync(AccessTokenKey); 

        public async Task SaveRefreshTokenAsync(string token) =>
          await  _storage.SaveAsync(RefreshTokenKey, token);

        public async Task<string?> GetRefreshTokenAsync() =>
          await  _storage.GetAsync(RefreshTokenKey);

        public async Task SaveTokenTypeAsync(string tokenType) =>
          await  _storage.SaveAsync(TokenTypeKey, tokenType);

        public async Task<string> GetTokenTypeAsync() =>
          await _storage.GetAsync(TokenTypeKey)!;

        public async Task SaveExpiresInTokenAsync(string expiresIn) =>
          await _storage.SaveAsync(ExpiresInTokenKey, expiresIn);

        public async Task<string> GetExpiresInTokenAsync() =>
          await  _storage.GetAsync(ExpiresInTokenKey)!;

        public async Task SaveAllTokensAsync(string accessToken, string refreshToken, string expiresInToken, string tokenType)
        {
            await Task.WhenAll(
                SaveTokenAsync(accessToken),
                SaveRefreshTokenAsync(refreshToken),
                SaveExpiresInTokenAsync(expiresInToken),
                SaveTokenTypeAsync(tokenType)
            );
        }

        public async Task DeleteTokenAsync() =>
            await _storage.DeleteAsync(AccessTokenKey);
        public async Task DeleteRefreshTokenAsync() =>
            await _storage.DeleteAsync(RefreshTokenKey);
        public async Task DeleteTokenTypeAsync() =>
            await _storage.DeleteAsync(TokenTypeKey);
        public async Task DeleteExpiresInTokenAsync() =>
            await _storage.DeleteAsync(ExpiresInTokenKey);

        public async Task RemoveAllTokensAsync()
        {

            try { 
                    var keys = new[] { AccessTokenKey, RefreshTokenKey, TokenTypeKey, ExpiresInTokenKey };
                    var deleteTasks = keys.Select(k => _storage.DeleteAsync(k));
                    await Task.WhenAll(deleteTasks);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while removing tokens: {ex.Message}");
                throw; 
            }
        }


    }
}