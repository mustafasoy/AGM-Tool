using ArGeTesvikTool.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArGeTesvikTool.Business.ValidationRules.FluentValidation
{
    public class UserInfoChangeValidator : AbstractValidator<UserDto>
    {
        public UserInfoChangeValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Mail adresi giriniz!")
                .EmailAddress();

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim giriniz!")
                .MinimumLength(2).WithMessage("İsim alanı 2 karakterden fazla olmalıdır!");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soy isminizi giriniz!")
                .MinimumLength(2).WithMessage("Soy isim 2 karakterden fazla olmalıdır!");
        }
    }
}
