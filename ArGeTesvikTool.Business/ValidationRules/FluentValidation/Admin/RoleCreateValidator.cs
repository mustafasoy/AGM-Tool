using ArGeTesvikTool.Entities.Concrete;
using FluentValidation;

namespace ArGeTesvikTool.Business.ValidationRules.FluentValidation
{
    public class RoleCreateValidator : AbstractValidator<RoleDto>
    {
        public RoleCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Role adı giriniz.");

            RuleFor(x => x.RoleText)
                .NotEmpty().WithMessage("Role tanımı giriniz.");
        }
    }
}
