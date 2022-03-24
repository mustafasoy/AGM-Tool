using ArGeTesvikTool.Entities.Concrete;
using FluentValidation;

namespace ArGeTesvikTool.Business.ValidationRules.FluentValidation
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordDto>
    {
        public ResetPasswordValidator()
        {
            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("Şifre giriniz.");
        }
    }
}
