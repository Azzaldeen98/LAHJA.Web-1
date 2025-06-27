
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Infrastructure.Share.Invoker;
using AutoMapper;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Share.Invoker;
using Microsoft.Extensions.Configuration;
using Shared.Exceptions;
namespace Infrastructure.DataSource.ApiClient2;


 public  class AuthApiClient : BuildApiClient<AuthClient>  , IAuthApiClient {

  
    public AuthApiClient(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                

    public   async Task RegisterAsync(RegisterRequest body, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.RegisterAsync(body, cancellationToken);
        });
                
    }


    public async Task<AccessTokenResponse> LoginAsync(bool? useCookies, bool? useSessionCookies, LoginRequest body, CancellationToken cancellationToken)
    {
        try
        {
            return await apiInvoker.InvokeAsync(async () =>
            {
                var client = await GetApiClient();
                return await client.LoginAsync(useCookies, useSessionCookies, body, cancellationToken);
            });
        }
        catch (UnauthorizedException ex)
        {
            // Handle specific exceptions if needed
            throw new InvalidCredentialsException("An error occurred while logging in.", ex);

        }
    }


    public   async Task ConfirmEmailAsync(ConfirmEmailRequest body, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.CustomMapIdentityApiApi_confirmEmailAsync(body, cancellationToken);
        });
                
    }


    public   async Task<string> ResendConfirmationEmailAsync(ResendConfirmationEmailRequest body, CancellationToken cancellationToken)
    {
    
         return   await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
             var str=    await client.ResendConfirmationEmailAsync(body, cancellationToken);
             return str;
        });
                
    }


    public   async Task ForgotPasswordAsync(ForgotPasswordRequest body, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.ForgotPasswordAsync(body, cancellationToken);
        });
                
    }


    public   async Task ResetPasswordAsync(ResetPasswordRequest body, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.ResetPasswordAsync(body, cancellationToken);
        });
                
    }


    public   async Task LogoutAsync(object body, CancellationToken cancellationToken)
    {
    
         await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
              await client.LogoutAsync(body, cancellationToken);
        });
                
    }


}

