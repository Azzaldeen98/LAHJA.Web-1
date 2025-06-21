using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Constants;
using System.Threading.Tasks;

namespace LAHJA.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CustomAuthenticationStateProvider AuthStateProvider;

        public LogoutModel(IHttpContextAccessor httpContextAccessor, CustomAuthenticationStateProvider authStateProvider)
        {
            _httpContextAccessor = httpContextAccessor;
            AuthStateProvider = authStateProvider;
        }

        public async Task OnGetAsync()
        {

           
            DeleteCookie();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            AuthStateProvider.MarkUserAsLoggedOut();
            Response.Redirect("/");
        }

        private void DeleteCookie()
        {
            try
            {
                var context = _httpContextAccessor.HttpContext;
                if (context != null)
                {
                    context.Response.Cookies.Delete(ConstantsApp.ACCESS_TOKEN);
                    context.Response.Cookies.Delete(ConstantsApp.REFRESH_TOKEN);
                    context.Response.Cookies.Delete(ConstantsApp.LOGIN_TYPE);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //public async Task<IActionResult> OnGet()
        //{
        //    //if (!string.IsNullOrEmpty(ErrorMessage))
        //    //{
        //    //    ModelState.AddModelError(string.Empty, ErrorMessage);
        //    //}

        //    // Clear the existing external cookie


        //    DeleteCookie();
        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    AuthStateProvider.MarkUserAsLoggedOut();

        //    return RedirectToPage("/");
        //}
    }

}
