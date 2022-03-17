using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using FluentValidation;

namespace ArGeTesvikTool.Business.ValidationRules.FluentValidation.RdCenterTech
{
    public class RdCenterTechProjectValidator: AbstractValidator<RdCenterTechProjectDto>
    {
        public RdCenterTechProjectValidator()
        {
            RuleFor(x => x.ProjectStatu)
                .NotEmpty().WithMessage("Proje durumunu seçiniz.");

            RuleFor(x => x.ProjectCode)
                .NotEmpty().WithMessage("Proje kodunu giriniz.");

            RuleFor(x => x.ProjectName)
                .NotEmpty().WithMessage("Proje adını giriniz.");
        }
    }
}
