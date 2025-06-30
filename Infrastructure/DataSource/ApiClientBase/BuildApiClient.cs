using AutoMapper;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Share.Invoker;
using Microsoft.Extensions.Configuration;
using Shared.Constants;
using Shared.Interfaces;

namespace Infrastructure.DataSource.ApiClientBase
{

        public interface IBuildApiClient<T> : ITBaseApiClient
        {
            public Task<T> GetApiClient();
            public Task<T> GetBasicApiClient();

        }


        public class BuildApiClient<T> : IBuildApiClient<T> where T : class
        {



            protected readonly ClientFactory _clientFactory;
            protected readonly IMapper _mapper;
            protected readonly IApiInvoker apiInvoker;

            public BuildApiClient(
                            ClientFactory clientFactory,
                            IMapper mapper,
                            IApiInvoker apiInvoker)
            {
                _clientFactory = clientFactory;
                _mapper = mapper;
                this.apiInvoker = apiInvoker;
            }


            public async Task<T> GetApiClient()
            {
                var client = await _clientFactory.CreateClientWithAuthAsync<T>(ConstantsAPI.API_CLIENT_NAME);
                return client;
            }
            public async Task<T> GetBasicApiClient()
            {
                var client = await _clientFactory.CreateClientAsync<T>(ConstantsAPI.API_CLIENT_NAME);
                return client;
            }

    }
    
}
