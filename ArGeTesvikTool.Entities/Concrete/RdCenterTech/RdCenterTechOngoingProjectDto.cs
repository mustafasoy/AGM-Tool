using ArGeTesvikTool.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterTech
{
    public class RdCenterTechOngoingProjectDto : AuditableEntity
    {
        public ProjectStatu ProjectStatu { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public decimal EquityAmount { get; set; }
        public decimal SupportAmount { get; set; }
        public string ProgramName { get; set; }
        public string InternationalProgName { get; set; }
        public decimal TotalProjectBudget { get; set; }
    }

    public enum ProjectStatu
    {
        [Display(Name = "Devam Eden")]
        Devam = 1,
        [Display(Name = "Tamamlanan")]
        Tamam = 2,
        [Display(Name = "İptal Edilen")]
        Iptal = 3,
    }
}
