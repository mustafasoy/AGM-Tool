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
                .MaximumLength(14)
                .When(x => !string.IsNullOrEmpty(x.PhoneNumber))
                .WithMessage("Telefon numarası yanlış");
        }
    }
}
