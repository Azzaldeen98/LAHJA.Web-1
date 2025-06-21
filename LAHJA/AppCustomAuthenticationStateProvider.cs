//using Microsoft.AspNetCore.Components.Authorization;
//using Microsoft.AspNetCore.Http;
//using Newtonsoft.Json.Linq;
//using Shared.Helpers;
//using System.Data;
//using System.Security.Claims;

//namespace LAHJA
//{
//    public class AppCustomAuthenticationStateProvider : AuthenticationStateProvider
//    {
//        private ClaimsPrincipal _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
//        private readonly IHttpContextAccessor _httpContextAccessor;

//        public AppCustomAuthenticationStateProvider(IHttpContextAccessor httpContextAccessor)
//        {
//            _httpContextAccessor = httpContextAccessor;
//        }
//        public override  Task<AuthenticationState> GetAuthenticationStateAsync()
//        {

//            var token = _httpContextAccessor.HttpContext.Request.Cookies["AccessToken"];
//            var role = _httpContextAccessor.HttpContext.Request.Cookies["Role"];

//            if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(role))
//            {
//                var claims = new List<Claim>
//                {
//                    new Claim("AccessToken", token),
//                    new Claim(ClaimTypes.Role, role)
//                };

//                var identity = new ClaimsIdentity(claims, "CustomAuth");
//                _currentUser = new ClaimsPrincipal(identity);

//                NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
//            }

//            return Task.FromResult(new AuthenticationState(_currentUser));
//        }

//        //public void SignIn(string token, string role="User")
//        //{
//        //    var claims = new List<Claim>
//        //{
//        //    //new Claim(ClaimTypes.NameIdentifier, userId),
//        //    new Claim("AccessToken", token),
//        //    //new Claim(ClaimTypes.Email, email),
//        //    new Claim(ClaimTypes.Role, role)
//        //};

//        //    _currentUser = new ClaimsPrincipal(new ClaimsIdentity(claims, "CustomAuth"));
//        //    NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
//        //}

//        public void SignOut()
//        {

//            _httpContextAccessor.HttpContext.Response.Cookies.Delete("AccessToken");
//            _httpContextAccessor.HttpContext.Response.Cookies.Delete("Role");

//            _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
//            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
//        }

//        public void StoreAuthenticationData(string token, string role="User")
//        {
//            var claims = new List<Claim>
//            {
//                new Claim("AccessToken", token),
//                //new Claim(ClaimTypes.Role, role)
//            };

//             var identity = new ClaimsIdentity(claims, "CustomAuth");
//            _currentUser = new ClaimsPrincipal(identity);

       
//            var cookieOptions = new CookieOptions { HttpOnly = true, Secure = true };

            
//                //if (!_httpContextAccessor.HttpContext.Response.HasStarted)
//                //{
//                //_httpContextAccessor.HttpContext.Response.Cookies.Append("AccessToken", token, cookieOptions);
//                //_httpContextAccessor.HttpContext.Response.Cookies.Append("Role", role, cookieOptions);

            

//            //_httpContextAccessor.HttpContext.Response.Cookies.Append("AccessToken", token, cookieOptions);
//            //_httpContextAccessor.HttpContext.Response.Cookies.Append("Role", role, cookieOptions);

//            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
//        }

//        public async Task InitializeAuthenticationState()
//        {
//            var token = _httpContextAccessor.HttpContext.Request.Cookies["AccessToken"];
//            var role = _httpContextAccessor.HttpContext.Request.Cookies["Role"];

//            if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(role))
//            {
//                var claims = new List<Claim>
//                {
//                    new Claim("AccessToken", token),
//                    new Claim(ClaimTypes.Role, role)
//                };

//                var identity = new ClaimsIdentity(claims, "CustomAuth");
//                _currentUser = new ClaimsPrincipal(identity);

//                NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
//            }
//        }


//    }

//    public interface IAppUserClaimsHelper
//    {
//        //string UserId { get; }
//        string UserRole { get; }
//        //string Email { get; }
//        //public string AccessTokenHash { get; }
//        public string AccessToken { get; }
//        //public string RefreshToken { get; }
//        public bool IsAuthenticated { get; set; } 
//        public  Task LoadUserClaimsAsync();

//    }


//    public class AppUserClaimsHelper : IAppUserClaimsHelper
//    {
//        private readonly AuthenticationStateProvider _authenticationStateProvider;

//        //public string UserId { get; private set; } = string.Empty;
//        //public string Email { get; private set; } = string.Empty;
//        public string Role { get; private set; } = string.Empty;
//        public string AccessToken { get; set; } = string.Empty;
//        public  bool IsAuthenticated { get;  set; } = false;

//        public string UserRole => throw new NotImplementedException();

//        public AppUserClaimsHelper(AuthenticationStateProvider authenticationStateProvider)
//        {
//            _authenticationStateProvider = authenticationStateProvider;
//        }

//        public async Task LoadUserClaimsAsync()
//        {
//            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
//            var user = authState.User;

//            IsAuthenticated = user.Identity?.IsAuthenticated ?? false;

//            if (IsAuthenticated)
//            {
//                //UserId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
//                //Email = user.FindFirst(c => c.Type == ClaimTypes.Email)?.Value ?? string.Empty;
//                Role = user.FindFirst(c => c.Type == ClaimTypes.Role)?.Value ?? string.Empty;
//                AccessToken = user.FindFirst(c => c.Type == "AccessToken")?.Value ?? string.Empty;
//            }
//        }
//    }


//}
