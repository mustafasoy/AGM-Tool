using ArGeTesvikTool.WebUI.Models.Authentication;
using FluentValidation;
using System.Text.RegularExpressions;

namespace ArGeTesvikTool.Business.ValidationRules.FluentValidation
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim giriniz!")
                .MinimumLength(2).WithMessage("İsim alanı 2 karakterden fazla olmalıdır!");
            
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soy isminizi giriniz!")
                .MinimumLength(2).WithMessage("Soy isim 2 karakterden fazla olmalıdır!");
            
            RuleFor(x => x.UserName)
                .Must(HasValidUserName).WithMessage("Kullanıcı adı sayı içeremez!");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Mail adresi giriniz!")
                .EmailAddress();
            
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre giriniz!");
        }

        private bool HasValidUserName(string arg)
        {
            return Regex.IsMatch(arg, "^[a-zA-Z_.]+$");
        }
    }
}
