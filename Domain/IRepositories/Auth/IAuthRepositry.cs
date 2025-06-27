
using AutoGenerator.Config.Attributes;
using Domain.Entity;
using Shared.Interfaces;


namespace Domain.IRepositories
{
    public interface IAuthRepository : ITBaseRepository, ITScope
    {
        public Task RegisterAsync(Register body, CancellationToken cancellationToken);

        public Task<AccessToken> LoginAsync(Login body, CancellationToken cancellationToken);

        [RouteTo("ConfirmEmailAsync")]
        public Task ConfirmationEmailAsync(ConfirmEmail body, CancellationToken cancellationToken);

        public Task<string> ResendConfirmationEmailAsync(ResendConfirmationEmail body, CancellationToken cancellationToken);

        public Task ForgotPasswordAsync(ForgetPassword body, CancellationToken cancellationToken);

        public Task ResetPasswordAsync(ResetPassword body, CancellationToken cancellationToken);

        public Task LogoutAsync(object body, CancellationToken cancellationToken);

    }
 
}
