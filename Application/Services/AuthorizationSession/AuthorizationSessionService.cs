using Application.UseCase.AuthorizationSession;
using Domain.Entities.AuthorizationSession;
using Domain.Entities.Service.Response;
using Domain.Exceptions;
using Domain.Repository.AuthorizationSession;
using Domain.Repository.Service;
using Domain.ShareData.Base;
 using Shared.Wrapper;

namespace Application.Service.AuthorizationSession
{
    public class AuthorizationSessionService
    {


        private readonly GetSessionsAccessTokensUseCase getSessionsAccessTokensUseCase;
        private readonly CreateAuthorizationSessionUseCase createAuthorizationSessionUseCase;
        private readonly DeleteAuthorizationSessionUseCase deleteAuthorizationSessionUseCase;
        private readonly ValidateSessionTokenUseCase validateSessionTokenUseCase;
        private readonly PauseSessionTokenUseCase pauseSessionTokenUseCase;
        private readonly ResumeSessionTokenUseCase resumeSessionTokenUseCase;
        private readonly IAuthorizationSessionRepository authorizationSessionRepository;
        private readonly IServiceRepository serviceRepository;

        public AuthorizationSessionService(
                            GetSessionsAccessTokensUseCase getSessionsAccessTokensUseCase,
                            DeleteAuthorizationSessionUseCase deleteAuthorizationSessionUseCase,
                            ValidateSessionTokenUseCase validateSessionTokenUseCase,
                            IAuthorizationSessionRepository authorizationSessionRepository,
                            PauseSessionTokenUseCase pauseSessionTokenUseCase,
                            ResumeSessionTokenUseCase resumeSessionTokenUseCase,
                            CreateAuthorizationSessionUseCase createAuthorizationSessionUseCase,
                            IServiceRepository serviceRepository)
        {


            this.getSessionsAccessTokensUseCase = getSessionsAccessTokensUseCase;
            this.deleteAuthorizationSessionUseCase = deleteAuthorizationSessionUseCase;
            this.validateSessionTokenUseCase = validateSessionTokenUseCase;
            this.authorizationSessionRepository = authorizationSessionRepository;
            this.pauseSessionTokenUseCase = pauseSessionTokenUseCase;
            this.resumeSessionTokenUseCase = resumeSessionTokenUseCase;
            this.createAuthorizationSessionUseCase = createAuthorizationSessionUseCase;
            this.serviceRepository = serviceRepository;
        }

        public async Task<Result<AuthorizationSessionWebResponse>> CreateAuthorizationSessionAsync(AuthorizationWebRequest request)
        {
   

            try
            {

                var service= await serviceRepository.GetOneAsync(request.ServiceId);
             
                if (service != null)
                {
                    var encrypt = await authorizationSessionRepository.EncryptFromWebAsync();
                    if (encrypt != null)
                    {
                        var response = await authorizationSessionRepository.CreateAuthorizationSessionAsync(new AuthorizationWebRequest
                        {
                            ServiceId = service.Id,
                            Token = encrypt.EncrptedToken
                        });
                        if (response != null)
                        {
                            return Result<AuthorizationSessionWebResponse>.Success(response);
                        }
                    }
                }

            
                return  Result<AuthorizationSessionWebResponse>.Fail("Not Found Service !!");
            }
            catch (ServerException e) {

                return Result<AuthorizationSessionWebResponse>.Fail(e.Message,e.StatusCode);
            }
            catch (Exception e) {
               return Result<AuthorizationSessionWebResponse>.Fail(e.Message);
            }


        
    

        }
        
        public async Task<Result<List<SessionTokenAuthResponse>>> GetSessionsAccessTokensAsync()
        {
            return await getSessionsAccessTokensUseCase.ExecuteAsync();

        }

        public async Task<Result<DeleteResponse>> DeleteSessionAccessTokenAsync(string id)
        {
            return await deleteAuthorizationSessionUseCase.ExecuteAsync(id);

        }    
        
        public async Task<Result<DeleteResponse>> PauseSessionTokenAsync(string id)
        {
            return await pauseSessionTokenUseCase.ExecuteAsync(id);

        }   
        
        public async Task<Result<DeleteResponse>> ResumeSessionTokenAsync(string id)
        {
            return await resumeSessionTokenUseCase.ExecuteAsync(id);

        }

        public async Task<Result<bool>> ValidateSessionTokenAsync(string token)
        {
            return await validateSessionTokenUseCase.ExecuteAsync(token);

        }


    }
}
