
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Auth.Request;
using Domain.Entities.Auth.Response;
using Domain.Repository.Auth;
using Domain.ShareData.Base;
using Domain.ShareData.Base.Auth;
 using Shared.Wrapper;
using Infrastructure.DataSource;
using Infrastructure.DataSource.ApiClient.Auth;
using Infrastructure.DataSource.Seeds;
using Infrastructure.Models.Auth.Response;
using Infrastructure.Models.Plans;
using Shared.Settings;
using System.Reflection;

namespace Infrastructure.Repository.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly SeedsUsers seedsUsers;
        private readonly AuthControl authControl;
        private readonly AuthApiClient authApiClient;
        private readonly IMapper _mapper;
        private readonly ApplicationModeService appModeService;
        public AuthRepository(
            IMapper mapper,
            ApplicationModeService appModeService,
            AuthControl authControl,
            AuthApiClient authApiClient,
            SeedsUsers seedsUsers)
        {

            _mapper = mapper;
            this.appModeService = appModeService;
            this.authControl = authControl;
            this.authApiClient = authApiClient;
            this.seedsUsers = seedsUsers;
        }

   
        public async Task<Result<ForgetPasswordResponse>> forgetPasswordAsync(ForgetPasswordRequest request)
        {

            var model = _mapper.Map<ForgetPasswordRequestModel>(request);
            var response = await authControl.forgetPasswordAsync(model);

            if (response.Succeeded)
            {
                var res = _mapper.Map<ForgetPasswordResponse>(response.Data);

                return Result<ForgetPasswordResponse>.Success(res);

            }
            else
            {
                return Result<ForgetPasswordResponse>.Fail(response.Messages);
            }
         


        }
        public async Task ExternalLoginAsync(ExternalLoginRequest request)
        {
            await authControl.ExternalLoginAsync(request);
        }


        public async Task<Result<LoginResponse>> loginAsync(LoginRequest request)
        {

            var model = _mapper.Map<LoginRequestModel>(request);

            var response = await authControl.loginAsync(model);

            if (response.Succeeded)
            {
                var res = _mapper.Map<LoginResponse>(response.Data);

                return Result<LoginResponse>.Success(res);
               
            }
            else
            {
                return Result<LoginResponse>.Fail(response.Messages);
            }


        }
             public async Task<Result<RegisterResponse>> registerAsync(RegisterRequest request)
            {
                    var model = _mapper.Map<RegisterRequestModel>(request);

                    var response=await authControl.registerAsync(model);

                    //return _mapper.Map<RegisterResponse>(response);

                    if (response.Succeeded)
                    {
                        var res = _mapper.Map<RegisterResponse>(response.Data);
                        return Result<RegisterResponse>.Success(res);
       
                    }
                    else
                    {
                        return Result<RegisterResponse>.Fail(response.Messages);
                    }


        }

        public async Task<Result<string>> logoutAsync()
        {

           return await authControl.logoutAsync();

        }

        public async Task<Result<AccessTokenResponse>> RefreshTokenAsync(RefreshRequest request)
        {
            var model = _mapper.Map<RefreshRequestModel>(request);
            var response = await authControl.RefreshTokenAsync(model);

            if (response.Succeeded)
            {
                var res = _mapper.Map<AccessTokenResponse>(response.Data);
                return Result<AccessTokenResponse>.Success(res);

            }
            else
            {
                return Result<AccessTokenResponse>.Fail(response.Messages);
            }

        }

 

        public async Task<Result<string>> confirmationEmailAsync(ConfirmationEmail request)
        {

            var model = _mapper.Map<ConfirmationEmailModel>(request);
            return await authControl.confirmationEmailAsync(model);

         
        }

        public async Task<Result<string>> reSendConfirmationEmailAsync(ResendConfirmationEmail request)
        {

            var model = _mapper.Map<ResendConfirmationEmailModel>(request);
            return await authControl.reSendConfirmationEmailAsync(model);



        }
        public async Task<Result<ResetPasswordResponse>> resetPasswordAsync(ResetPasswordRequest request)
        {

            var model = _mapper.Map<ResetPasswordRequestModel>(request);
            var response = await authControl.resetPasswordAsync(model);

            if (response.Succeeded)
            {
                var res = _mapper.Map<ResetPasswordResponse>(response.Data);
                return Result<ResetPasswordResponse>.Success(res);

            }
            else
            {
                return Result<ResetPasswordResponse>.Fail(response.Messages);
            }

        }

  
    }
}
