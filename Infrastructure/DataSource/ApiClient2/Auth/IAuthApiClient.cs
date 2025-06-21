using Infrastructure.Nswag;
using Shared.Interfaces;
namespace Infrastructure.DataSource.ApiClient2;


public interface IAuthApiClient : ITBaseShareApiClient 
{
    public Task RegisterAsync(RegisterRequest body, CancellationToken cancellationToken);

    public Task<AccessTokenResponse> LoginAsync(bool? useCookies, bool? useSessionCookies, LoginRequest body, CancellationToken cancellationToken);

    public Task CustomMapIdentityApiApi_confirmEmailAsync(ConfirmEmailRequest body, CancellationToken cancellationToken);

    public Task<string> ResendConfirmationEmailAsync(ResendConfirmationEmailRequest body, CancellationToken cancellationToken);

    public Task ForgotPasswordAsync(ForgotPasswordRequest body, CancellationToken cancellationToken);

    public Task ResetPasswordAsync(ResetPasswordRequest body, CancellationToken cancellationToken);

    public Task LogoutAsync(object body, CancellationToken cancellationToken);

}

