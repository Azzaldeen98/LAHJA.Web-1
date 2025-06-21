using Application.Service.AuthorizationSession;
using Application.UseCase.AuthorizationSession;
using Domain.Entities.AuthorizationSession;
using Domain.Repository.AuthorizationSession;
using Domain.ShareData.Base;
 using Shared.Wrapper;

namespace LAHJA.ApplicationLayer.AuthorizationSession
{
    public class AuthorizationSessionClientService
    {

        private readonly AuthorizationSessionService authorizationSessionService;
        private readonly GetSessionsAccessTokensUseCase getSessionsAccessTokensUseCase;



        public AuthorizationSessionClientService(AuthorizationSessionService authorizationSessionService)
        {
            this.authorizationSessionService = authorizationSessionService;
        }

        public async Task<Result<List<SessionTokenAuthResponse>>> GetSessionsAccessTokensAsync()
        {
            return await authorizationSessionService.GetSessionsAccessTokensAsync();

        }


        public async Task<Result<AuthorizationSessionWebResponse>> CreateAnyAuthorizationSessionAsync(AuthorizationWebRequest request)
        {
            return await authorizationSessionService.CreateAuthorizationSessionAsync(request);

        }

        public async Task<Result<DeleteResponse>> DeleteSessionAccessTokenAsync(string id)
        {
            return await authorizationSessionService.DeleteSessionAccessTokenAsync(id);

        }
        public async Task<Result<DeleteResponse>> PauseSessionTokenAsync(string id)
        {
            return await authorizationSessionService.PauseSessionTokenAsync(id);

        }

        public async Task<Result<DeleteResponse>> ResumeSessionTokenAsync(string id)
        {
            return await authorizationSessionService.ResumeSessionTokenAsync(id);

        }
        public async Task<Result<bool>> ValidateSessionTokenAsync(string token)
        {
            return await authorizationSessionService.ValidateSessionTokenAsync(token);

        }


    }
}
