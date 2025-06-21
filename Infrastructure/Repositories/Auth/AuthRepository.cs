
using AutoMapper;
using Shared.Settings;
using Infrastructure.DataSource.ApiClient2;
using Infrastructure.Nswag;
using Domain.Entity;
using Domain.IRepositories;


namespace Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
    
   
        private readonly IAuthApiClient apiClient;
        private readonly IMapper _mapper;
        private readonly ApplicationModeService appModeService;
        public AuthRepository(
            IMapper mapper,
            ApplicationModeService appModeService,
            IAuthApiClient apiClient)
        {

            _mapper = mapper;
            this.appModeService = appModeService;
            this.apiClient = apiClient;

        }

   
   

        public async Task RegisterAsync(Register body, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<RegisterRequest>(body);
             await apiClient.RegisterAsync(model, cancellationToken);
        }

        public async Task<AccessToken> LoginAsync(Login body, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<LoginRequest>(body);
            var response= await apiClient.LoginAsync(false,false,model, cancellationToken);
            return _mapper.Map<AccessToken>(response);
           
        }

        public async Task ConfirmationEmailAsync(ConfirmEmail body, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<ConfirmEmailRequest>(body);
             await apiClient.CustomMapIdentityApiApi_confirmEmailAsync(model, cancellationToken);
        }

        public async Task<string> ResendConfirmationEmailAsync(ResendConfirmationEmail body, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<ResendConfirmationEmailRequest>(body);
            return await apiClient.ResendConfirmationEmailAsync(model, cancellationToken);
        }

        public async Task ForgotPasswordAsync(ForgetPassword body, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<ForgotPasswordRequest>(body);
             await apiClient.ForgotPasswordAsync(model, cancellationToken);
        }

        public async Task ResetPasswordAsync(ResetPassword body, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<ResetPasswordRequest>(body);
            await apiClient.ResetPasswordAsync(model, cancellationToken);
        }

        public async Task LogoutAsync(object body, CancellationToken cancellationToken)
        {
            await apiClient.LogoutAsync(body, cancellationToken);
        }

   
    }
}
