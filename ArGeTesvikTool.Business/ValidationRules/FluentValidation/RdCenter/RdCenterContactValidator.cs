using ArGeTesvikTool.Entities.Concrete.RdCenter;
using FluentValidation;

namespace ArGeTesvikTool.Business.ValidationRules.FluentValidation.Business
{
    public class RdCenterContactValidator : AbstractValidator<RdCenterContactDto>
    {
        public RdCenterContactValidator()
        {
            RuleFor(x => x.IdentityNumber.ToString())
                .NotEmpty().WithMessage("Kimlik numrasını giriniz.")
                .Must(x => x.Length < 12).WithMessage("Kimlik numarası alanına 11 karakterden fazla girmeyin.");

            RuleFor(x => x.NameSurname)
                .NotEmpty().WithMessage("İsim soyisim giriniz.");
        }
    }
}
