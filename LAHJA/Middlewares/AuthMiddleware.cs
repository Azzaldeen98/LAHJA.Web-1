using Shared.Constants;

namespace LAHJA.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            if (context.Request.Cookies.ContainsKey(ConstantsApp.ACCESS_TOKEN))
            {
                var token = context.Request.Cookies[ConstantsApp.ACCESS_TOKEN];
                if (!string.IsNullOrEmpty(token))
                {
                    context.Request.Headers.Append("Authorization", $"Bearer {token}");
                }

            
            }
            await _next(context);
        }
    }
}
