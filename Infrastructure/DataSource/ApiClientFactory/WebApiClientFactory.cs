using Shared.Helpers;
using System.Net.Http.Headers;

namespace Infrastructure.DataSource.ApiClientFactory
{

    public interface IWebApiClientFactory
    {
        Task<HttpClient> GetClientAsync();
        Task<HttpClient> GetClientWithAuthAsync();

    }






    public class WebApiClientFactory : IWebApiClientFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly IUserClaimsHelper userClaimsHelper;

        public WebApiClientFactory(IHttpClientFactory httpClientFactory, IUserClaimsHelper userClaimsHelper)
        {
            _httpClientFactory = httpClientFactory;
            this.userClaimsHelper = userClaimsHelper;

            // _token = token;

        }



        public async Task<HttpClient> GetClientWithAuthAsync()
        {
            if (userClaimsHelper.AccessToken == null)
                throw new Exception("failed Access to remote");

            var httpClient = _httpClientFactory.CreateClient("LocalApi");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userClaimsHelper.AccessToken);

            //httpClient.BaseAddress = new Uri(baseUrl.Api);
            //  string bearerToken = _token.AccessToken;
            //  if (!string.IsNullOrEmpty(bearerToken)) httpClient.SetBearerToken(bearerToken);

            return httpClient;

        }
        public async Task<HttpClient> GetClientAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("LocalApi");
          

            //httpClient.BaseAddress = new Uri(baseUrl.Api);
            //  string bearerToken = _token.AccessToken;
            //  if (!string.IsNullOrEmpty(bearerToken)) httpClient.SetBearerToken(bearerToken);

            return httpClient;

        }

   
    }


    

}
