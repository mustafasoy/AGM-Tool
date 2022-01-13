﻿using ArGeTesvikTool.Entities.Concrete;
using ArGeTesvikTool.WebUI.Models.Authentication;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ArGeTesvikTool.Business.ValidationRules.FluentValidation
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim giriniz!")
                .MinimumLength(3).WithMessage("İsim alanı 3 karakterden fazla olmalıdır!");
            
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soy isminizi giriniz!")
                .MinimumLength(3).WithMessage("Soy isim 3 karakterden fazla olmalıdır!");
            
            RuleFor(x => x.UserName)
                .Must(HasValidUserName).WithMessage("Kullanıcı adı sayı içeremez!");
            
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Mail adresi giriniz!")
                .EmailAddress();
            
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre giriniz!");
        }

        private bool HasValidUserName(string arg)
        {
            return Regex.IsMatch(arg, "^[a-zA-Z_.]+$");
        }
    }
}
