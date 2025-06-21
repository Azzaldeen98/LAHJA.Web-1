using AutoMapper;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Share.Invoker;
using Microsoft.Extensions.Configuration;
using Shared.Interfaces;

namespace Infrastructure.DataSource.ApiClient.Base
{


  

        public interface IBuildApiClient<T>:ITBuildApiClient {

        public string DevelopmentMessage { get; }


        public  Task<T> GetApiClient();
       
    }




    public class BuildApiClient<T>: IBuildApiClient<T> where T : class
    {

        public  string DevelopmentMessage => "The service is still under development From  Api !! ";

        protected readonly ClientFactory _clientFactory;
        protected readonly IMapper _mapper;
        protected readonly IConfiguration _config;
        protected readonly IApiInvoker apiSafelyHandler;



        public BuildApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config)
        {
            _clientFactory = clientFactory;
            _mapper = mapper;
            _config = config;
        }

        public BuildApiClient(
                        ClientFactory clientFactory,
                        IMapper mapper,
                        IConfiguration config,
                        IApiInvoker apiSafelyHandler) : this(clientFactory, mapper, config)
        {

            this.apiSafelyHandler = apiSafelyHandler;
        }

        public async Task<T> GetApiClient()
        {
            var client = await _clientFactory.CreateClientWithAuthAsync<T>("ApiClient");
            return client;
        }


        



    }
}
