using Microsoft.Extensions.DependencyInjection;
using Shared.Enums;
using Shared.Settings;

namespace Shared
{

    public interface ISharedLayerMarker { }
    public static class SharedConfigServices
    {
        public static void InstallSharedConfigServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(_ => ApplicationModeService.getInstance(ApplicationMode.Production));
        }
    }
}
