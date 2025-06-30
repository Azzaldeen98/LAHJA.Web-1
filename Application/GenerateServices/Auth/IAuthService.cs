
using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.Services;


public interface IAuthService :  ITBaseShareService  
{

    public Task confirmationEmailAuthAsync(ConfirmEmail body, CancellationToken cancellationToken);


    public Task forgotPasswordAuthAsync(ForgetPassword body, CancellationToken cancellationToken);


    public Task<AccessToken> loginAuthAsync(Login body, CancellationToken cancellationToken);


    public Task logoutAuthAsync(object body, CancellationToken cancellationToken);


    public Task registerAuthAsync(Register body, CancellationToken cancellationToken);


    public Task<string> resendConfirmationEmailAuthAsync(ResendConfirmationEmail body, CancellationToken cancellationToken);


    public Task resetPasswordAuthAsync(ResetPassword body, CancellationToken cancellationToken);




}

