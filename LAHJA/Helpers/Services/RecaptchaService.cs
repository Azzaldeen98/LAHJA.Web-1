using Shared.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LAHJA.Helpers.Services
{


    //public class RecaptchaService
    //{
    //    private readonly HttpClient _httpClient;
    //    private readonly ReCaptchaSettings googleRecaptcha;
    //    private const string VerificationUrl = "https://www.google.com/recaptcha/api/siteverify";

    //    public RecaptchaService(HttpClient httpClient, ReCaptchaSettings googleRecaptcha)
    //    {
    //        _httpClient = httpClient;
    //        this.googleRecaptcha = googleRecaptcha;
    //    }

    //    public async Task<bool> VerifyAsync(string token, string secretKey)
    //    {
    //        var response = await _httpClient.PostAsync($"{googleRecaptcha.VerificationUrl}?secret={googleRecaptcha.SecretKey}&response={googleRecaptcha.SiteKey}", null);
    //        if (response.IsSuccessStatusCode)
    //        {
    //            var json = await response.Content.ReadAsStringAsync();
    //            var result = JsonSerializer.Deserialize<RecaptchaResponse>(json);
    //            return result?.Success ?? false;
    //        }
    //        return false;
    //    }
    //}



}
