using System.Globalization;
using System.Resources;

namespace LAHJA.Helpers
{
    public class CustomStringLocalizer
    {
        private readonly ResourceManager _resourceManager;

        public CustomStringLocalizer(string resourceFilePath)
        {
            _resourceManager = new ResourceManager(resourceFilePath, typeof(Program).Assembly);
        }

        public string GetLocalizedString(string key)
        {
            return _resourceManager.GetString(key, CultureInfo.CurrentCulture);
        }
    }
}
