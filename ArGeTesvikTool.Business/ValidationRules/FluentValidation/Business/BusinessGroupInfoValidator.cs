using ArGeTesvikTool.Entities.Concrete.Business;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArGeTesvikTool.Business.ValidationRules.FluentValidation.Business
{
    public class BusinessGroupInfoValidator : AbstractValidator<GroupInfoDto>
    {
        public BusinessGroupInfoValidator()
        {
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Şirket ünvanı giriniz.");
        }
    }
}
