
using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.Services;


public interface IAuthService :  ITBaseShareService  
{

    public Task confirmationEmailAsync(ConfirmEmail body, CancellationToken cancellationToken);


    public Task forgotPasswordAsync(ForgetPassword body, CancellationToken cancellationToken);


    public Task<AccessToken> loginAsync(Login body, CancellationToken cancellationToken);


    public Task logoutAsync(object body, CancellationToken cancellationToken);


    public Task registerAsync(Register body, CancellationToken cancellationToken);


    public Task<string> resendConfirmationEmailAsync(ResendConfirmationEmail body, CancellationToken cancellationToken);


    public Task resetPasswordAsync(ResetPassword body, CancellationToken cancellationToken);




}

