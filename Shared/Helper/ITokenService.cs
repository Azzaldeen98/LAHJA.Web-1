using Microsoft.AspNetCore.Http;
using Shared.Constants;
using Shared.Enums;
using Shared.Interfaces;

namespace Shared.Helpers
{

    public interface ITokenService : ITScope
    {

        Task<bool> IsWebHasStartUpAsync();
        Task<bool> StartUpWebSessionAsync();
        
        Task<string?> GetTokenAsync();
        string? GetToken();
        string? GetLoginType();
        string? GetRefreshToken();
        Task<string?> GetTokenFromSessionAsync();
        Task<string?> GetRefreshTokenAsync();
        Task<string> GetTokenTypeAsync();
        Task<string> GetExpiresInTokenAsync();

        ///////////////////////////////////////
        Task SaveTokenAsync(string token);
        Task SaveAllTokensAsync(string accessToken, string refreshToken, string expiresInToken, string tokenType);
        Task SaveTokenTypeAsync(string tokenType);
        Task SaveExpiresInTokenAsync(string expiresIn);
        Task SaveRefreshTokenAsync(string token);
        Task SaveLoginTypeAsync(LoginType type);
        void SetToken(string token);
        void SetRefreshToken(string token);
        Task SaveTokenInSessionAsync(string tokenIn);

        ///////////////////////////////////////
        Task RemoveTokenAsync();
        Task RemoveCookiesAsync();
        Task RemoveAllTokensAsync();
        Task DeleteTokenAsync();
        void DeleteToken();
        void DeleteRefreshToken();
        Task DeleteTokenFromSessionAsync();
        Task DeleteLoginTypeAsync();
        Task DeleteRefreshTokenAsync();
        Task DeleteTokenTypeAsync();
        Task DeleteExpiresInTokenAsync();


    }




}