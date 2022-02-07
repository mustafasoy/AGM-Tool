using ArGeTesvikTool.Entities.Concrete.Business;
using FluentValidation;

namespace ArGeTesvikTool.Business.ValidationRules.FluentValidation.Business
{
    public class BusinessInfoValidator : AbstractValidator<BusinessInfoDto>
    {
        public BusinessInfoValidator()
        {
            RuleFor(x => x.PhoneNumber.ToString())
                .Must(x => x.Length < 12).WithMessage("Telefon numarası alanına 11 karakterden fazla girmeyin.");

            RuleFor(x => x.TradeNumber.ToString())
                .Must(x => x.Length < 26).WithMessage("Sanayi/Ticaret sicil numarası alanına 26 karakterden fazla girmeyin.");
            
            RuleFor(x => x.RegistrationNo.ToString())
                .Must(x => x.Length < 26).WithMessage("SGK işyeri sicil numarası alanına 26 karakterden fazla girmeyin.");

            RuleFor(x => x.CRSNumber.ToString())
                .Must(x => x.Length < 16).WithMessage("Mersis numarası alanına 16 karakterden fazla girmeyin.");
        }
    }
}
