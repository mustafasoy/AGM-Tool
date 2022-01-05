using ArGeTesvikTool.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArGeTesvikTool.Business.ValidationRules.FluentValidation
{
    public class RegisterValidator : AbstractValidator<Register>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim giriniz!")
                .MinimumLength(3).WithMessage("En az 3 karakterden fazla olmalıdır!");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soy isminizi giriniz!")
                .MinimumLength(3).WithMessage("En az 3 karakterden fazla olmalıdır!");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Mail adresi giriniz!")
                .EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre giriniz!")
                .MinimumLength(4)
                .MaximumLength(10);
        }
    }
}
