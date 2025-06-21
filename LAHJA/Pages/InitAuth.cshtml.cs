using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Constants;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MudBlazor;
using System.Security.Claims;
namespace LAHJA.Pages
{
    public class InitAuthModel : PageModel
    {
        private readonly ILogger<InitAuthModel> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CustomAuthenticationStateProvider AuthStateProvider;
        public InitAuthModel(IHttpContextAccessor httpContextAccessor, ILogger<InitAuthModel> logger, CustomAuthenticationStateProvider authStateProvider)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            AuthStateProvider = authStateProvider;
        }

        public async void OnGet()
        {
            try
            {
                var option = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = false,
                    Expires = DateTimeOffset.UtcNow.AddDays(30),
                    SameSite = SameSiteMode.Strict,
                };

                string? token = Request.Query[ConstantsApp.ACCESS_TOKEN];
                string? refresh_token = Request.Query[ConstantsApp.REFRESH_TOKEN];
                string? login_type = Request.Query[ConstantsApp.LOGIN_TYPE];
           

                if (!string.IsNullOrEmpty(token))
                {
                    _httpContextAccessor.HttpContext?.Response.Cookies.Append(ConstantsApp.ACCESS_TOKEN,token, option);
                    if (!string.IsNullOrEmpty(refresh_token))
                    {
                        _httpContextAccessor.HttpContext?.Response.Cookies.Append(ConstantsApp.REFRESH_TOKEN, refresh_token, option);
                    }
                    if (!string.IsNullOrEmpty(login_type))
                    {
                        _httpContextAccessor.HttpContext?.Response.Cookies.Append(ConstantsApp.LOGIN_TYPE, login_type, option);
                    }

                    await AuthStateProvider.InitializeAsync();
                    Response.Redirect("/");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "حدث خطأ أثناء معالجة التوكن.");
            }
        }

        public void OnGet2()
        {
            string? token = Request.Query["token"];
            Console.WriteLine("token: " + token);

            if (!string.IsNullOrEmpty(token))
            {

                _httpContextAccessor.HttpContext.Response.Cookies.Append(
                 ConstantsApp.ACCESS_TOKEN,  // اسم الكوكي
                   token,        // التوكن
                   new CookieOptions
                   {
                       HttpOnly = true,  // جعل الكوكيز غير قابلة للوصول عبر JavaScript
                       Secure = true,    // إرسال الكوكيز فقط عبر HTTPS
                       Expires = DateTimeOffset.UtcNow.AddDays(30),  // مدة صلاحية الكوكي
                       SameSite = SameSiteMode.Strict,  // حماية ضد هجمات CSRF

                   }
               );
              
                //string returnUrl = Request.Headers["Referer"].ToString() ?? "/";
                //Response.Redirect(returnUrl)

                Response.Redirect("/");
            }
        }


        public async Task<IActionResult> OnGet3()
        {
            //ReturnUrl = returnUrl;

            string? token = Request.Query["token"];
            Console.WriteLine("token: " + token);
            if (!string.IsNullOrEmpty(token))
            {
                // Use Input.Email and Input.Password to authenticate the user
                // with your custom authentication logic.
                //
                // For demonstration purposes, the sample validates the user
                // on the email address maria.rodriguez@contoso.com with 
                // any password that passes model validation.

                //var user = await AuthenticateUser(Input.Email, Input.Password);

                //if (user == null)
                //{
                //    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                //    return Page();
                //}

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "UserName"),
                    new Claim("UserId", "UserId"),
                    new Claim(ClaimTypes.Role, "User"),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    //IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                //_logger.LogInformation("User {Email} logged in at {Time}.",
                //    user.Email, DateTime.UtcNow);

             
            }

            return LocalRedirect("/");
        }



    }



}
