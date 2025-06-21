using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Constants;

namespace LAHJA.Pages
{
    public class LangModel : PageModel
    {
        public void OnGet()
        {
            string? culture = Request.Query["culture"];
            Console.WriteLine("new selected language: " + culture);
            if (culture != null)
            {
                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );
            }


            string returnUrl = Request.Headers["Referer"].ToString() ?? "/";
            Response.Redirect(returnUrl);
        }




       

        //public string GetTokenFromCookie()
        //{
        //    return Request.Cookies[ConstantsApp.ACCESS_TOKEN];
        //}

        //// ÿ—Ìﬁ… ·Õ–› «· Êﬂ‰ „‰ «·ﬂÊﬂÌ
        //public void RemoveTokenFromCookie()
        //{
        //    Response.Cookies.Delete(ConstantsApp.ACCESS_TOKEN);
        //}

    }
}
