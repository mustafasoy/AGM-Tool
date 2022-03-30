using ArGeTesvikTool.Entities.Concrete.Business;
using FluentValidation;

namespace ArGeTesvikTool.Business.ValidationRules.FluentValidation.Business
{
    public class BusinessInfoValidator : AbstractValidator<BusinessInfoDto>
    {
        public BusinessInfoValidator()
        {
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Şirket ünvanı giriniz.");

            RuleFor(x => x.ActivityCode)
                .NotEmpty().WithMessage("Faaliyet kodunu giriniz.");

            RuleFor(x => x.PhoneNumber.ToString())
                .MaximumLength(14)
                .When(x => !string.IsNullOrEmpty(x.PhoneNumber))
                .WithMessage("Telefon numarası yanlış.");

            RuleFor(x => x.TradeNumber.ToString())
                .MaximumLength(26)
                .When(x => !string.IsNullOrEmpty(x.TradeNumber))
                .WithMessage("Sanayi/Ticaret sicil numarası alanına 26 karakterden fazla girmeyin.");
            
            RuleFor(x => x.RegistrationNo.ToString())
                .MaximumLength(26)
                .When(x => !string.IsNullOrEmpty(x.RegistrationNo))
                .WithMessage("SGK işyeri sicil numarası alanına 26 karakterden fazla girmeyin.");

            RuleFor(x => x.CRSNumber.ToString())
                .MaximumLength(16)
                .When(x => !string.IsNullOrEmpty(x.CRSNumber))
                .WithMessage("Mersis numarası alanına 16 karakterden fazla girmeyin.");
        }
    }
}
