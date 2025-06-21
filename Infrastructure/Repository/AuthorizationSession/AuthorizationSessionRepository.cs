using AutoMapper;
using Domain.Entities.AuthorizationSession;
using Domain.Entities.AuthorizationSession;
using Domain.Repository.AuthorizationSession;
using Domain.ShareData.Base;
 using Shared.Wrapper;
using Infrastructure.Core.Repositories.Base;
using Infrastructure.DataSource.ApiClient.AuthorizationSession;
using Infrastructure.DataSource.ApiClient.Payment;
using Infrastructure.Models.AuthorizationSession;
using Infrastructure.Models.Price.Request;
using Infrastructure.Models.Price.Response;
using Shared.Settings;
using System.Reflection;

namespace Infrastructure.Repository.AuthorizationSession
{
    public class AuthorizationSessionRepository : BaseRepository<AuthorizationSessionApiClient>, IAuthorizationSessionRepository
    {
        public AuthorizationSessionRepository(IMapper mapper, ApplicationModeService appModeService, AuthorizationSessionApiClient apiClient) 
            : base(mapper, appModeService, apiClient)
        {

        }
        public async Task<List<SessionTokenAuthResponse>> GetSessionsAsync()
        {

            var response = await ExecutorAppMode.ExecuteAsync<List<SessionTokenAuthResponseModel>>(
                  async () => await _apiClient.GetSessionsAsync(),
                   async () => await _apiClient.GetSessionsAsync());
  
            var resModel = _mapper.Map<List<SessionTokenAuthResponse>>(response);

            return resModel;

        }


        public async Task<AuthorizationSessionWebResponse> CreateAuthorizationSessionAsync(AuthorizationWebRequest request) {
          
            var model = _mapper.Map<AuthorizationWebRequestModel>(request);
            var response = await ExecutorAppMode.ExecuteAsync<AuthorizationSessionWebResponseModel>(
                 async () => await _apiClient.CreateAuthorizationSessionAsync(model),
                  async () => await _apiClient.CreateAuthorizationSessionAsync(model));

            return _mapper.Map<AuthorizationSessionWebResponse>(response);

        }
        public async Task<AuthorizationSessionCoreResponse> AuthorizationSessionAsync(ValidateTokenRequest request) {
           
            var model = _mapper.Map<ValidateTokenRequestModel>(request);
            var response = await ExecutorAppMode.ExecuteAsync<AuthorizationSessionCoreResponseModel>(
                 async () => await _apiClient.AuthorizationSessionAsync(model),
                  async () => await _apiClient.AuthorizationSessionAsync(model));

            return _mapper.Map<AuthorizationSessionCoreResponse>(response);
        }
        public async Task ValidateSessionTokenAsync(string token) {

            
            await ExecutorAppMode.ExecuteAsync(
                 async () =>  _apiClient.ValidateWebTokenAsync(token),
                  async () => _apiClient.ValidateWebTokenAsync(token)
              );
        }
        public async Task<AuthorizationSessionEncryptResponse> EncryptFromWebAsync() {

               var  res= await ExecutorAppMode.ExecuteAsync<AuthorizationSessionEncryptResponseModel>(
                    async () =>await _apiClient.EncryptFromWebAsync(),
                    async () =>await _apiClient.EncryptFromWebAsync()
                );

            return _mapper.Map<AuthorizationSessionEncryptResponse>(res);
        }
        public async Task<DeleteResponse> PauseAuthorizationSessionAsync(string id)
        {

            var res = await ExecutorAppMode.ExecuteAsync<DeleteResponse>(
               async () => await _apiClient.PauseAuthorizationSessionAsync(id),
               async () => await _apiClient.PauseAuthorizationSessionAsync(id)
           );
       
      
            return res;

        }
        public async Task<DeleteResponse> ResumeAuthorizationSessionAsync(string id)
        {


            var res = await ExecutorAppMode.ExecuteAsync<DeleteResponse>(
                async () => await _apiClient.ResumeAuthorizationSessionAsync(id),
                async () => await _apiClient.ResumeAuthorizationSessionAsync(id)
            );


            return res;

        }
        public async Task<AuthorizationSessionEncryptResponse> EncryptFromCoreAsync(string sessionToken) {

            var res =  await ExecutorAppMode.ExecuteAsync<AuthorizationSessionEncryptResponseModel>(
                  async () => await _apiClient.EncryptFromCoreAsync(sessionToken),
                  async () => await _apiClient.EncryptFromCoreAsync(sessionToken)
              );

            return _mapper.Map<AuthorizationSessionEncryptResponse>(res);
        }
        public async Task<DeleteResponse> DeleteAuthorizationSessionAsync(string sessionId) {

           return await ExecutorAppMode.ExecuteAsync<DeleteResponse>(
                    async () =>await  _apiClient.DeleteAuthorizationSessionAsync(sessionId),
                    async () => await _apiClient.DeleteAuthorizationSessionAsync(sessionId)
                );


        }
    }

}
