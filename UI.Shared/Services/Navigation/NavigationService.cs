using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Shared.Services.Navigation
{
    public interface INavigationService
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

            // هنا يمكنك إضافة أي منطق إضافي مثل تتبع التنقل أو التحقق
            _navigationManager.NavigateTo(url, forceReload);
        }
    }
}
