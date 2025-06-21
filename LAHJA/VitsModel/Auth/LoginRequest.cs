using System.ComponentModel.DataAnnotations;

namespace LAHJA.VitsModel.Auth
{
    public class LoginRequest
    {

        [Required(ErrorMessage = "البريد الإلكتروني مطلوب")]
        [EmailAddress(ErrorMessage = "صيغة البريد الإلكتروني غير صحيحة")]
        public string Email { get; set; } = "Azdeenedghg@gmail.com";

        [Required(ErrorMessage = "كلمة المرور مطلوبة")]
        public string Password { get; set; } = "Azdeen2024$$$";
    }
}
