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
                .Length(6).WithMessage("Şifreniz en az 6 karakter olmalıdır.");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("Yeni şifrenizi giriniz.")
                .Length(6).WithMessage("Şifreniz en az 6 karakter olmalıdır.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Yeni şifrenizi tekrar giriniz.")
                .Length(6).WithMessage("Şifreniz en az 6 karakter olmalıdır.")
                .Equal(x => x.NewPassword).WithMessage("Yeni şifreniz uyuşmuyor.");
        }
    }
}
