using Application.UseCase.Plans;
using Domain.Entities.Plans;
using Infrastructure.Models.Plans;
 using Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Auth.Response;
using Domain.Entities.Auth.Request;
using Application.UseCase.Auth;
using Domain.ShareData.Base;
using Application.UseCase;
using Domain.Entities;

namespace Application.Service.Auth
{
    public class WebAuthService
    {
        private readonly LoginUseCase loginUseCase;
        private readonly RegisterUseCase registerUseCase;
        private readonly ForgetPasswordUseCase forgetPasswordUseCase;
        private readonly RefreshTokinUseCase refreshTokinUseCase;
        private readonly ReSendConfirmationEmailUseCase reSendConfirmationEmailUseCase;
        private readonly ResetPasswordUseCase resetPasswordUseCase;
        private readonly ConfirmationEmailUseCase confirmationEmailUseCase;
        private readonly LogoutUseCase logoutUseCase;
        private readonly ExternalLoginUseCase externalLoginUseCase;

        public WebAuthService(

                    LoginUseCase loginUseCase,
                    RegisterUseCase registerUseCase,
                    ForgetPasswordUseCase forgetPasswordUseCase,
                    RefreshTokinUseCase refreshTokinUseCase,
                    ResetPasswordUseCase resetPasswordUseCase,
                    ConfirmationEmailUseCase confirmationEmailUseCase,
                    LogoutUseCase logoutUseCase,
                    ReSendConfirmationEmailUseCase reSendConfirmationEmailUseCase,
                    ExternalLoginUseCase externalLoginUseCase)
        {


            this.loginUseCase = loginUseCase;
            this.registerUseCase = registerUseCase;
            this.forgetPasswordUseCase = forgetPasswordUseCase;
            this.refreshTokinUseCase = refreshTokinUseCase;
            this.resetPasswordUseCase = resetPasswordUseCase;
            this.confirmationEmailUseCase = confirmationEmailUseCase;
            this.logoutUseCase = logoutUseCase;
            this.reSendConfirmationEmailUseCase = reSendConfirmationEmailUseCase;
            this.externalLoginUseCase = externalLoginUseCase;
        }

        public async Task<Result<LoginResponse>> loginAsync(LoginRequest request)
        {
            return await loginUseCase.ExecuteAsync(request);

        }    
        
        public async Task ExternalLoginAsync(ExternalLoginRequest request)
        {
             await externalLoginUseCase.ExecuteAsync(request);

        }

        public async Task<Result<RegisterResponse>> registerAsync(RegisterRequest request)
        {
            return await registerUseCase.ExecuteAsync(request);
                
           
        }

        public async Task<Result<string>> logoutAsync()
        {

            return await logoutUseCase.ExecuteAsync();

        }

        public async Task<Result<AccessTokenResponse>> RefreshToken(RefreshRequest request)
        {

            return await refreshTokinUseCase.ExecuteAsync(request);

        }

   


        public async Task<Result<ForgetPasswordResponse>> forgetPasswordAsync(ForgetPasswordRequest model)
        {
            return await forgetPasswordUseCase.ExecuteAsync(model);
                
            

        }

        public async Task<Result<string>> confirmationEmailAsync(ConfirmationEmail request)
        {
            return await confirmationEmailUseCase.ExecuteAsync(request);


        }

        public async Task<Result<string>> reSendConfirmationEmailAsync(ResendConfirmationEmail request)
        {

            return await reSendConfirmationEmailUseCase.ExecuteAsync(request);



        }
        public async Task<Result<ResetPasswordResponse>> resetPasswordAsync(ResetPasswordRequest request)
        {

            return await resetPasswordUseCase.ExecuteAsync(request);

        }

   

    }
}
