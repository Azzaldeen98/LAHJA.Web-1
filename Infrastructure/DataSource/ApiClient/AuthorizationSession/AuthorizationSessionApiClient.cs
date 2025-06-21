using AutoMapper;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Nswag;
using Microsoft.Extensions.Configuration;
using Infrastructure.DataSource.ApiClient.Base;
using Infrastructure.Models.AuthorizationSession;
using Domain.ShareData.Base;
using Infrastructure.Share.Invoker;




namespace Infrastructure.DataSource.ApiClient.AuthorizationSession
{
    public class AuthorizationSessionApiClient : BuildApiClient<AuthorizationSessionClient>
    {




        public AuthorizationSessionApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, IApiInvoker apiSafelyHandler) 
            : base(clientFactory, mapper, config, apiSafelyHandler)
        {

        }
        public async Task<List<SessionTokenAuthResponseModel>> GetSessionsAsync()
        {
            return await apiSafelyHandler.InvokeAsync(async () =>
            {
                var client = await GetApiClient();
                var response = await client.GetAuthorizationSessionsAsync();
                var resModel = _mapper.Map<List<SessionTokenAuthResponseModel>>(response?.ToList());

                return resModel;
            });
        
        

        }
        public async Task<AuthorizationSessionWebResponseModel> CreateAuthorizationSessionAsync(AuthorizationWebRequestModel request)
        {

            return await apiSafelyHandler.InvokeAsync(async () =>
            {
                var client = await GetApiClient();
                //var model = _mapper.Map<CreateAuthorizationWebRequest>(request);
                var model = _mapper.Map<AuthorizationSessionCreateVM>(request);
                var response = await client.CreateAuthorizationSessionAsync(model);
                var resModel = _mapper.Map<AuthorizationSessionWebResponseModel>(response);

                return resModel;
            });
                //catch (ApiException<ApiExceptionResult> ex)
                //{
                //    throw new ServerException(ex.Result.Message, ex.StatusCode);  
                //}    
                //catch (HttpRequestException e)
                //{
                //    throw new ServerException(e.Message, (int)(e.StatusCode??0));
                //}
                //catch (Exception e)
                //{
                //    throw;
                //}
     
            
        }
        public async Task<DeleteResponse> PauseAuthorizationSessionAsync(string id)
        {


            return await apiSafelyHandler.InvokeAsync(async () =>
            {
                var client = await GetApiClient();
                await client.PauseAuthorizationSessionAsync(id);
                //var resModel = _mapper.Map<DeleteResponse>(response);
                return new DeleteResponse();
             });

        }
        public async Task<DeleteResponse> ResumeAuthorizationSessionAsync(string id)
        {
            return await apiSafelyHandler.InvokeAsync(async () =>
            {
                var client = await GetApiClient();
                 await client.ResumeAuthorizationSessionAsync(id);
                //var resModel = _mapper.Map<DeleteResponse>(response);
                return  new DeleteResponse();
            });
    

        }
        public async Task<AuthorizationSessionCoreResponseModel> AuthorizationSessionAsync(ValidateTokenRequestModel request)
        {
            return await apiSafelyHandler.InvokeAsync(async () =>
            {
                var client = await GetApiClient();
                var model = _mapper.Map<ValidateTokenRequest>(request);
                var response = await client.AuthorizationSessionAsync(model);
                var resModel = _mapper.Map<AuthorizationSessionCoreResponseModel>(response);
                return resModel;
            });
         
    
          
        }
        public async Task ValidateWebTokenAsync(string  token)
        {
             await apiSafelyHandler.InvokeAsync(async () =>
            {
                var client = await GetApiClient();

                await client.ValidateWebTokenAsync(token);
            });
         
     

        }

        public async Task ValidateCoreTokenAsync(Dictionary<string, string> data)
        {
             await apiSafelyHandler.InvokeAsync(async () =>
            {
                var client = await GetApiClient();
                if (data.ContainsKey("token") && data.ContainsKey("coreToken"))
                {
                    await client.ValidateCoreTokenAsync(data["token"], data["coreToken"]);
                }
                else
                {

                }

            });
          

        }
        public async Task<AuthorizationSessionEncryptResponseModel> EncryptFromWebAsync()
        {
            return await apiSafelyHandler.InvokeAsync(async () =>
            {
                var client = await GetApiClient();
                //var response = await client.EncryptFromWebAsync(new EncryptTokenRequest { AuthorizationType = "internal", Expires = DateTimeOffset.UtcNow });
                //return new AuthorizationSessionEncryptResponseModel() { EncrptedToken = response.EncryptedToken };
                return new AuthorizationSessionEncryptResponseModel();
            });
          
        }

        public async Task<AuthorizationSessionEncryptResponseModel> EncryptFromCoreAsync(string sessionToken)
        {
            return await apiSafelyHandler.InvokeAsync(async () =>
            {
                var client = await GetApiClient();
                //var response = await client.EncryptFromCoreAsync(sessionToken);
                //return new AuthorizationSessionEncryptResponseModel() { EncrptedToken = response.EncryptedToken };
                return new AuthorizationSessionEncryptResponseModel();
            });
          

    
        }

        public async Task<DeleteResponse> DeleteAuthorizationSessionAsync(string sessionId)
        {
            return await apiSafelyHandler.InvokeAsync(async () =>
            {
                var client = await GetApiClient();
                await client.DeleteAuthorizationSessionAsync(sessionId);
                //var resModel = _mapper.Map<DeleteResponse>(response);
                return new DeleteResponse();
            });
         
            
        }


     
        //public async Task<Result<bool>> ValidateSessionTokenAsync(string token)
        //{
        //    try
        //    {
        //        var client = await GetApiClient();  // الحصول على العميل

        //        await client.ValidateSessionTokenAsync(token);

        //        return Result<bool>.Success(true);  // إرجاع النتيجة بنجاح
        //    }
        //    catch (ApiException ex)
        //    {
        //        return Result<bool>.Fail(ex.Response, ex.StatusCode);  // في حال حدوث خطأ API
        //    }
        //    catch (Exception ex)
        //    {
        //        return Result<bool>.Fail(ex.Message);  // في حال حدوث أي خطأ عام
        //    }
        //}
        //public async Task<Result<string>> EncryptFromWebAsync()
        //{
        //    try
        //    {
        //        var client = await GetApiClient();  // الحصول على العميل
        //        await client.EncryptFromWebAsync();  // استدعاء API لتشفير البيانات من الويب

        //        return Result<string>.Success();  // إرجاع النتيجة بنجاح
        //    }
        //    catch (ApiException ex)
        //    {
        //        return Result<string>.Fail(ex.Response, ex.StatusCode);  // في حال حدوث خطأ API
        //    }
        //    catch (Exception ex)
        //    {
        //        return Result<string>.Fail(ex.Message);  // في حال حدوث أي خطأ عام
        //    }
        //}

        //public async Task<Result<string>> EncryptFromCoreAsync(string sessionToken)
        //{
        //    try
        //    {
        //        var client = await GetApiClient();  // الحصول على العميل
        //        await client.EncryptFromCoreAsync(sessionToken);  // استدعاء API لتشفير البيانات من الCore

        //        return Result<string>.Success();  // إرجاع النتيجة بنجاح
        //    }
        //    catch (ApiException ex)
        //    {
        //        return Result<string>.Fail(ex.Response, ex.StatusCode);  // في حال حدوث خطأ API
        //    }
        //    catch (Exception ex)
        //    {
        //        return Result<string>.Fail(ex.Message);  // في حال حدوث أي خطأ عام
        //    }
        //}

        //public async Task<Result<DeleteResponse>> DeleteAuthorizationSessionAsync(string sessionId)
        //{
        //    try
        //    {
        //        var client = await GetApiClient();
        //        var response = await client.DeleteAuthorizationSessionAsync(sessionId);
        //        var resModel = _mapper.Map<DeleteResponse>(response);
        //        return Result<DeleteResponse>.Success(resModel);
        //    }
        //    catch (ApiException ex)
        //    {
        //        return Result<DeleteResponse>.Fail(ex.Response, ex.StatusCode);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Result<DeleteResponse>.Fail(ex.Message);
        //    }
        //}
    }
}
