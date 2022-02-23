using ArGeTesvikTool.Entities.Concrete;
using FluentValidation;

namespace ArGeTesvikTool.Business.ValidationRules.FluentValidation
{
    public class PasswordChangeValidator : AbstractValidator<PasswordChangeDto>
    {
        public PasswordChangeValidator()
        {
            RuleFor(x => x.OldPassword)
                .NotEmpty().WithMessage("Eski şifrenizi giriniz.")
                .MinimumLength(6).WithMessage("Eski şifreniz en az 6 karakter olmalıdır.");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("Yeni şifrenizi giriniz.")
                .MinimumLength(6).WithMessage("Yeni şifreniz en az 6 karakter olmalıdır.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Tekrar şifrenizi giriniz.")
                .MinimumLength(6).WithMessage("Tekrar şifreniz en az 6 karakter olmalıdır.")
                .Equal(x => x.NewPassword).WithMessage("Tekrar şifreniz uyuşmuyor.");
        }
    }
}
