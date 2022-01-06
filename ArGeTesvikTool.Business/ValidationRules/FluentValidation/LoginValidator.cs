using ArGeTesvikTool.Entities.Concrete;
using ArGeTesvikTool.WebUI.Models.Authentication;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArGeTesvikTool.Business.ValidationRules.FluentValidation
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adını giriniz");
        }
    }
}
