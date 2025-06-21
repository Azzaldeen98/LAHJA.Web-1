using Client.Shared.Helpers;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Client.Shared.Providers
{
    public  class ResourceProvider
    {

        //private static ResourceProvider _instance;
        private static Assembly _assembly;


        private  CustomStringLocalizer authResource;// = new CustomStringLocalizer("LAHJA.Resources.Messages.Errors.AuthMessages");
        //private static readonly ResourceManager ValidationResource = new ResourceManager("Resources.ValidationMessages", typeof(ResourceProvider).Assembly);
        //private static readonly ResourceManager ServerResource = new ResourceManager("Resources.ServerMessages", typeof(ResourceProvider).Assembly);

        public  ResourceProvider(Assembly assembly=null)
        {

                _assembly = assembly;
                //_instance = new ResourceProvider();
            
            //return _instance;
        }

        public  string GetResourcePath(string file_path)
        {
            return $"Client.Shared.Resources.{file_path}";
        }


        public  string GetAuthMessage(string key)
        {
            if(authResource==null)
                authResource = new CustomStringLocalizer(GetResourcePath("Messages.Errors.AuthMessages"), Assembly.GetExecutingAssembly());
            return authResource.GetLocalizedString(key);
        }

        //public static string GetValidationMessage(string key)
        //{
        //    return GetValue(ValidationResource, key);
        //}

        //public static string GetServerMessage(string key)
        //{
        //    return GetValue(ServerResource, key);
        //}

        private static string GetValue(ResourceManager manager, string key)
        {
            try
            {
                var value = manager.GetString(key, CultureInfo.CurrentUICulture);
                return value ?? $"[Missing resource: {key}]";
            }
            catch
            {
                return $"[Error reading resource: {key}]";
            }
        }
    }
}
