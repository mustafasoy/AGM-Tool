using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArGeTesvikTool.Business.Utilities
{
    public class ValidatorTool
    {
        public static ValidationResult Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            return validator.Validate(context);
        }
    }
}
