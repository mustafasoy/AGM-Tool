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
                .NotEmpty().WithMessage("İsim giriniz.")
                .MinimumLength(2).WithMessage("İsim alanı 2 karakterden fazla olmalıdır.");
            
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soy isminizi giriniz.")
                .MinimumLength(2).WithMessage("Soy isim 2 karakterden fazla olmalıdır.");
            
            RuleFor(x => x.UserName)
                .Must(HasValidUserName).WithMessage("Kullanıcı adı sayı içeremez.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Mail adresi giriniz.")
                .EmailAddress();
            
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre giriniz.");

            RuleFor(x => x.IdentityNumber)
                .NotEmpty().WithMessage("TC kimlik numarasını giriniz.")
                .MaximumLength(11);

            RuleFor(x => x.RegistrationNo)
                .NotEmpty().WithMessage("Sicil numarasını giriniz.")
                .MaximumLength(26);

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("işe başlangıç tarihi giriniz.");

            RuleFor(x => x.PersonPosition)
                .NotEmpty().WithMessage("Görevi seçiniz.");

            RuleFor(x => x.WorkType)
                .NotEmpty().WithMessage("Çalışma şeklini seçiniz.");

            RuleFor(x => x.CountryCode)
                .NotEmpty().WithMessage("Uyruğunu seçiniz.");

            RuleFor(x => x.EducationStatu)
                .NotEmpty().WithMessage("Eğitim durumunu seçiniz.");

            RuleFor(x => x.GraduateUniversity)
                .NotEmpty().WithMessage("Mezun olduğu lise/üniversite giriniz.");

            RuleFor(x => x.UniversityDepartmant)
                .NotEmpty().WithMessage("Mezun olduğu bölüm giriniz.");
        }

        private bool HasValidUserName(string arg)
        {
            return Regex.IsMatch(arg, "^[a-zA-Z_.ıuşço]+$");
        }
    }
}