using Microsoft.AspNetCore.Http;

namespace Shared.LocalStorage
{

    public class ProtectedCookieStorage : IProtectedCookieStorage
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProtectedCookieStorage(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task SaveAsync(string key, string value)
        {
            if(string.IsNullOrEmpty(key)  || string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value), "Value cannot be null or empty.");
            }

            var context = _httpContextAccessor.HttpContext!;
            context.Response.Cookies.Append(key, value, new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddDays(7)
            });
            return Task.CompletedTask;
        }

        public Task<string?> GetAsync(string key)
        {
            if (string.IsNullOrEmpty(key) )
            {
                throw new ArgumentNullException(nameof(key), "key cannot be null or empty.");
            }
            var context = _httpContextAccessor.HttpContext!;
            context.Request.Cookies.TryGetValue(key, out var value);
            return Task.FromResult(value);
        }

        public Task DeleteAsync(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key), "key cannot be null or empty.");
            }

            var context = _httpContextAccessor.HttpContext!;
            context.Response.Cookies.Delete(key);
            return Task.CompletedTask;
        }


    }

}