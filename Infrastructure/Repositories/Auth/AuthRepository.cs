using Shared.Interfaces;
using Shared.Wrapper;
using AutoGenerator.Attributes;
using Domain.Entity;
using Infrastructure.Nswag;
using Domain.IRepositories;
using System.Threading.Tasks;
using Infrastructure.DataSource.ApiClient2;
using System.Collections.Generic;
using AutoMapper;

namespace Infrastructure.Repositories;
public partial class AuthRepository : IAuthRepository
{
    private readonly IAuthApiClient _apiClient;
    private readonly IMapper _mapper;
    public AuthRepository(IAuthApiClient apiClient, IMapper mapper)
    {
        _apiClient = apiClient;
        _mapper = mapper;
    }

    public async Task RegisterAsync(Register body, CancellationToken cancellationToken)
    {
        var _body = _mapper.Map<RegisterRequest>(body);
        await _apiClient.RegisterAsync(_body, cancellationToken);
    }

    public async Task<AccessToken> LoginAsync(Login body, CancellationToken cancellationToken, Boolean useCookies, Boolean useSessionCookies)
    {
        var _body = _mapper.Map<LoginRequest>(body);
        var result = await _apiClient.LoginAsync(useCookies, useSessionCookies, _body, cancellationToken);
        return _mapper.Map<AccessToken>(result);
    }

    [RouteTo("ConfirmEmailAsync")]
    public async Task ConfirmationEmailAsync(ConfirmEmail body, CancellationToken cancellationToken)
    {
        var _body = _mapper.Map<ConfirmEmailRequest>(body);
        await _apiClient.ConfirmEmailAsync(_body, cancellationToken);
    }

    public async Task<string> ResendConfirmationEmailAsync(ResendConfirmationEmail body, CancellationToken cancellationToken)
    {
        var _body = _mapper.Map<ResendConfirmationEmailRequest>(body);
        var result = await _apiClient.ResendConfirmationEmailAsync(_body, cancellationToken);
        return result;
    }

    public async Task ForgotPasswordAsync(ForgetPassword body, CancellationToken cancellationToken)
    {
        var _body = _mapper.Map<ForgotPasswordRequest>(body);
        await _apiClient.ForgotPasswordAsync(_body, cancellationToken);
    }

    public async Task ResetPasswordAsync(ResetPassword body, CancellationToken cancellationToken)
    {
        var _body = _mapper.Map<ResetPasswordRequest>(body);
        await _apiClient.ResetPasswordAsync(_body, cancellationToken);
    }

    public async Task LogoutAsync(Object body, CancellationToken cancellationToken)
    {
        await _apiClient.LogoutAsync(body, cancellationToken);
    }
}