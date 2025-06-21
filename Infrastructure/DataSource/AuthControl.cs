using AutoMapper;
using Domain.Entities;
using Domain.ShareData.Base.Auth;

using Shared.Wrapper;
using Infrastructure.DataSource.ApiClient.Auth;
using Infrastructure.DataSource.Seeds;
using Infrastructure.DataSource.Seeds.Models;
using Infrastructure.Models.Auth.Response;
using Infrastructure.Models.Plans;
using System.Reflection;

namespace Infrastructure.DataSource
{
	public class AuthControl
    {
        private readonly SeedsUsers seedsUsers;
        private readonly AuthApiClient authApiClient;
        private readonly IMapper _mapper;
        public AuthControl(SeedsUsers seedsUsers, IMapper mapper, AuthApiClient authApiClient)
        {
            this.seedsUsers = seedsUsers;
            _mapper = mapper;
            this.authApiClient = authApiClient;
        }
        public async Task ExternalLoginAsync(ExternalLoginRequest request)
        {
            await authApiClient.ExternalLoginAsync(request);
        }

        public async Task<Result<LoginResponseModel>> loginAsync(LoginRequestModel model)
        {

       

            var response = await ExecutorAppMode.ExecuteAsync<Result<LoginResponseModel>>(
                async () => await authApiClient.loginAsync(model),
                 async () => {
                      var user=await seedsUsers.loginAsync(model);
					 var res = _mapper.Map<LoginResponseModel>(user);
					 var resUser = await authApiClient.loginAsync(new LoginRequestModel
					 {
						 email = "azzaldeen771211417@gmail.com",
						 password = "Test@123"
					 });

            
					 if (user != null)
                      {
						 //var res= _mapper.Map<LoginResponseModel>(user);

						 //if (resUser.Succeeded)
						 //{
							// res.AccessToken = resUser.Data.AccessToken;

       //                  }
       //                  else
       //                  {
							// res.AccessToken = authApiClient.GenerateJwtToken("AZDSF!@#$%^&6756345236");
						 //}
						 

                         return Result<LoginResponseModel>.Success(res);
                      }
                     return Result<LoginResponseModel>.Fail("your email or password is wrong !!");
                 });

       

            return response;

           
        }

        public async Task<Result<ForgetPasswordResponseModel>> forgetPasswordAsync(ForgetPasswordRequestModel email)
        {

            var response = await ExecutorAppMode.ExecuteAsync<Result<ForgetPasswordResponseModel>>(
                async () =>   await authApiClient.forgetPasswordAsync(email),
                 async () => Result<ForgetPasswordResponseModel>.Success("Success !!"));


            return response;


        }
        public async Task<Result<RegisterResponseModel>> registerAsync(RegisterRequestModel model)
        {

            //var model = _mapper.Map<RegisterRequestModel>(request);
            
            //var res = await seedsUsers.createUserAsync(user);
            var response = await ExecutorAppMode.ExecuteAsync<Result<RegisterResponseModel>>(
               async () =>
               {
                   return await authApiClient.registerAsync(model);
                   //if (response == null)
                   //    return Result<RegisterResponseModel>.Fail(" ");
                   //else
                   //    return response;
               },
                async () => {
                    var user = _mapper.Map<UserApp>(model);
                    if (await seedsUsers.createUserAsync(user))
                    {
                        //var res = _mapper.Map<RegisterResponseModel>(user);
                        return Result<RegisterResponseModel>.Success();
                    }
                    return Result<RegisterResponseModel>.Fail("The email or phoneNumber is not correct !!");
                });

            return response;

            //if (!res)
            //{

            //    return null;
            //}

            //return new RegisterResponseModel();


        }

        public async Task<Result<string>> logoutAsync()
        {
           return await ExecutorAppMode.ExecuteAsync<Result<string>>(
               async () => await authApiClient.logoutAsync() ,
                async () =>  Result<string>.Success());

        }

        public async Task<Result<AccessTokenResponseModel>> RefreshTokenAsync(RefreshRequestModel request)
        {

            return await ExecutorAppMode.ExecuteAsync<Result<AccessTokenResponseModel>>(
            async () => await authApiClient.refreshTokinAsync(request),
             async () => Result<AccessTokenResponseModel>.Success());

        }



        public async Task<Result<string>> confirmationEmailAsync(ConfirmationEmailModel request)
        {
            return await ExecutorAppMode.ExecuteAsync<Result<string>>(
              async () => await authApiClient.confirmationEmailAsync(request),
               async () => Result<string>.Success());


        }

        public async Task<Result<string>> reSendConfirmationEmailAsync(ResendConfirmationEmailModel request)
        {

            return await ExecutorAppMode.ExecuteAsync<Result<string>>(
              async () => await authApiClient.reSendConfirmationEmailAsync(request),
               async () => Result<string>.Success());



        }
        public async Task<Result<ResetPasswordResponseModel>> resetPasswordAsync(ResetPasswordRequestModel request)
        {


            return await ExecutorAppMode.ExecuteAsync<Result<ResetPasswordResponseModel>>(
              async () => await authApiClient.resetPasswordAsync(request),
               async () => Result<ResetPasswordResponseModel>.Success());

        }
    }
}
