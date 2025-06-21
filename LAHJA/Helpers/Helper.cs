using ApexCharts;
using LAHJA.Data.UI.Components;
using LAHJA.Data.UI.Components.Render;
using Microsoft.AspNetCore.Components;
using System.Reflection;
namespace LAHJA.Helpers
{
    public class Helper
    {
        private static NavigationManager _navigation;
        private static Helper _instance;
        public static void Init(NavigationManager navigation)
        {
            if (_navigation == null)
            {
                _navigation = navigation;
            }
        }
        public static Helper GetInstance()
        {
            if(_instance == null)
            {
                _instance = new Helper();
                
            }
               
            return _instance;
        }


        public  string GetFullPath(string urlPage)
        {
            return $"{_navigation?.BaseUri??""}{urlPage}";
        }     
        
        public static  string GetFullPath(NavigationManager _navigation,string urlPage)
        {
            return $"{_navigation?.BaseUri??""}{urlPage}";
        }

        public static string GetMaskedCVC(string cvc)
        {
            return string.IsNullOrEmpty(cvc) ? "" : new string('*', cvc.Length);
        }    
        
        public static string GetServiceSrcFrame(string urlCore,string sessionToken)
        {
            return $"{urlCore}/?token={sessionToken}";
        }

        public static  string GetServiceSrcFrame(string urlCore,string sessionToken, string lg = "ar", string theme = "light",
            string? url_redirect = null, 
            string? url_cancel = null, 
            string? data = null){

            var url = GetServiceSrcFrame(urlCore, sessionToken);
            return  GetServiceSrcFrame(url,lg,theme,url_redirect,url_cancel,data);
          
        }


        public static string GetServiceSrcFrame(string url, string lg="ar", string theme="light",
            string? url_redirect = null,
            string? url_cancel = null,
            string? data = null){

            var srcIframe = $"{url}{(url.Contains("/?")?'&':'?')}__theme={theme}&lg={lg}";

            if (!string.IsNullOrEmpty(url_redirect))
                srcIframe += $"&url_redirect={url_redirect}";
            if (!string.IsNullOrEmpty(url_cancel))
                srcIframe += $"&url_cancel={url_cancel}";
            if (!string.IsNullOrEmpty(data))
                srcIframe += $"&data={data}";
       

            return srcIframe;
        }
        public static bool PageNeedAuthentication(string url)
        {
           var urlPage= url.Replace(_navigation.BaseUri, "");
            var protectedRoutes = new List<string> { "dashboard", "profile", "settings",
                "services","studio","trainingModel","billing","logout" };

            return protectedRoutes.Any(route => urlPage.StartsWith(route));
        }

        public static object MapDataComponentRender<S,D>(S src, D dest, object destMember)
        {
            // إذا كانت الخاصية من النوع ICellRender
            if (destMember is ICellRender render)
             { 


                var namecell = render.Name;
                if (string.IsNullOrEmpty(namecell))
                {
                    namecell = typeof(D).GetProperties()
                                                  .FirstOrDefault(p => p.GetValue(dest) == destMember)?.Name;
                   
                }


                
                render.Create(src.GetType().GetProperty(namecell)?.GetValue(src));
                
                return render;

            }

            var name = typeof(D).GetProperties().FirstOrDefault(p => p.GetValue(dest) == destMember)?.Name;

            var value = src.GetType().GetProperty(name)?.GetValue(src);

            if (value != null&& value.GetType()==destMember.GetType())
            {
                return value;
            }

            return  destMember;

        }
    }   

  




}
