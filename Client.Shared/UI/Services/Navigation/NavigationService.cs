using Microsoft.AspNetCore.Components;
using Shared.Interfaces;

namespace Client.Shared.UI.Services.Navigation
{
    public interface INavigationService:ITScope
    {
        void GoTo(string url, Dictionary<string, object>? parameters = null, bool forceReload = false);
    }

    public class NavigationService : INavigationService
    {
        private readonly NavigationManager _navigationManager;

        public NavigationService(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public void GoTo(string url, Dictionary<string, object>? parameters = null, bool forceReload = false)
        {
            if (parameters != null && parameters.Any())
            {
                var queryString = string.Join("&", parameters
                    .Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value?.ToString() ?? string.Empty)}"));

                url = $"{url}?{queryString}";
            }


            _navigationManager.NavigateTo(url, forceReload);
        }
    }
}
