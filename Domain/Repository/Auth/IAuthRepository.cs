using Domain.Entities;
using Domain.Entities.Auth.Request;
using Domain.Entities.Auth.Response;
using Domain.ShareData.Base;
 
using Shared.Wrapper;

namespace Domain.Repository.Auth
{
    public  interface  IAuthRepository
    {

        public Task<Result<LoginResponse>> loginAsync(LoginRequest model);
        public Task<Result<RegisterResponse>> registerAsync(RegisterRequest model);
        public Task<Result<ForgetPasswordResponse>> forgetPasswordAsync(ForgetPasswordRequest request);

        public  Task<Result<string>> logoutAsync();

        public  Task<Result<AccessTokenResponse>> RefreshTokenAsync(RefreshRequest request);


        public  Task<Result<string>> confirmationEmailAsync(ConfirmationEmail request);
        public  Task ExternalLoginAsync(ExternalLoginRequest request);

        public  Task<Result<string>> reSendConfirmationEmailAsync(ResendConfirmationEmail request);


        public  Task<Result<ResetPasswordResponse>> resetPasswordAsync(ResetPasswordRequest request);
      
    }
}
