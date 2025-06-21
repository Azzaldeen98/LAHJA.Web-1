using LAHJA.Helpers.Enum;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.JSInterop;
using Shared.Constants;
using Shared.Enums;
using Shared.Helpers;
namespace LAHJA.Helpers.Services
{

    ////TODO: 8-2
    /// <summary>
    /// 
    /// </summary>
    public class TokenService : ITokenService
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly ProtectedSessionStorage PSession;
        private readonly ProtectedLocalStorage PLocalStorage;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TokenService(IJSRuntime jsRuntime, ProtectedSessionStorage pSession, ProtectedLocalStorage pLocalStorage, IHttpContextAccessor httpContextAccessor)
        {
            _jsRuntime = jsRuntime;
            PSession = pSession;
            PLocalStorage = pLocalStorage;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> IsWebHasStartUpAsync()
        {
            try
            {
                return (await PSession.GetAsync<bool>(ConstantsApp.START_UP_WEB)).Value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
        }
        public async Task<bool> StartUpWebSessionAsync()
        {

            try
            {
                if (!await IsWebHasStartUpAsync())
                {
                    await PSession.SetAsync(ConstantsApp.START_UP_WEB, true);
                    return true;
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public async Task SaveTokenInSessionAsync(string token)
        {

            try
            {
                if (!string.IsNullOrEmpty(token))
                {

                    await PSession.SetAsync(ConstantsApp.ACCESS_TOKEN, token);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    

        public async Task<string?> GetTokenFromSessionAsync()
        {
            return  (await PSession.GetAsync<string>(ConstantsApp.ACCESS_TOKEN)).Value??"";
        }

        public async Task SaveTokenAsync(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                await PLocalStorage.SetAsync(ConstantsApp.ACCESS_TOKEN, token);
                //await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", ConstantsApp.ACCESS_TOKEN, token);
            }
           
        }

        public async Task SaveRefreshTokenAsync(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                await PLocalStorage.SetAsync(ConstantsApp.REFRESH_TOKEN, token);
                //await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", ConstantsApp.REFRESH_TOKEN, token);
            }

           
        }
        public async Task SaveExpiresInTokenAsync(string expiresIn)
        {
            if (!string.IsNullOrEmpty(expiresIn))
            {
                await PLocalStorage.SetAsync(ConstantsApp.EXPIRES_IN_TOKEN, expiresIn);
                //await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", ConstantsApp.EXPIRES_IN_TOKEN, expiresIn);
            }
           
        }
        public async Task SaveTokenTypeAsync(string tokenType)
        {
            if (!string.IsNullOrEmpty(tokenType))
            {
                await PLocalStorage.SetAsync(ConstantsApp.TOKEN_TYPE, tokenType);
                //await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", ConstantsApp.TOKEN_TYPE, tokenType);
            }
 
        }
        public async Task SaveLoginTypeAsync(LoginType type)
        {
            await PLocalStorage.SetAsync(ConstantsApp.LOGIN_TYPE, type.ToString());

            //await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", ConstantsApp.LOGIN_TYPE, type.ToString());
        }
        public async Task DeleteLoginTypeAsync()
        {
            try
            {
                await PLocalStorage.DeleteAsync(ConstantsApp.LOGIN_TYPE);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
            //await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", ConstantsApp.LOGIN_TYPE);
        }
        public async Task<string> GetLoginTypeAsync()
        {
            try
            {
                return (await PLocalStorage.GetAsync<string>(ConstantsApp.LOGIN_TYPE)).Value ?? "";

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }
            //return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", ConstantsApp.LOGIN_TYPE) ?? LoginType.Email.ToString();
        }
        public async Task<string?> GetTokenAsync()
        {
            try
            {
                return (await PLocalStorage.GetAsync<string>(ConstantsApp.ACCESS_TOKEN)).Value ?? "";

            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }
            //return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", ConstantsApp.ACCESS_TOKEN)??"";
        }  
        

        public async Task<string?> GetRefreshTokenAsync()
        {
            try
            {
                return (await PLocalStorage.GetAsync<string>(ConstantsApp.REFRESH_TOKEN)).Value ?? "";

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }
            //return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", ConstantsApp.REFRESH_TOKEN) ?? "";
        }
        public async Task<string> GetExpiresInTokenAsync()
        {
            try
            {
                return (await PLocalStorage.GetAsync<string>(ConstantsApp.EXPIRES_IN_TOKEN)).Value ?? "";

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }
            //return (await PLocalStorage.GetAsync<string>(ConstantsApp.EXPIRES_IN_TOKEN)).Value ?? "";
            //return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", ConstantsApp.EXPIRES_IN_TOKEN);
        }
        public async Task<string> GetTokenTypeAsync()
        {
            try
            {
                return (await PLocalStorage.GetAsync<string>(ConstantsApp.TOKEN_TYPE)).Value ?? "";

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }

            //return (await PLocalStorage.GetAsync<string>(ConstantsApp.TOKEN_TYPE)).Value ?? "";
            //return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", ConstantsApp.TOKEN_TYPE);
        }

        public async Task SaveAllTokensAsync(string accessToken, string refreshToken,
            string expiresInToken, string tokenType)
        {

            //if (!string.IsNullOrEmpty(accessToken))
            //{
            //    await SaveTempTokenAsync(accessToken);
            //}


            await SaveTokenAsync(accessToken);
             
            await SaveRefreshTokenAsync(refreshToken);
             
            await SaveExpiresInTokenAsync(expiresInToken);

            await SaveTokenTypeAsync(tokenType);
            
        
          
           
          
        }

        public async Task RemoveTokenAsync()
        {
            
            try
            {
                await PLocalStorage.DeleteAsync(ConstantsApp.ACCESS_TOKEN);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //await _jsRuntime.InvokeVoidAsync("localStorageHelper.removeItem", ConstantsApp.ACCESS_TOKEN);
        }
        public async Task DeleteTokenFromSessionAsync()
        {
            try
            {
                await PSession.DeleteAsync(ConstantsApp.ACCESS_TOKEN);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public string? GetToken()
        {
            try 
            { 
                var httpContext = _httpContextAccessor.HttpContext;

                if (httpContext != null && httpContext.Request.Cookies.TryGetValue(ConstantsApp.ACCESS_TOKEN, out var token))
                {
                    return token;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }
        public string? GetRefreshToken()
        {
            try 
            { 
                var httpContext = _httpContextAccessor.HttpContext;

                if (httpContext != null && httpContext.Request.Cookies.TryGetValue(ConstantsApp.REFRESH_TOKEN, out var refresh_token))
                {
                    return refresh_token;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public string? GetLoginType()
        {
            try
            {
                var httpContext = _httpContextAccessor.HttpContext;

                if (httpContext != null && httpContext.Request.Cookies.TryGetValue(ConstantsApp.REFRESH_TOKEN, out var loginType))
                {
                    return loginType;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }
        public void DeleteToken() {
         
            try
            {
                _httpContextAccessor.HttpContext.Response.Cookies.Delete(ConstantsApp.ACCESS_TOKEN);

            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }   
        
        public void DeleteRefreshToken() {
            try
            {
                _httpContextAccessor.HttpContext.Response.Cookies.Delete(ConstantsApp.REFRESH_TOKEN);

            }catch(Exception e) { Console.WriteLine(e.Message); }
        }
        public void SetRefreshToken(string token)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Append(
                   ConstantsApp.REFRESH_TOKEN,  // اسم الكوكي
                   token,        // التوكن
                   new CookieOptions
                   {
                       HttpOnly = true,  // جعل الكوكيز غير قابلة للوصول عبر JavaScript
                       Secure = false,    // إرسال الكوكيز فقط عبر HTTPS
                       Expires = DateTimeOffset.UtcNow.AddDays(30),  // مدة صلاحية الكوكي
                       SameSite = SameSiteMode.Strict,  // حماية ضد هجمات CSRF

                   }
               );
        }
        public void SetToken(string token)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Append(
                   ConstantsApp.ACCESS_TOKEN,  // اسم الكوكي
                   token,        // التوكن
                   new CookieOptions
                   {
                       HttpOnly = true,  // جعل الكوكيز غير قابلة للوصول عبر JavaScript
                       Secure = false,    // إرسال الكوكيز فقط عبر HTTPS
                       Expires = DateTimeOffset.UtcNow.AddDays(30),  // مدة صلاحية الكوكي
                       SameSite = SameSiteMode.Strict,  // حماية ضد هجمات CSRF

                   }
               );
        }
        public async Task RemoveCookiesAsync()
        {
            try
            {
                await _jsRuntime.InvokeVoidAsync("deleteCookie", ConstantsApp.ACCESS_TOKEN);
            }
            catch (Exception e) { 

              Console.WriteLine(e.Message);
            }
        }
        public async Task RemoveAllTokensAsync()
        {
            try
            {
                await PLocalStorage.DeleteAsync(ConstantsApp.ACCESS_TOKEN);
                await PLocalStorage.DeleteAsync(ConstantsApp.REFRESH_TOKEN);
                await PLocalStorage.DeleteAsync(ConstantsApp.EXPIRES_IN_TOKEN);
                await PLocalStorage.DeleteAsync(ConstantsApp.TOKEN_TYPE);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Task DeleteTokenAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteRefreshTokenAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteTokenTypeAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteExpiresInTokenAsync()
        {
            throw new NotImplementedException();
        }

      

    }
}
