using ArGeTesvikTool.WebUI.Models.Authentication;
using FluentValidation;

namespace ArGeTesvikTool.Business.ValidationRules.FluentValidation
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Mail adresi giriniz.")
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre giriniz.");
        }
    }
}
