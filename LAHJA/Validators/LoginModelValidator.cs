using FluentValidation;
using LAHJA.Data.UI.Components.Base;
using LAHJA.Helpers;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace LAHJA.Validators
{
    public class LoginModelValidator : AbstractValidator<DataBuildAuthBase>
    {
        private readonly CustomStringLocalizer _localizer;
        public LoginModelValidator(IStringLocalizer<LoginModelValidator> localizer)
        {

            _localizer = new CustomStringLocalizer("LAHJA.Resources.Validator.ValidationMessages");


            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(_localizer.GetLocalizedString("EmailRequired"))
                .EmailAddress().WithMessage(_localizer.GetLocalizedString("InvalidEmail"));

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(_localizer.GetLocalizedString("PasswordRequired"))
                .MinimumLength(8).WithMessage(_localizer.GetLocalizedString("PasswordTooShort"))
                .Matches(@"[A-Z]").WithMessage(_localizer.GetLocalizedString("PasswordUppercase")) // يجب أن تحتوي على حرف كبير
                .Matches(@"[a-z]").WithMessage(_localizer.GetLocalizedString("PasswordLowercase")) // يجب أن تحتوي على حرف صغير
                .Matches(@"[0-9]").WithMessage(_localizer.GetLocalizedString("PasswordDigit")) // يجب أن تحتوي على رقم
                .Matches(@"[\W_]").WithMessage(_localizer.GetLocalizedString("PasswordSpecialChar")) // يجب أن تحتوي على رمز خاص
                .WithMessage(_localizer.GetLocalizedString("InvalidPasswordComplexity"));
        }
    }
}
