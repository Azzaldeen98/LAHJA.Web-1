
namespace NWHttps
{

    public interface IWebApiClientFactory
    {
        Task<HttpClient> GetClientAsync();
  
    }
    //https://localhost:6002/swagger/v1/swagger.json
    //




    public class WebApiClientFactory : IWebApiClientFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;
     

   

        public WebApiClientFactory(
            IHttpClientFactory httpClientFactory
         
            )
        {
            _httpClientFactory = httpClientFactory;
           
           // _token = token;
           
        }


   
        public async Task<HttpClient> GetClientAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("LocalApi");
          
            //httpClient.BaseAddress = new Uri(_appSettings.BaseUrls.Api);
            //  string bearerToken = _token.AccessToken;
            //  if (!string.IsNullOrEmpty(bearerToken)) httpClient.SetBearerToken(bearerToken);

            return httpClient;
            
        }
     
    }
}
