using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;

namespace LAHAJ.Helpers
{





    public static class NavigationHelper
    {
        private static IServiceProvider _serviceProvider;

        public static void Init(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static void To(string url,bool reload=true)
        {
            var navigationManager = _serviceProvider.GetRequiredService<NavigationManager>();
            navigationManager.NavigateTo(url, reload);
        }
    }

}