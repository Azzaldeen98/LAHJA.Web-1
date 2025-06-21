using Domain.Entities.AuthorizationSession;
using Domain.Entities.ModelGateway;
using Domain.ShareData.Base;

namespace Domain.Repository.AuthorizationSession
{
    public interface IAuthorizationSessionRepository
    {
        Task<List<SessionTokenAuthResponse>> GetSessionsAsync();
        Task<AuthorizationSessionWebResponse> CreateAuthorizationSessionAsync(AuthorizationWebRequest request);
        Task<AuthorizationSessionCoreResponse> AuthorizationSessionAsync(ValidateTokenRequest request);
        Task ValidateSessionTokenAsync(string token);
        Task<AuthorizationSessionEncryptResponse> EncryptFromWebAsync();
        Task<AuthorizationSessionEncryptResponse> EncryptFromCoreAsync(string sessionToken);
        Task<DeleteResponse> DeleteAuthorizationSessionAsync(string sessionId);
        Task<DeleteResponse> PauseAuthorizationSessionAsync(string sessionId);

        Task<DeleteResponse> ResumeAuthorizationSessionAsync(string sessionId);
    }
    

}
