


using Infrastructure.Models.Plans;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Nswag;
using AutoMapper;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
 using Shared.Wrapper;


using LoginRequest = Infrastructure.Nswag.LoginRequest;
using Domain.ShareData.Base.Auth;
using ResetPasswordRequest = Infrastructure.Nswag.ResetPasswordRequest;
using RegisterRequest = Infrastructure.Nswag.RegisterRequest;
using Infrastructure.Models.Auth.Response;
using Domain.Entities;
using Infrastructure.DataSource.ApiClient.Base;
using Infrastructure.Middlewares;
using Infrastructure.Share.Invoker;


//using Microsoft.AspNetCore.Http;

namespace Infrastructure.DataSource.ApiClient.Auth
{

    public class AuthApiClient: BuildApiClient<AuthClient>
    {


        public AuthApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, IApiInvoker apiSafelyHandler)
            :base(clientFactory,mapper,config,apiSafelyHandler)
        {
       
        }

        //private  async Task<AuthClient> GetApiClient()
        //{

        //    var client = await _clientFactory.CreateClientAsync<AuthClient>("ApiClient");
        //    return client;
        //}

        //private async Task<AuthClient> GetApiClientWithAuth()
        //{

        //    var client = await _clientFactory.CreateClientWithAuthAsync<AuthClient>("ApiClient");
        //    return client;
        //}
        /// TODO : link to Api
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<Result<ForgetPasswordResponseModel>> forgetPasswordAsync(ForgetPasswordRequestModel requestModel)
        {
            try
            {   
                var model = _mapper.Map<ForgotPasswordRequest>(requestModel);
                var client = await GetApiClient();
                await client.ForgotPasswordAsync(model);
                //var response=
                //var res= _mapper.Map<ForgetPasswordResponseModel>(response);
                return Result<ForgetPasswordResponseModel>.Success();
            }
            catch (ApiException ex)
            {
                return Result<ForgetPasswordResponseModel>.Fail(ex.Message);
            }
            catch (Exception ex)
            {
                return Result<ForgetPasswordResponseModel>.Fail(ex.Message);
            }
        }
        public async Task<Result<LoginResponseModel>> loginAsync(LoginRequestModel request)
        {
            try
            {
                var model = _mapper.Map<LoginRequest>(request);
                var client = await GetApiClient();
                var response =await client.LoginAsync(false,false,model);
                var resModel = _mapper.Map<LoginResponseModel>(response);
                return Result<LoginResponseModel>.Success(resModel);

            }catch(ApiException e)
            {

                return Result<LoginResponseModel>.Fail(e.Message);
               
            }
  

        }
        public async Task ExternalLoginAsync(ExternalLoginRequest request)
        {
          
                
                var client = await GetApiClient();
            //await client.ExternalLoginAsync(request.Provider, request.ReturnUrl);

           await Task.CompletedTask;
        }
        public  async  Task<Result<string>> reSendConfirmationEmailAsync(ResendConfirmationEmailModel request)
        {
            try
            {
                var model = _mapper.Map<ResendConfirmationEmailRequest>(request);
               
                var client = await GetApiClient();
                await client.ResendConfirmationEmailAsync(model);
              
                return Result<string>.Success();

            }catch(ApiException e)
            {

                return Result<string>.Fail(e.Response,httpCode:e.StatusCode);
               
            }
   
        }

        public async Task<Result<string>> confirmationEmailAsync(ConfirmationEmailModel request)
        {
            try
            {
                var model = _mapper.Map<ResendConfirmationEmailRequest>(request);
                var client = await GetApiClient();
                await client.ResendConfirmationEmailAsync(model);

                return Result<string>.Success();

            }
            catch (ApiException e)
            {

                return Result<string>.Fail(e.Response, httpCode: e.StatusCode);

            }


        }

        public async Task<Result<RegisterResponseModel>> registerAsync(RegisterRequestModel request)
        {
            try
            {
                var model = _mapper.Map<RegisterRequest>(request);
                if (model.ReturnUrl==null)
                    model.ReturnUrl = "https://asg.tryasp.net/swagger/index.html"; 

                var client = await GetApiClient();
               await client.RegisterAsync(model);

                return Result<RegisterResponseModel>.Success();
      

            }
            catch (ApiException e)
            {

                return Result<RegisterResponseModel>.Fail(e.Message);

            }
            //var token = response.AccessToken;


        }


        public async Task<Result<string>> logoutAsync()
        {
            try
            {
                var client = await GetApiClient();
                await client.LogoutAsync("");
                return Result<string>.Success();
            }
            catch (ApiException ex)
            {
                return Result<string>.Fail(ex.Message);
            }
            catch (Exception ex)
            {
                return Result<string>.Fail(ex.Message);
            }

        }

        public async Task<Result<AccessTokenResponseModel>> refreshTokinAsync(RefreshRequestModel request)
        {

            try
            {
                //var model = _mapper.Map<RefreshRequest>(request);
            
                var client = await GetApiClient();
                //var response=  await client.RefreshAsync(model);

                //return Result<AccessTokenResponseModel>.Success(_mapper.Map<AccessTokenResponseModel>(response));
                return Result<AccessTokenResponseModel>.Success();
            }
            catch (ApiException ex)
            {
                return Result<AccessTokenResponseModel>.Fail(ex.Message);
            }
            catch (Exception ex)
            {
                return Result<AccessTokenResponseModel>.Fail(ex.Message);
            }

        }


        public async Task<Result<ResetPasswordResponseModel>> resetPasswordAsync(ResetPasswordRequestModel request)
        {

            try
            {
                var model = _mapper.Map<ResetPasswordRequest>(request);
                var client = await GetApiClient();
                await client.ResetPasswordAsync(model);

                return Result<ResetPasswordResponseModel>.Success();
            }
            catch (ApiException ex)
            {
                return Result<ResetPasswordResponseModel>.Fail(ex.Message);
            }
            catch (Exception ex)
            {
                return Result<ResetPasswordResponseModel>.Fail(ex.Message);
            }

        }





        public string GenerateJwtToken(string serverToken, string role="")
        {
            var claims = new[]
            {
            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub,"LahagaWebSiteAccessToken"),
            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
            new Claim("ServerToken", serverToken),
            //new Claim(ClaimTypes.Role, role)
        };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("LahagaWebSiteApp63727&^%$@#@8gdsdgsug"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                     issuer: "LahagaWebSiteApp",
                audience: "LahagaWebSiteAPIClient",
                claims: claims,
                expires: DateTime.UtcNow.AddMonths(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
        public async Task SaveLoginUser(string token,string role = "User") {


            var claims = new List<Claim>
                            {
                                new Claim("accessToken" ,  token),
                                new Claim("accessTokenHash" ,  ""),
                                new Claim("RefreshToken" ,  ""),
                                new Claim("email",""),
                                new Claim("id",""),
                                new Claim("role",role),

                            };
            var userIdentity = new ClaimsIdentity(claims, "Bearer");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            // قم بتسجيل المستخدم في الجلسة
            //await Microsoft.AspNetCore.Http.HttpContext.  SignInAsync(principal);
        }
        public string EncryptToken(string serverToken,string role="User")
        {
            // Step 1: Create claims including the server token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]??""),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                new Claim("ServerToken", serverToken), // Adding the server token as a claim
                new Claim(ClaimTypes.Role, role)

                //new Claim(JwtClaimTypes.Id, user.Id),
                //new Claim(JwtClaimTypes.Email, user?.Email??""),
                //new Claim(JwtClaimTypes.Role,(await _userManager.GetRolesAsync(user)).FirstOrDefault()??""),
            };

            // Step 2: Create the signing key and credentials
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? ""));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Step 3: Create the JWT token
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMonths(1),
                signingCredentials: credentials
            );

          


            // Step 4: Write and return the signed JWT token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

      


    }



}
