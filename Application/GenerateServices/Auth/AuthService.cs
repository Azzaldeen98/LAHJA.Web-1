
using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.Services;


public class AuthService : IAuthService {


        
     private readonly ConfirmationEmailAuthUseCase _confirmEmailAuthUseCase;
     private readonly ForgotPasswordAuthUseCase _forgotPasswordAuthUseCase;
     private readonly LoginAuthUseCase _loginAuthUseCase;
     private readonly LogoutAuthUseCase _logoutAuthUseCase;
     private readonly RegisterAuthUseCase _registerAuthUseCase;
     private readonly ResendConfirmationEmailAuthUseCase _resendConfirmationEmailAuthUseCase;
     private readonly ResetPasswordAuthUseCase _resetPasswordAuthUseCase;


    public AuthService(
            ConfirmationEmailAuthUseCase confirmEmailAuthUseCase,
            ForgotPasswordAuthUseCase forgotPasswordAuthUseCase,
            LoginAuthUseCase loginAuthUseCase,
            LogoutAuthUseCase logoutAuthUseCase,
            RegisterAuthUseCase registerAuthUseCase,
            ResendConfirmationEmailAuthUseCase resendConfirmationEmailAuthUseCase,
            ResetPasswordAuthUseCase resetPasswordAuthUseCase)
    {
                        
          _confirmEmailAuthUseCase=confirmEmailAuthUseCase;
          _forgotPasswordAuthUseCase=forgotPasswordAuthUseCase;
          _loginAuthUseCase=loginAuthUseCase;
          _logoutAuthUseCase=logoutAuthUseCase;
          _registerAuthUseCase=registerAuthUseCase;
          _resendConfirmationEmailAuthUseCase=resendConfirmationEmailAuthUseCase;
          _resetPasswordAuthUseCase=resetPasswordAuthUseCase;


    }

                

    public async Task confirmationEmailAsync(ConfirmEmail body, CancellationToken cancellationToken)
    {
    

         await _confirmEmailAuthUseCase.ExecuteAsync(body, cancellationToken);
        
    }



    public async Task forgotPasswordAsync(ForgetPassword body, CancellationToken cancellationToken)
    {
    

         await _forgotPasswordAuthUseCase.ExecuteAsync(body, cancellationToken);
        
    }



    public async Task<AccessToken> loginAsync(Login body, CancellationToken cancellationToken)
    {
    

         return   await _loginAuthUseCase.ExecuteAsync(body, cancellationToken);
        
    }



    public async Task logoutAsync(object body, CancellationToken cancellationToken)
    {
    

         await _logoutAuthUseCase.ExecuteAsync(body, cancellationToken);
        
    }



    public async Task registerAsync(Register body, CancellationToken cancellationToken)
    {
    

         await _registerAuthUseCase.ExecuteAsync(body, cancellationToken);
        
    }



    public async Task<string> resendConfirmationEmailAsync(ResendConfirmationEmail body, CancellationToken cancellationToken)
    {
    

         return   await _resendConfirmationEmailAuthUseCase.ExecuteAsync(body, cancellationToken);
        
    }



    public async Task resetPasswordAsync(ResetPassword body, CancellationToken cancellationToken)
    {
    

         await _resetPasswordAuthUseCase.ExecuteAsync(body, cancellationToken);
        
    }





}
