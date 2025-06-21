using System.ComponentModel.DataAnnotations;

namespace LAHJA.VitsModel.Auth
{
    public class RegisterRequest
    {

        [Required(ErrorMessage = "البريد الإلكتروني مطلوب.")]
        [EmailAddress(ErrorMessage = "البريد الإلكتروني غير صحيح.")]
        public string Email { get; set; } = "Azdeenedghg@gmail.com";

        //[Required(ErrorMessage = "كلمة المرور مطلوبة.")]
        //[StringLength(100, MinimumLength = 6, ErrorMessage = "يجب أن تكون كلمة المرور مكونة من 6 أحرف أو أكثر.")]
        //public string Password { get; set; } = "Azdeen2024$$$";

        [Required(ErrorMessage = "تأكيد كلمة المرور مطلوب.")]
        [Compare("Password", ErrorMessage = "كلمة المرور وتأكيد كلمة المرور غير متطابقين.")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d{2,})(?=.*[!@#$%^&*]).{8,}$",
        ErrorMessage = "Password must have at least 8 characters, 2 digits, and 1 special character.")]
        public string Password { get; set; } = "Azdeen2024$$$";

        //[Required(ErrorMessage = "Password confirmation is required.")]
        //[Compare("Password", ErrorMessage = "Password and confirmation do not match.")]
        //public string ConfirmPassword { get; set; }


        [Phone(ErrorMessage = "رقم الهاتف غير صحيح.")]
        public string PhoneNumber { get; set; } = "787878777";

        [Required(ErrorMessage = "الدور مطلوب.")]
        public string UserRole { get; set; } = "user";

    }
}
