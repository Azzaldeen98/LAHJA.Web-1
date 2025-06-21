using Infrastructure.DataSource.ApiClientFactory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure
{
    public static class ApiClientFactoryConfigServices
    {
        public static void InstallConfiguration(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<ClientFactory>();
        }
    }
}
