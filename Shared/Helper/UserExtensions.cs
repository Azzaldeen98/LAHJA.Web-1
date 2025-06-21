using System.Linq;
using System.Security.Claims;

namespace Shared.Helpers
{

    public static class UserExtensions
    {
        public static string GetClaim(this ClaimsPrincipal claimsPrincipal, string claimName)
        {
            var claim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == claimName);
            return claim?.Value;
        }
    }

}