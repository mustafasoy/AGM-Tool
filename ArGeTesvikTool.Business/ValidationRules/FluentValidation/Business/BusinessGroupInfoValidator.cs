using ArGeTesvikTool.Entities.Concrete.Business;
using FluentValidation;

namespace ArGeTesvikTool.Business.ValidationRules.FluentValidation.Business
{
    public class BusinessGroupInfoValidator : AbstractValidator<GroupInfoDto>
    {
        public BusinessGroupInfoValidator()
        {
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Şirket ünvanı giriniz.");
        }
    }
}
