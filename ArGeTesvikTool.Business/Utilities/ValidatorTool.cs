using FluentValidation;
using FluentValidation.Results;

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
