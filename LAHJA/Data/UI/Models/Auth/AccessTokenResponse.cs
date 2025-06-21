using Shared.Interfaces;

namespace LAHJA.Data.UI.Models.Auth
{
    public class AccessTokenResponse : ITVM
    {
        public string TokenType { get; set; }
        public string AccessToken { get; set; }
        public string ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
    }
}
