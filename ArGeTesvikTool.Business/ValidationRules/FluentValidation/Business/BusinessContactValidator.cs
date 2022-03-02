using ArGeTesvikTool.Entities.Concrete.Business;
using FluentValidation;

namespace ArGeTesvikTool.Business.ValidationRules.FluentValidation.Business
{
    public class BusinessContactValidator : AbstractValidator<BusinessContactDto>
    {
        public BusinessContactValidator()
        {
            RuleFor(x => x.IdentityNumber.ToString())
                .NotEmpty().WithMessage("Kimlik numrasını giriniz.")
                .Must(x => x.Length < 12).WithMessage("Kimlik numarası alanına 11 karakterden fazla girmeyin.");

            RuleFor(x => x.NameSurname)
                .NotEmpty().WithMessage("İsim soyisim giriniz.");

            RuleFor(x => x.PhoneNumber.ToString())
                .InclusiveBetween("10", "11").WithMessage("Telefon numarası 10 ile 11 hane arasında olmalıdır");
        }
    }
}
