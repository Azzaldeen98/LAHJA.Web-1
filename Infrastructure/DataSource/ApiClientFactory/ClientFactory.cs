using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Shared.Constants;
using Shared.Exceptions;
using Shared.Helpers;
using System.Net.Http.Headers;

namespace Infrastructure.DataSource.ApiClientFactory
{

    


    public class ClientFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
 
        private readonly ITokenService tokenService;
        //private readonly IUserClaimsHelper userClaimsHelper;

        public ClientFactory(IHttpClientFactory httpClientFactory,
          IUserClaimsHelper userClaimsHelper, ITokenService tokenService, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory), "HttpClientFactory cannot be null.");
           
            //this.userClaimsHelper = userClaimsHelper;
            this.tokenService = tokenService;
            _httpContextAccessor = httpContextAccessor;
        }




        public Task<string?> GetTokenAsync()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext != null && httpContext.Request.Cookies.TryGetValue(ConstantsApp.ACCESS_TOKEN, out var token))
            {
                return Task.FromResult<string?>(token);
            }

            return Task.FromResult<string?>(null);
        }

        public async Task<TClient> CreateClientWithAuthAsync<TClient>(string clientName = ConstantsAPI.API_CLIENT_NAME, string token2 = "") where TClient : class
        {

            if (string.IsNullOrWhiteSpace(clientName))
            {
                throw new ArgumentException("Client name cannot be null, empty or whitespace.", nameof(clientName));
            }

            try
            {

                var token = ""; 
                try
                {
                    token = tokenService.GetToken();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }

                var httpClient = _httpClientFactory.CreateClient(clientName);

                if (!string.IsNullOrEmpty(token) && token != "$$$$") //token.Length>=255
                    httpClient.SetBearerToken(token);
   


                if (Activator.CreateInstance(typeof(TClient), httpClient) is TClient client)
                {
                    return client;
                }
                else
                {
                    throw new InvalidOperationException($"Could not create an instance of {typeof(TClient).Name}. Make sure the constructor is correct.");
                }
            }
            catch (ArgumentException ex)
            {

                throw new InvalidOperationException("Invalid argument provided to create the client.", ex);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException($"An error occurred while creating the client: {ex.Message}", ex);
            }
        }
        public async Task<TClient> CreateClientWithAuthAsync2<TClient>(string clientName = "ApiClient",string token2="") where TClient : class
        {




            if (string.IsNullOrWhiteSpace(clientName))
            {
                throw new ArgumentException("Client name cannot be null, empty or whitespace.", nameof(clientName));
            }
            var token = "";
            try
            {
                token = await tokenService.GetTokenFromSessionAsync();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                if (string.IsNullOrEmpty(token))
                {
                    token = await tokenService.GetTokenAsync();
                }
            }

            try
            {

          

                //var token = await GetTokenAsync();


                if (string.IsNullOrEmpty(token) || token=="$$$$")
                    throw new UnauthorizedException("invalid token!!");

                var httpClient = _httpClientFactory.CreateClient(clientName);
          

                 httpClient.SetBearerToken(token);

                if (Activator.CreateInstance(typeof(TClient), httpClient) is TClient client)
                {
                    return client;
                }
                else
                {
                    throw new InvalidOperationException($"Could not create an instance of {typeof(TClient).Name}. Make sure the constructor is correct.");
                }
            }
            catch (ArgumentException ex)
            {

                throw new InvalidOperationException("Invalid argument provided to create the client.", ex);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException($"An error occurred while creating the client: {ex.Message}", ex);
            }
        }
        public async Task<TClient> CreateClientAsync<TClient>(string clientName="ApiClient") where TClient : class
        {

          


            if (string.IsNullOrWhiteSpace(clientName))
            {
                throw new ArgumentException("Client name cannot be null, empty or whitespace.", nameof(clientName));
            }

            try
            {

                var httpClient = _httpClientFactory.CreateClient(clientName);
                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userClaimsHelper.AccessToken);


                if (Activator.CreateInstance(typeof(TClient), httpClient) is TClient client)
                {
                    return client;
                }
                else
                {
                    throw new InvalidOperationException($"Could not create an instance of {typeof(TClient).Name}. Make sure the constructor is correct.");
                }
            }
            catch (ArgumentException ex)
            {

                throw new InvalidOperationException("Invalid argument provided to create the client.", ex);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException($"An error occurred while creating the client: {ex.Message}", ex);
            }
        }
       
    }
}