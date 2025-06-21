using LAHJA.Helpers.Services;
using MudBlazor;
namespace LAHJA.Helpers
{



    public class HelperThemeManager
    {
        private static SessionUserManager _sessionUserManager;

        public static void Init(SessionUserManager sessionUserManager)
        {
            if (_sessionUserManager == null)
            {
                _sessionUserManager = sessionUserManager;
            }
        }
        public static async Task<string> GetStringThemeAsync(SessionUserManager? sessionUserManager = null)
        {

            if (sessionUserManager != null)
                _sessionUserManager = sessionUserManager;

            if (_sessionUserManager != null)
                return await _sessionUserManager.GetThemeAsync();
            return  "light";
        }


        public static async Task<bool> IsDarkModeAsync()
        {
            var _isDarkMode = false;
            if (_sessionUserManager != null)
                _isDarkMode = await _sessionUserManager.GetThemeAsync() == "dark" ;
            return _isDarkMode;
        }



    }

  




}
