using ArGeTesvikTool.Entities.Concrete.Business;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArGeTesvikTool.Business.ValidationRules.FluentValidation.Business
{
    public class BusinessContactValidator : AbstractValidator<BusinessContactDto>
    {
        public BusinessContactValidator()
        {
            RuleFor(x => x.IdentityNumber.ToString())
                .Must(x => x.Length < 12).WithMessage("Kimlik numarası alanına 11 karakterden fazla girmeyin.");

            RuleFor(x => x.PhoneNumber.ToString())
                .Must(x => x.Length < 12).WithMessage("Telefon numarası alanına 11 karakterden fazla girmeyin.");
        }
    }
}
