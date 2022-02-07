using ArGeTesvikTool.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArGeTesvikTool.Business.ValidationRules.FluentValidation
{
    public class RoleValidator : AbstractValidator<RoleDto>
    {
        public RoleValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Rol adını giriniz!");

            RuleFor(x => x.RoleText)
                .NotEmpty().WithMessage("Rol tanımı giriniz!");
        }
    }
}
