using ArGeTesvikTool.Entities.Concrete.RdCenter;
using FluentValidation;

namespace ArGeTesvikTool.Business.ValidationRules.FluentValidation.RdCenter
{
    public class RdCenterInfoValidator : AbstractValidator<RdCenterInfoDto>
    {
        public RdCenterInfoValidator()
        {
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Şirket ünvanı giriniz.");
        }
    }
}
