using ArGeTesvikTool.Entities.Concrete;
using FluentValidation;

namespace ArGeTesvikTool.Business.ValidationRules.FluentValidation
{
    public class RoleValidator : AbstractValidator<RoleDto>
    {
        public RoleValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Rol adını giriniz.");

            RuleFor(x => x.RoleText)
                .NotEmpty().WithMessage("Rol tanımı giriniz.");
        }
    }
}
